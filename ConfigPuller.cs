/* #########################################################################*/
/* #                                                                       #*/
/* #  This file is part of ConfigurationManager project, which is written  #*/
/* #  as a Script N'Go plug-in to help configuration management of         #*/
/* #  Cisco devices.                                                       #*/
/* #                                                                       #*/
/* #  You may not use this file except in compliance with the license.     #*/
/* #                                                                       #*/
/* #  Copyright Laszlo Frank (c) 2014-2020                                 #*/
/* #                                                                       #*/
/* #########################################################################*/

using MoreLinq;
using Scriptngo.Common;
using Scriptngo.ExtensionInterfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scriptngo.ConfigurationManager
{
  public partial class ConfigPuller : Form
  {
    #region Fields
    /// <summary>
    /// The ID of the configuration set beeing deployed
    /// </summary>
    private int _configurationSetID;
    private WorkInProgress _workInProgress;
    private string _workInProgressText = "Work in progress...";
    private string _workInProgressCaption = "Please be patient";
    private bool _workInProgress_CancelPressed = false;
    private bool _workInProgressSupportCancellation = false;
    private SqlCommand _workInProgressSqlCommandToCancel = null;
    /// <summary>
    /// Used for thread syncronization
    /// </summary>
    private object _lckObject = new object();
    /// <summary>
    /// Used to remember Button back colors
    /// </summary>
    private Hashtable ButtonColors = new Hashtable();
    /// <summary>
    /// The list of ScriptManagers of opened Scripting Forms
    /// </summary>
    private List<SNGScriptManager> ScriptManagers = new List<SNGScriptManager>();
    /// <summary>
    /// Indicates whether the Form can be closed at its current state
    /// </summary>
    private bool CanClose = true;
		private SNGDataSet SNGDataSet;
    #endregion

    #region Initialization
    public ConfigPuller(SNGDataSet ds, int ConfigurationSetID)
    {
      InitializeComponent();
			this.SNGDataSet = ds;
			_workInProgress = new WorkInProgress(_workInProgressCaption, _workInProgressText );
      SetControlBackGround(this);
      _configurationSetID = ConfigurationSetID;
    }
    private void SetControlBackGround(Control rootControl)
    {
      if (rootControl != null)
      {
        foreach (Control thisControl in rootControl.Controls)
        {
          if (thisControl is System.Windows.Forms.Label || thisControl is CheckBox || thisControl is GroupBox)
          {
            thisControl.BackColor = System.Drawing.Color.Transparent;
            MethodInfo m = thisControl.GetType().GetMethod("SetStyle");
            if (m != null) m.Invoke(thisControl, new object[] { ControlStyles.SupportsTransparentBackColor, true });
          }
          SetControlBackGround(thisControl);
        }
      }

    }
    private void DrawGradientBackground(object sender, PaintEventArgs e)
    {
      Rectangle rect = (sender as Control).ClientRectangle;
      using (Brush br = new LinearGradientBrush(rect, System.Drawing.Color.White, (sender as Control).BackColor, LinearGradientMode.Vertical))
      {
        e.Graphics.FillRectangle(br, rect);
      }
    }
    private void ConfigPuller_Load(object sender, EventArgs e)
    {
      setTargetsTA.FillTargetsInSet(configDS.SetTargets, _configurationSetID);
      if (configDS.SetTargets.Rows.Count > 0)
      {
        tbSelConfigSetName.Text = ((ConfigDS.SetTargetsRow)configDS.SetTargets.Rows[0]).ConfigSetName;
        foreach (var item in configDS.SetTargets)
        {
          clbTargets.Items.Add(item, true);
        }
      }
      else
      {
        btnPullConfig.Enabled = false;
        MessageBox.Show("There no targets in this set to pull the configuration from.", "Empty configuration set", MessageBoxButtons.OK, MessageBoxIcon.Error);
        Close();
      }
    }
    #endregion

    #region Private members

    /// <summary>
    /// Cancels pending pull operations
    /// </summary>
    private void CancelPullOperation()
    {
      lock (_lckObject)
      {
        pbPullProgress.Value = 0;
        pbPullProgress.Maximum = ScriptManagers.Count;
        lblOperationInProgress.Text = "Cancelling operation...";
        pbPullProgress.Visible = true;
        List<Task> terminators = new List<Task>();
        for (int i = ScriptManagers.Count - 1; i >= 0; i--)
        {
          SNGScriptManager thisManager = ScriptManagers[i];
          // Remove from ScriptManagers list to prevent acting on _ScriptManager_OnScriptFinished() event fired by th script
          // in response to StopScript() call below.
          // ScriptManagers.Remove(thisManager);
          terminators.Add(Task.Factory.StartNew(() => TerminateScript(thisManager)));
        }
        int waitTime = (int)SettingsManager.GetCurrentScriptSettings(this.SNGDataSet).ConnectTimeout.TotalMilliseconds;
        Task.Factory.StartNew(new Action(delegate
        {
          // wait for each task to complete for the double amount of connection timeout
          terminators.ForEach(t => t.Wait(2 * waitTime));
          Invoke(new MethodInvoker(delegate 
          {
            pbPullProgress.Visible = false;
            EnableControls();
            btnPullConfig.Enabled = true;
          }));
        }));
        btnCancelPull.Visible = false;
        btnPullConfig.Enabled = false;
      }
    }

    /// <summary>
    /// Disable general UI controls except buttons
    /// </summary>
    private void DisableControls()
    {
      cbCreateNewSet.Enabled = false;
      cbScriptPerHost.Enabled = false;
      cbAutoSave.Enabled = false;
      clbTargets.Enabled = false;
      CanClose = false;  
    }

    /// <summary>
    /// Enable general UI controls except buttons
    /// </summary>
    private void EnableControls()
    {
      cbCreateNewSet.Enabled = true;
      cbScriptPerHost.Enabled = true;
      cbAutoSave.Enabled = true;
      clbTargets.Enabled = true;
      CanClose = true;
    }

    /// <summary>
    /// Terminates a script specified by its ScriptManager
    /// </summary>
    /// <param name="thisManager"></param>
    private void TerminateScript(SNGScriptManager thisManager)
    {
      bool stopped = false;
      try
      {
        int waitTime = (int)SettingsManager.GetCurrentScriptSettings(this.SNGDataSet).ConnectTimeout.TotalMilliseconds;
        DebugEx.WriteLine(string.Format("Stopping script {0}...", thisManager.GetScriptName()), DebugLevel.Informational);
        stopped = thisManager.StopScript(waitTime);
        thisManager.SetScriptSaved();
        DebugEx.WriteLine(string.Format("Closing form for script {0}...", thisManager.GetScriptName()), DebugLevel.Informational);
        this.Invoke(new MethodInvoker(delegate () { thisManager.CloseForm(); }));
      }
      catch (Exception Ex)
      {
        DebugEx.WriteLine(string.Format("CancelPullOperation : error while closing Form for <{0}> : {1}", thisManager.GetScriptName() + Ex.Message));
      }
      if (!stopped)
      {
        Invoke(new MethodInvoker(delegate
        {
          if (pbPullProgress.Value < pbPullProgress.Maximum) pbPullProgress.Value += 1;
        }));
      }
    }

    private void PullConfig()
    {
      _workInProgressCaption = "Please wait...";
      _workInProgressText = "Generating script...";
			_workInProgress.Run();
      DisableControls();
      try
      {
        if (cbCreateNewSet.Checked)
        {
          DateTime d = DateTime.Now;
          object o = qTA.CloneConfigSet(_configurationSetID, string.Format("{0}_{1}{2}{3}{4}{5}{6}", tbSelConfigSetName.Text, d.Year, d.Month, d.Day, d.Hour, d.Minute, d.Second));
          _configurationSetID = Convert.ToInt32(o);
        }
        SNGDataSet.ScriptSettingRow _scriptSettings = Scriptngo.Common.SettingsManager.GetCurrentScriptSettings(this.SNGDataSet);
        string sepChar = _scriptSettings.CSVSeparator;
        string sExtendedHeader = string.Join(sepChar, Enum.GetNames(typeof(InputFileHeader)));
        sExtendedHeader += "SetTargetID";
        Scriptngo.SNGScriptManager _ScriptManager = ScriptingFormManager.OpenNewScriptingForm();
        if (_ScriptManager != null)
        {
          ScriptManagers.Add(_ScriptManager);
          _ScriptManager.UpdateHeader(sExtendedHeader.Split(sepChar.ToCharArray(), StringSplitOptions.RemoveEmptyEntries));
          _ScriptManager.OnScriptAborted += _ScriptManager_OnScriptAborted;
          _ScriptManager.OnScriptFinished += _ScriptManager_OnScriptFinished;
          string thisLine = string.Empty;
          _ScriptManager.BeginAddingEntries();
          try
          {
            int lastConfigTargetID = -1;
            int targetCount = clbTargets.CheckedItems.Count;
            int targetNum = 1;
            foreach (var target in configDS.SetTargets)
            {
              if (IsTargetSelected(target.ConfigTargetID))
              {
                if (lastConfigTargetID == -1) lastConfigTargetID = target.ConfigTargetID;
                // Open a new ScriptinForm if script needs to be generated per configuration target
                if (target.ConfigTargetID != lastConfigTargetID && cbScriptPerHost.Checked && (targetNum % (numHostPerForm.Value + 1) == 0))
                {
                  if (_ScriptManager != null)
                  {
                    _ScriptManager.EndAddingEntries();
                    _ScriptManager.ExecuteScript(null, false);
                  }
                  _ScriptManager = ScriptingFormManager.OpenNewScriptingForm();
                  if (_ScriptManager == null) break;
                  _ScriptManager.OnScriptAborted += _ScriptManager_OnScriptAborted;
                  _ScriptManager.OnScriptFinished += _ScriptManager_OnScriptFinished;
                  ScriptManagers.Add(_ScriptManager);
                  _ScriptManager.UpdateHeader(sExtendedHeader.Split(sepChar.ToCharArray(), StringSplitOptions.RemoveEmptyEntries));
                  _ScriptManager.BeginAddingEntries();
                  lastConfigTargetID = target.ConfigTargetID;
                }
                int configSetTargetID = cbCreateNewSet.Checked ? (int)qTA.GetConfigSetTargetID(_configurationSetID, target.ConfigTargetID) : target.ConfigSetTargetID;
                thisLine = "1," + string.Concat(target.IsJumpServerIPNull() ? "" : target.JumpServerIP.Trim()) + "," + target.DeviceVendor + "," + target.TargetIP + string.Concat(target.IsPortNull() ? "," : string.Format(":{0},", target.Port)) + "" + "," + target.Protocol + "," + "sh run" + ",yes,,,"
                           + ",,," + configSetTargetID;
                if (!string.IsNullOrEmpty(thisLine))
                {
                  bool added = _ScriptManager.AddEntry(thisLine, false);
                  if (!added)
                  {
                    if (MessageBox.Show("There was an error adding a script line. Do you want to continue ?", "Script generation error", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.No)
                    {
                      break;
                    }
                  }
                }
                targetNum++;
              }
            }
          }
          finally
          {
            if (_ScriptManager != null)
            {
              _ScriptManager.EndAddingEntries();
              _ScriptManager.ExecuteScript(null, false);
            }
          }
        }
      }
      finally
      {
				_workInProgress.Cancel();
        _workInProgressSupportCancellation = false;
        btnPullConfig.Enabled = ScriptManagers.Count == 0;
        lblOperationInProgress.Text = "Pulling configuration...";
        pbPullProgress.Value = 0;
        pbPullProgress.Maximum = ScriptManagers.Count;
        pbPullProgress.Visible = ScriptManagers.Count > 1;
        btnCancelPull.Visible = !btnPullConfig.Enabled;
      }
    }

    private void SaveScriptResults(SNGScriptManager thisManager)
    {
      int defaultColumnCount = Enum.GetNames(typeof(InputFileHeader)).Length - 1;
      bool errorOccurred = false;

      _workInProgress.Caption = "Operation in progress";
      _workInProgress.Text = "Please wait while saving script results...";
			_workInProgress.Run();
      try
      {
        int itemCount = thisManager.GetItems().Count();
        foreach (ScriptListViewItem thisItem in thisManager.GetItems())
        {
          try
          {
            int ConfigSetTargetID = -1;
            if (int.TryParse(thisItem.SubItems[defaultColumnCount].Text, out ConfigSetTargetID))
            {
              // Only save the result if item is selected for execution and result is success !
              if (thisItem.HasChanged & thisItem.State == ScriptLineState.Success)
              {
                string targetConfig = thisItem.SubItems[(int)LVISubItem.CommandResult].Text;
                if (!string.IsNullOrEmpty(targetConfig))
                {
                  string[] configLines = targetConfig.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                  SaveConfiguration(configLines, ConfigSetTargetID);
                }
              }
              else
              {
                if (itemCount > 1)
                {
                  DialogResult dRes = MessageBox.Show(string.Format("Can't save result for <{0}> because command result reported an error. Continue operation ?", thisItem.SubItems[1]), "Can't save result", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                  if (dRes == DialogResult.No) break;
                }
              }
            }
          }
          catch (Exception Ex)
          {
						_workInProgress.Cancel();
            MessageBox.Show(string.Format("Item not saved as an unexpected error occurred : {0}", Ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            errorOccurred = true;
          }
        }
      }
      finally
      {
				_workInProgress.Cancel();
      }
      if (!errorOccurred) thisManager.SetScriptSaved();
    }

    /// <summary>
    /// Saves the passed configuration to database
    /// </summary>
    /// <param name="ConfigurationSetTargetID">If set, configuration lines will be stored/updated for this reference, regardless the currently selected target</param>
    private void SaveConfiguration(string[] configLines, int ConfigurationSetTargetID)
    {
      qTA.DeleteConfiguration(ConfigurationSetTargetID);
      configDS.ConfigLines.Clear();
      foreach (string line in configLines)
      {
        if (line.IndexOf("Building configuration") < 0 & line.IndexOf("Current configuration") < 0)
        {
          ConfigDS.ConfigLinesRow clr = configDS.ConfigLines.NewConfigLinesRow();
          clr.ConfigSetTargetID = ConfigurationSetTargetID;
          clr.ConfigLine = line;
          configDS.ConfigLines.AddConfigLinesRow(clr);
        }
      }
      configLinesTA.Update(configDS);
    }

    private void _ScriptManager_OnScriptFinished(object sender, Common.ScriptEventArgs e)
    {
      DebugEx.WriteLine("ConfigurationManager : OnScriptFinished - " + e.Reason.ToString(), DebugLevel.Informational);
      SNGScriptManager thisManager = null;
      if (sender is ScriptExecutor) thisManager = ScriptingFormManager.GetScriptManager(sender as ScriptExecutor);
      else if (sender is ScriptingForm) thisManager = (sender as ScriptingForm).ScriptManager;
      if (ScriptManagers.Contains(thisManager))
      {
        lock (_lckObject) // locking is required to synchronize potential parallel calls
        {
          ScriptManagers.Remove(thisManager);
          if (e.Reason != ScriptEventReason.UserAborted)
          {
            Invoke(new MethodInvoker(delegate ()
            {
              if (pbPullProgress.Value < pbPullProgress.Maximum) pbPullProgress.Value += 1;
              DialogResult saveConfig = DialogResult.Yes;
              if (cbAutoSave.Checked || (saveConfig = MessageBox.Show(String.Format("Script <{0}> finished. Do you want to auto-save script results to database ?", thisManager.GetScriptName()), "Auto-save", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) == System.Windows.Forms.DialogResult.Yes)
              {
                SaveScriptResults(thisManager);
              }
              if (saveConfig == DialogResult.Yes) thisManager.CloseForm();
              if (ScriptManagers.Count == 0)
              {
                EnableControls();
                btnPullConfig.Enabled = true;
                lblOperationInProgress.Text = "Operation completed";
                RefreshScriptManagers();
              }
              btnCancelPull.Visible = !btnPullConfig.Enabled;
            }));
          }
          else
          {
            Invoke(new MethodInvoker(delegate () { if (!IsDisposed && pbPullProgress.Value < pbPullProgress.Maximum) pbPullProgress.Value += 1; }));
          }
        }
      }

    }

    private void _ScriptManager_OnScriptAborted(object sender, Common.ScriptEventArgs e)
    {
      DebugEx.WriteLine("COnfigurationManager : OnScriptAborted - " + e.Reason, DebugLevel.Informational);
      SNGScriptManager thisManager = null;
      if (sender is ScriptExecutor) thisManager = ScriptingFormManager.GetScriptManager(sender as ScriptExecutor);
      else if (sender is ScriptingForm) thisManager = (sender as ScriptingForm).ScriptManager;
      if (ScriptManagers.Contains(thisManager))
      {
        lock (_lckObject) // locking is required to synchronize potential parallel calls
        {
          Invoke(new MethodInvoker(delegate
          {
            if (pbPullProgress.Value < pbPullProgress.Maximum) pbPullProgress.Value += 1;
            if (ScriptManagers.Count == 0)
            {
              EnableControls();
              btnPullConfig.Enabled = true;
              lblOperationInProgress.Text = "Operation completed";
              RefreshScriptManagers();
            }
            btnCancelPull.Visible = !btnPullConfig.Enabled;
          }));
        }
      }
    }

    /// <summary>
    /// Indicates whether a target is selected for pulling configuration from
    /// </summary>
    /// <param name="ConfigTargetID">The ConfigTargetID of the target to check</param>
    /// <returns></returns>
    private bool IsTargetSelected(int ConfigTargetID)
    {
      bool result = false;
      foreach (var item in clbTargets.CheckedItems)
      {
        if (((ConfigDS.SetTargetsRow)item).ConfigTargetID == ConfigTargetID)
        {
          result = true;
          break;
        }
      }
      return result;
    }

    /// <summary>
    /// Checks all opened script manager forms and updates configuration sets
    /// </summary>
    private void RefreshScriptManagers()
    {
      var configMgrs = from Form thisForm in Application.OpenForms where thisForm is ConfigManager select thisForm as ConfigManager;
      configMgrs.ForEach(c => c.UpdateLists());
    }
    #endregion

    #region Event handlers
    private void btnPullconfig_Click(object sender, EventArgs e)
    {
      Properties.Settings.Default.Save();
      PullConfig();
    }

    private void btnCancelPull_Click(object sender, EventArgs e)
    {
      CancelPullOperation();
    }

    private void ConfigPuller_FormClosing(object sender, FormClosingEventArgs e)
    {
      e.Cancel = !CanClose;
      if (CanClose)
      {
        ShowIcon = false; // An error in .NET Mdi form handling requires thiss
        try
        {
          if (ScriptManagers.Count > 0)
          {
            if (MessageBox.Show(string.Format("There are {0} opened Script Executor window(s) open. If you close Configuration Manager, the script windows will also be closed and running scripts will be terminated. Do you want to proceed ?", ScriptManagers.Count), "Automated scripting in progress", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.Yes)
            {
              foreach (SNGScriptManager thisManager in ScriptManagers)
              {
                thisManager.OnScriptAborted -= this._ScriptManager_OnScriptAborted;
                thisManager.OnScriptFinished -= this._ScriptManager_OnScriptFinished;
                thisManager.StopScript();
                thisManager.SetScriptSaved();
                thisManager.CloseForm(false);
              }
            }
            else e.Cancel = true;
          }
        }
        catch { }
      }
      else MessageBox.Show("Please wait until all operation completes.", "Close not permitted", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
    }

    private void clbTargets_Format(object sender, ListControlConvertEventArgs e)
    {
      if (e.ListItem is ConfigDS.SetTargetsRow) e.Value = ((ConfigDS.SetTargetsRow)e.ListItem).TargetName;
    }

    private void ColoredButtonEnabledChanged(object sender, EventArgs e)
    {
      try
      {
        if (ButtonColors == null) ButtonColors = new Hashtable();
        Button btn = sender as Button;
        if (btn.Enabled)
        {
          btn.BackColor = (System.Drawing.Color)ButtonColors[btn];
        }
        else
        {
          if (!ButtonColors.ContainsKey(btn)) ButtonColors.Add(btn, btn.BackColor);
          btn.BackColor = System.Drawing.Color.DarkGray;
        }
      }
      catch { }
    }

     private void pbPullProgress_VisibleChanged(object sender, EventArgs e)
    {
      lblOperationInProgress.Visible = pbPullProgress.Visible;
    }

    private void cmTargetsSelectAll_Click(object sender, EventArgs e)
    {
      for (int i = 0; i < clbTargets.Items.Count; i++) clbTargets.SetItemChecked(i, true);
    }

    private void cmTargetsClearAll_Click(object sender, EventArgs e)
    {
      for (int i = 0; i < clbTargets.Items.Count; i++) clbTargets.SetItemChecked(i, false);
    }

    private void cmTargetsToggle_Click(object sender, EventArgs e)
    {
      for (int i = 0; i < clbTargets.Items.Count; i++) clbTargets.SetItemChecked(i, !clbTargets.GetItemChecked(i));
    }
    #endregion
  }
}
