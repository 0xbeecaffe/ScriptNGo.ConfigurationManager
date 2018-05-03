/* #########################################################################*/
/* #                                                                       #*/
/* #  This file is part of ConfigurationManager project, which is written  #*/
/* #  as a PGT plug-in to help configuration management of Cisco devices.  #*/
/* #                                                                       #*/
/* #  You may not use this file except in compliance with the license.     #*/
/* #                                                                       #*/
/* #  Copyright Laszlo Frank (c) 2014-2017                                 #*/
/* #                                                                       #*/
/* #########################################################################*/

using PGT.Common;
using System;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Windows.Forms;

namespace PGT.ConfigurationManager
{
  public partial class Deployer : Form
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
    #endregion

    #region Initialization
    public Deployer(int ConfigurationSetID)
    {
      InitializeComponent();
			_workInProgress = new WorkInProgress(_workInProgressCaption, _workInProgressText);
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
    private void Deployer_Load(object sender, EventArgs e)
    {
      deployTA.Fill(configDS.Deploy, _configurationSetID);
      if (configDS.Deploy.Rows.Count > 0)
      {
        tbSelConfigSetName.Text = ((ConfigDS.DeployRow)configDS.Deploy.Rows[0]).ConfigSetName;
        setTargetsTA.FillTargetsInSet(configDS.SetTargets, _configurationSetID);
        foreach (var item in configDS.SetTargets)
        {
          clbTargets.Items.Add(item, true);
        }
      }
      else
      {
        btnDeploySet.Enabled = false;
        MessageBox.Show("There is no configuration to deploy in this Set", "Empty configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
        DialogResult = System.Windows.Forms.DialogResult.Cancel;
      }
    }
    #endregion

    #region Private members
    private void Deploy()
    {
      _workInProgress.Caption = "Please wait...";
      _workInProgress.Text = "Generating script...";
      _workInProgress.Run();
      try
      {
        PGTDataSet.ScriptSettingRow _scriptSettings = PGT.Common.SettingsManager.GetCurrentScriptSettings();
        string sepChar = _scriptSettings.CSVSeparator;
        string sExtendedHeader = PGT.Common.Helper.ArrayToString(Enum.GetNames(typeof(InputFileHeader)), sepChar);
        sExtendedHeader += "ConfigLineID";
        PGT.PGTScriptManager _ScriptManager = ScriptingFormManager.OpenNewScriptingForm();
        if (_ScriptManager != null)
        {
          string thisLine = string.Empty;
          _ScriptManager.SetSavePrompt(false);
          _ScriptManager.BeginAddingEntries();
          try
          {
            int lastConfigTargetID = (configDS.Deploy.Rows[0] as ConfigDS.DeployRow).ConfigTargetID;
            int targetCount = clbTargets.CheckedItems.Count;
            int targetNum = 0;
            foreach (var configLine in configDS.Deploy)
            {
              if (IsTargetSelected(configLine.ConfigTargetID))
              {
                if (configLine.ConfigTargetID != lastConfigTargetID) targetNum++;
                // Open a new ScriptinForm if script needs to be generated per configuration target
                if (configLine.ConfigTargetID != lastConfigTargetID && cbScriptPerHost.Checked && (targetNum > 0 &&  targetNum % numHostPerForm.Value == 0))
                {
                  #region Open a new Scripting Form
                  if (_ScriptManager != null)
                  {
                    _ScriptManager.EndAddingEntries();
                    if (cbStartScripts.Checked) _ScriptManager.ExecuteScript(null, false);
                  }
                  _ScriptManager = ScriptingFormManager.OpenNewScriptingForm();
                  if (_ScriptManager == null) break;
                  _ScriptManager.SetSavePrompt(false);
                  _ScriptManager.BeginAddingEntries();
                  lastConfigTargetID = configLine.ConfigTargetID;
                  #endregion
                }
                thisLine = "1," + string.Concat(configLine.IsJumpServerIPNull() ? "" : configLine.JumpServerIP.Trim()) + "," + configLine.DeviceVendor + "," + configLine.TargetIP + string.Concat(configLine.IsPortNull() ? "," : string.Format(":{0},", configLine.Port)) + "" + "," + configLine.Protocol + "," + configLine.ConfigLine + ",yes,,,"
                           + ",,,," + configLine.ConfigLineID;
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
              }
              if (configLine.ConfigTargetID != lastConfigTargetID) lastConfigTargetID = configLine.ConfigTargetID;
            }
          }
          finally
          {
            if (_ScriptManager != null)
            {
              _ScriptManager.EndAddingEntries();
              if (cbStartScripts.Checked) _ScriptManager.ExecuteScript(null, false);
            }
          }
        }
      }
      finally
      {
				_workInProgress.Cancel();
        _workInProgressSupportCancellation = false;
        DialogResult = DialogResult.OK;
      }
    }

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

    #endregion

    #region Event handlers
    private void btnDeploySet_Click(object sender, EventArgs e)
    {
      Hide();
      Deploy();
      DialogResult = System.Windows.Forms.DialogResult.OK;
      Close();
    }

    private void clbTargets_Format(object sender, ListControlConvertEventArgs e)
    {
      if (e.ListItem is ConfigDS.SetTargetsRow) e.Value = ((ConfigDS.SetTargetsRow)e.ListItem).TargetName;
    }

    private void Deployer_FormClosed(object sender, FormClosedEventArgs e)
    {
      Properties.Settings.Default.Save();
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
