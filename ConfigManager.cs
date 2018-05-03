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

using MoreLinq;
using PGT.Common;
using PGT.ExtensionInterfaces;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace PGT.ConfigurationManager
{
  public partial class ConfigManager : Form
  {
    #region Fields
    private WorkInProgress _workInProgress = new WorkInProgress("Work in progress", "Please be patient...");
    private SqlCommand _workInProgressSqlCommandToCancel = null;
    /// <summary>
    /// This indicates whether to display a cancel button in the WorkAnimation window
    /// </summary>
    private bool _workInProgressSupportCancellation = false;
    /// <summary>
    /// This is set to true when user clicks the cancel button in the WorkAnimation dialoge
    /// </summary>
    private bool _workInProgress_CancelPressed = false;
    /// <summary>
    /// Indicates whether the configuration text in tbConfiguration has changed since loaded frmom database
    /// </summary>
    private bool targetConfigurationChanged;
    /// <summary>
    /// The ConfigurationSetTargetID of the displayed configuration in tbConfigurationLines. Set when loaded.
    /// </summary>
    private int loadedConfigSetTargetID = -1;
    /// <summary>
    /// Used to remember Button back colors
    /// </summary>
    private Hashtable ButtonColors = new Hashtable();

    #endregion

    #region Initialization
    public ConfigManager()
    {
      InitializeComponent();
      SetControlBackGround(this);
    }
    private void ConfigManager_Load(object sender, EventArgs e)
    {
      _workInProgress.Caption = "Connecting to database";
      _workInProgress.Text = "Now connecting, please wait...";
      _workInProgress.Run();
      try
      {
        try
        {
          tsslSQLServer.Text = Properties.Settings.Default.SQLServerName + " : " + Properties.Settings.Default.DatabaseName;
          UpdateConfigTargetList();
          UpdateConfigSetList();
          UpdateTargetGroupFilterList();
        }
        catch (System.Data.SqlClient.SqlException Ex)
        {
          _workInProgress.Cancel();
          if (MessageBox.Show(string.Format("An unexpected database error occurred : {0} \r\n Do you want to reconfigure SQL connection parameters ? ", Ex.Message), "Database connection error", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
          {
            (new SqlConnectionEditor(_workInProgress)).ShowDialog();
          }
        }
        catch (Exception Ex)
        {
          _workInProgress.Cancel();
          MessageBox.Show(string.Format("An unexpected database error occurred : {0}", Ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        this.Text += string.Format(" - V{0}", Assembly.GetExecutingAssembly().GetName().Version.ToString());
      }
      finally
      {
        _workInProgress.Cancel();
      }
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

    #endregion

    #region General stuff
    public void UpdateLists()
    {
      UpdateConfigTargetList();
      UpdateConfigSetList();
      UpdateSetTargets();
    }

    #endregion

    #region Manage Config Targets
    /// <summary>
    /// Adds a new configuration target
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void AddConfigTarget()
    {
      ConfigTarget CT = new ConfigTarget();
      if (CT.ShowDialog() == DialogResult.OK)
      {
        UpdateConfigTargetList();
        UpdateSetTargets();
        UpdateTargetGroupFilterList();
      }
    }

    /// <summary>
    /// Open terminal connection to target currently selected
    /// </summary>
    /// <param name="TargetID"></param>
    private void ConnectToTarget()
    {
      if (lvTargets.SelectedItems.Count == 1)
      {
        int TargetID = (int)lvTargets.SelectedItems[0].Tag;
        TerminalWindow term;
        string host = string.Empty;
        try
        {
          ConfigDS.ConfigTargetsRow[] targets = configDS.ConfigTargets.Select(string.Format("ConfigTargetID = {0}", TargetID)) as ConfigDS.ConfigTargetsRow[];
          if (targets.Length > 0)
          {
            ConfigDS.ConfigTargetsRow selectedTarget = targets[0];
            host = selectedTarget.TargetIP;
            PGTDataSet.ScriptSettingRow _localScriptSettings = PGT.Common.SettingsManager.GetCurrentScriptSettings();
            ConnectionParameters CP = new ConnectionParameters
            {
              DeviceIP = selectedTarget.TargetIP,
              Protocol = (ConnectionProtocol)Enum.Parse(typeof(ConnectionProtocol), selectedTarget.Protocol, true),
              Port = selectedTarget.IsPortNull() ? 0 : selectedTarget.Port,
              DeviceVendor = selectedTarget.DeviceVendor,
              JumpServer = selectedTarget.JumpServerIP.Trim(),
              LogonUserName = _localScriptSettings.ScriptingUserName,
              EnablePassword = _localScriptSettings.DeviceEnablePassword,
              LogonPassword = _localScriptSettings.ScriptingPassword,
              AuthType = (PGTTermAuthType)Enum.Parse(typeof(PGTTermAuthType), _localScriptSettings.TerminalAuthType),
              LineFeedRule = (LineFeedRule)Enum.Parse(typeof(LineFeedRule), _localScriptSettings.TerminalLineFeedRule),
              EncodingType = (EncodingType)Enum.Parse(typeof(EncodingType), _localScriptSettings.TerminalEncoding),
              TerminalType = (TerminalType)Enum.Parse(typeof(TerminalType), _localScriptSettings.TerminalType),
              NewLine = (NewLine)Enum.Parse(typeof(NewLine), _localScriptSettings.TerminalTransmitNL)
            };
            var t = from Form form in Application.OpenForms where form is TerminalWindow select form;
            if (t.Count() > 0) term = (TerminalWindow)t.ElementAt(0);
            else term = new TerminalWindow(Color.FromArgb(_localScriptSettings.TerminalForeColor), Color.FromArgb(_localScriptSettings.TerminalBackColor));
            term.MdiParent = this.MdiParent;
            term.Show();
            term.BringToFront();
            term.ConnectDisconnectTask(ConnectionTaskAction.Connect, true, CP);
          }
          else MessageBox.Show("Unable to open a terminal because the script target was not found.", "Cannot open terminal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        catch (Exception Ex)
        {
          MessageBox.Show(string.Format("An error occurred while opening connection to {0}. The error was : {1}", host, Ex.Message), "Connection error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
      }
    }

    /// <summary>
    /// Edit an existing target
    /// </summary>
    /// <param name="ConfigTargetID">The ConfigTargetID of the item to edit</param>
    private void EditConfigTarget()
    {
      if (lvTargets.SelectedItems.Count > 0)
      {
        ListViewItem lvi = lvTargets.SelectedItems[0];
        ConfigTarget CT = new ConfigTarget((int)lvi.Tag);
        if (CT.ShowDialog() == DialogResult.OK)
        {
          UpdateConfigTargetList();
          UpdateSetTargets();
          UpdateTargetGroupFilterList();
        }
      }
    }

    /// <summary>
    /// Deletes all selected config target
    /// </summary>
    private void DeleteConfigTargets()
    {
      if (lvTargets.SelectedItems.Count > 0)
      {
        if (MessageBox.Show("Are you sure you want to delete the selected cofiguration target(s) ?", "Deletion warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
        {
          foreach (ListViewItem lvi in lvTargets.SelectedItems) DeleteConfigTarget((int)lvi.Tag);
        }
      }
    }

    /// <summary>
    /// Delete the given ConfigTarget
    /// </summary>
    /// <param name="ConfigTargetID">The ConfigTargetID of the item to edit</param>
    private void DeleteConfigTarget(int ConfigTargetID)
    {
      configTargetsTA.Delete(ConfigTargetID);
      UpdateConfigTargetList();
      UpdateSetTargets();
      UpdateTargetGroupFilterList();
    }

    /// <summary>
    /// Import targets from CSV file
    /// </summary>
    private void ImportTargets()
    {
      string imputFileName = string.Empty;
      PGTDataSet.ScriptSettingRow scriptSettings = SettingsManager.GetCurrentScriptSettings();
      OpenFileDialog openFileDialog = new OpenFileDialog();
      openFileDialog.Filter = "CSV files|*.csv|All files|*.*";
      if (openFileDialog.ShowDialog() == DialogResult.OK)
      {
        _workInProgress.Caption = "Please wait";
        _workInProgress.Text = "Importing targets...";
        bool importOK = true;
        int dupCount = 0; // count of items marked ignored as duplicate ip detected
        int errCount = 0; // count of items not elegible for import due to some invalid data
        string[] allLines;
        try
        {
          try
          {
            imputFileName = openFileDialog.FileName;
            allLines = File.ReadAllLines(imputFileName);
            if (allLines.Length > 0)
            {
              string thisLine = allLines[0];
              string[] sections = thisLine.Split(scriptSettings.CSVSeparator.ToCharArray());
              string doNotImportColumnText = "< Do not import >";
              CSVHeaderMapper mapper = new CSVHeaderMapper(sections, doNotImportColumnText);
              if (mapper.ShowDialog() == System.Windows.Forms.DialogResult.OK)
              {
                if (mapper.GetTargetIPColumnIndex != -1)
                {
                  _workInProgress.Run();
                  bool wasError = false;
                  for (int i = 1; i < allLines.Length; i++)
                  {
                    try
                    {
                      thisLine = allLines[i];
                      sections = thisLine.Split(scriptSettings.CSVSeparator.ToCharArray());
                      string targetName = "";
                      string targetGroup = "default";
                      string targetIP = "";
                      string deviceVendor = "";
                      string jumpServerIP = "";
                      string protocol = "SSH2";
                      int? port = null;
                      string note = "";

                      // Target IP
                      targetIP = sections[mapper.GetTargetIPColumnIndex].Trim().Truncate(50);
                      if (targetIP.IndexOf(":") > 0)
                      {
                        string[] targetIPPort = targetIP.Split(':');
                        targetIP = targetIPPort[0];
                        int p = -1;
                        if (int.TryParse(targetIPPort[1], out p)) port = p;
                      }
                      // Target name
                      if (mapper.GetTargetNameColumnIndex >= 0) targetName = sections[mapper.GetTargetNameColumnIndex].Trim().Truncate(100);
                      else if (mapper.GetTargetNameColumnIndex == -1) targetName = mapper.GetTargetNameText.Truncate(300);
                      // Target group name
                      if (mapper.GetTargetGroupNameColumnIndex >= 0) targetGroup = sections[mapper.GetTargetGroupNameColumnIndex].Trim().Truncate(100);
                      else if (mapper.GetTargetGroupNameColumnIndex == -1) targetGroup = mapper.GetTargeGroupNameText.Truncate(300);
                      // Jump server ip
                      if (mapper.GetJumpServerIPColumnIndex != -2) jumpServerIP = sections[mapper.GetJumpServerIPColumnIndex].Trim().Truncate(15);
                      // Note
                      if (mapper.GetNoteColumnIndex >= 0) note = sections[mapper.GetNoteColumnIndex].Trim().Truncate(500);
                      else if (mapper.GetNoteColumnIndex == -1) note = mapper.GetNoteText;
                      // Protocol
                      if (mapper.GetProtocolColumnIndex != -2) protocol = sections[mapper.GetProtocolColumnIndex].Trim().Truncate(15);
                      // Vendor
                      if (mapper.GetVendorColumnIndex > -1) deviceVendor = sections[mapper.GetVendorColumnIndex].Trim().Truncate(50);
                      else deviceVendor = mapper.GetVendorText;

                      if (!string.IsNullOrEmpty(targetIP) && targetIP.IsValidIP() && !string.IsNullOrEmpty(targetName))
                      {
                        int? c = (int?)qTA.GetTargetCount(targetGroup, targetName, port);
                        if (c > 0) dupCount++;
                        else this.configTargetsTA.Insert(targetName, targetIP, deviceVendor, jumpServerIP, protocol, port, note, targetGroup);
                      }
                      else
                      {
                        errCount++;
                        wasError = true;
                      }
                      _workInProgress.Text = string.Format("Importing items...{0}% done", i * 100 / allLines.Length);
                    }
                    catch
                    {
                      wasError = true;
                    }
                  }
                  try
                  {
                    if (!wasError || MessageBox.Show("Not all input lines could be parsed. Do you want to submit partial import into database ?", "Input errors", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.Yes)
                    {
                      _workInProgress.Text = "Submitting items to database...";
                      configTargetsTA.Update(this.configDS);
                    }
                    else importOK = false;
                  }
                  catch (ConstraintException)
                  {
                    importOK = false;
                    _workInProgress.Cancel();
                    string errorText = this.configDS.Tables["ConfigTargets"].Rows[0].RowError;
                    MessageBox.Show(string.Format("There is a constraint problem here : {0}", errorText), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                  }
                  catch (Exception Ex)
                  {
                    importOK = false;
                    _workInProgress.Cancel();
                    MessageBox.Show(string.Format("An unexpected error occurred : {0}", Ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                  }
                  _workInProgress.Cancel();
                  if (importOK)
                  {
                    if (!wasError)
                    {
                      if (dupCount == 0) MessageBox.Show(string.Format("{0} items processed successfully.", allLines.Length), "Import success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                      else MessageBox.Show(string.Format("{0} items processed successfully : #Duplicate IP :{1} ", allLines.Length, dupCount), "Success, but duplicate IPs detected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else MessageBox.Show(string.Format("Some lines could not be imported due to invalid data. #Imported : {0}, #Duplicate IP :{1} #Skipped : {2}", allLines.Length, dupCount, errCount), "Success with errors", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                  }
                  else MessageBox.Show("The import failed, items were not added to Worklist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else MessageBox.Show("Device IP column must be specified for input. Cannot import items.", "Selection error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
              }
            }
          }
          catch (Exception Ex)
          {
            _workInProgress.Cancel();
            MessageBox.Show(string.Format("Unfortunately an error occurred while importing : {0}", Ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
          }
        }
        finally
        {
          _workInProgress.Cancel();
          UpdateConfigTargetList();
          UpdateSetTargets();
          UpdateTargetGroupFilterList();
        }
      }
    }

    /// <summary>
    /// Updates the list of configuration targets included/excluded in a set 
    /// </summary>
    private void UpdateSetTargets()
    {
      lvTargetsInSet.Items.Clear();
      lvTargetsNotInSet.Items.Clear();
      if (lvSets.SelectedItems.Count > 0)
      {
        int curSetID = (int)lvSets.SelectedItems[0].Tag;
        ConfigDS.SetTargetsDataTable targets = new ConfigDS.SetTargetsDataTable();
        // list targets included current set
        setTargetsTA.FillTargetsInSet(targets, curSetID);
        lvTargetsInSet.BeginUpdate();
        try
        {
          foreach (var item in targets)
          {
            ListViewItem lvi = new ListViewItem(new string[] { item.TargetGroup, item.TargetName });
            lvi.Tag = item.ConfigTargetID;
            lvTargetsInSet.Items.Add(lvi);
          }
        }
        finally
        {
          lvTargetsInSet.EndUpdate();
          lvTargetsInSet.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
          lvTargetsInSet.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }
        if (lvTargetsInSet.Items.Count > 0) lvTargetsInSet.Items[0].Selected = true;
        // list targets not in set, but matchin the specified group filter
        setTargetsTA.FillTargetsNotInSet(targets, curSetID);
        lvTargetsNotInSet.BeginUpdate();
        try
        {
          foreach (var item in targets)
          {
            if (item.TargetGroup == cbxTargetGroupFilter.Text)
            {
              ListViewItem lvi = lvTargetsNotInSet.Items.Add(item.TargetName);
              lvi.Tag = item.ConfigTargetID;
            }
          }
        }
        finally
        {
          lvTargetsNotInSet.EndUpdate();
          lvTargetsNotInSet.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
          lvTargetsNotInSet.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }
        if (lvTargetsNotInSet.Items.Count > 0) lvTargetsNotInSet.Items[0].Selected = true;
      }
      RefreshTargetList();
    }

    /// <summary>
    /// Refreshes the ConfigTargets listview from database
    /// </summary>
    private void UpdateConfigTargetList()
    {
      configTargetsTA.Fill(this.configDS.ConfigTargets);
      lvTargets.BeginUpdate();
      try
      {
        lvTargets.Items.Clear();
        lvTargets.ListViewItemSorter = null;
        foreach (var item in this.configDS.ConfigTargets)
        {
          ListViewItem lvi = new ListViewItem();
          lvi.Text = item.TargetGroup;
          lvi.SubItems.Add(item.TargetName);
          lvi.SubItems.Add(item.TargetIP);
          lvi.SubItems.Add(item.DeviceVendor);
          lvi.SubItems.Add(item.IsJumpServerIPNull() ? "" : item.JumpServerIP);
          lvi.SubItems.Add(item.Protocol);
          lvi.SubItems.Add(item.IsPortNull() ? "" : item.Port.ToString());
          lvi.SubItems.Add(item.IsNoteNull() ? "" : item.Note);
          lvi.Tag = item.ConfigTargetID;
          lvTargets.Items.Add(lvi);
        }
        lvTargets.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        lvTargets.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
      }
      finally
      {
        lvTargets.EndUpdate();
      }
    }

    /// <summary>
    /// Refresh the list of config target groups
    /// </summary>
    private void UpdateTargetGroupFilterList()
    {
      string curTargetGroup = cbxTargetGroupFilter.Text;
      var targetGroups = (from target in this.configDS.ConfigTargets select target.TargetGroup).DistinctBy(t => t);
      cbxTargetGroupFilter.DataSource = targetGroups.ToList();
      cbxTargetGroupFilter.Text = curTargetGroup;
    }

    #endregion

    #region Manage Config Sets
    /// <summary>
    /// Refreshes both the ConfigSets listview and the ConfigSets combobox list from database
    /// </summary>
    private void UpdateConfigSetList()
    {
      configSetsTA.Fill(this.configDS.ConfigSets);
      lvSets.BeginUpdate();
      try
      {
        lvSets.Items.Clear();
        lvSets.ListViewItemSorter = null;
        foreach (var item in this.configDS.ConfigSets)
        {
          ListViewItem lvi = new ListViewItem();
          lvi.Text = item.ConfigSetName;
          lvi.SubItems.Add(item.IsNoteNull() ? "" : item.Note);
          lvi.Tag = item.ConfigSetID;
          lvSets.Items.Add(lvi);
        }
        cbxConfigSets.DataSource = configDS.ConfigSets.ToList();
        lvSets.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        lvSets.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        if (lvSets.Items.Count > 0) lvSets.Items[0].Selected = true;
      }
      finally
      {
        lvSets.EndUpdate();
      }
      UpdateSetTargets();
    }

    /// <summary>
    /// Create a new Configuration Set
    /// </summary>
    private void CreateConfigSet()
    {
      ConfigSet CS = new ConfigSet();
      if (CS.ShowDialog() == DialogResult.OK) UpdateConfigSetList();
    }

    /// <summary>
    /// Opens an existing Configuration Set to be edited
    /// </summary>
    private void EditConfigSet(int ConfigSetID)
    {
      ConfigSet CS = new ConfigSet(ConfigSetID);
      if (CS.ShowDialog() == DialogResult.OK) UpdateConfigSetList();
    }

    /// <summary>
    /// Delete an existing Configuration Set
    /// </summary>
    /// <param name="ConfigSetID"></param>
    private void DeleteConfigSet(int ConfigSetID)
    {
      if (MessageBox.Show("Are you sure you want to delete the selected cofiguration set ? All configurations, specific for this set will also be deleted !", "Data loss warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
      {
        configSetsTA.Delete(ConfigSetID);
        UpdateConfigSetList();
      }
    }

    /// <summary>
    /// Refreshes the selectable configuration target list depending on the selected configuration set
    /// </summary>
    private void RefreshTargetList()
    {
      if (cbxConfigSets.SelectedItem != null)
      {
        ConfigDS.SetTargetsDataTable setTargets = new ConfigDS.SetTargetsDataTable();
        int selSetID = ((ConfigDS.ConfigSetsRow)cbxConfigSets.SelectedItem).ConfigSetID;
        setTargetsTA.FillTargetsInSet(setTargets, selSetID);
        cbxConfigSetTargets.DataSource = setTargets.ToList();
        ShowConfiguration();
      }
    }

    private void AddTargetToSet(int ConfigTargetID, int ConfigSetID)
    {
      qTA.AddTargetToSet(ConfigSetID, ConfigTargetID);
    }

    private void RemoveTargetFromSet(int ConfigTargetID, int ConfigSetID)
    {
      if (MessageBox.Show("If you remove a target ftom a set, its associated configuration will also be deleted ? Are you sure you want to remove this target !", "Data loss warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
      {
        qTA.RemoveTargetFromSet(ConfigSetID, ConfigTargetID);
      }
    }

    #endregion

    #region Manage Configuration Lines
    /// <summary>
    /// Displays configuration for the currently selected configuration set target
    /// </summary>
    private void ShowConfiguration()
    {
      if (targetConfigurationChanged && MessageBox.Show("Configuration has changed. Do you want to save it ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
      {
        SaveConfigurationToDatabase(loadedConfigSetTargetID);
      }
      loadedConfigSetTargetID = -1;
      tbConfigurationLines.Text = "";
      if (cbxConfigSetTargets.SelectedItem != null)
      {
        int selConfigSetTargetID = ((ConfigDS.SetTargetsRow)cbxConfigSetTargets.SelectedItem).ConfigSetTargetID;
        configLinesTA.FillByConfigSetTargetID(this.configDS.ConfigLines, selConfigSetTargetID);
        var lines = from l in this.configDS.ConfigLines select l.ConfigLine;
        tbConfigurationLines.Lines = lines.ToArray();
        loadedConfigSetTargetID = selConfigSetTargetID;
      }
      targetConfigurationChanged = false;
    }

    /// <summary>
    /// Saves the currently displayed configuration to database
    /// </summary>
    /// <param name="ConfigurationSetTargetID">If set, configuration lines will be stored/updated for this reference, regardless the currently selected target</param>
    private void SaveConfigurationToDatabase(int ConfigurationSetTargetID = -1)
    {
      if (cbxConfigSetTargets.SelectedItem != null || ConfigurationSetTargetID != -1)
      {
        int selConfigSetTargetID = ConfigurationSetTargetID != -1 ? ConfigurationSetTargetID : ((ConfigDS.SetTargetsRow)cbxConfigSetTargets.SelectedItem).ConfigSetTargetID;
        qTA.DeleteConfiguration(selConfigSetTargetID);
        configDS.ConfigLines.Clear();
        foreach (string line in tbConfigurationLines.Lines)
        {
          ConfigDS.ConfigLinesRow clr = configDS.ConfigLines.NewConfigLinesRow();
          clr.ConfigSetTargetID = selConfigSetTargetID;
          clr.ConfigLine = line;
          configDS.ConfigLines.AddConfigLinesRow(clr);
        }
        configLinesTA.Update(configDS);
        targetConfigurationChanged = false;
      }
    }

    private void LoadConfigurationFromFile(string FileName = "")
    {
      try
      {
        openFileDialog.Filter = "TXT files|*.txt|All files|*.*";
        if (FileName != "" || openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        {
          if ((tbConfigurationLines.Text.Length == 0 & !targetConfigurationChanged) || MessageBox.Show("Overwrite configuration from file ?", "Open file", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
          {
            tbConfigurationLines.Text = "";
            tbConfigurationLines.Lines = File.ReadAllLines(FileName != "" ? FileName : openFileDialog.FileName);
            DebugEx.WriteLine("ConfigManager read configuration from file " + FileName, DebugLevel.Informational);
          }
        }
      }
      catch (Exception Ex)
      {
        MessageBox.Show("Unfortunately an error occurred : " + Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void SaveConfigurationToFile()
    {
      saveFileDialog.Filter = "TXT files|*.txt|All files|*.*";
      if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
      {
        File.WriteAllLines(saveFileDialog.FileName, tbConfigurationLines.Lines);
      }
    }

    /// <summary>
    /// Copy the current configuration of a target to other targets
    /// </summary>
    private void CopyTargetConfiguration()
    {
      int selSetID = ((ConfigDS.ConfigSetsRow)cbxConfigSets.SelectedItem).ConfigSetID;
      int selConfigSetTargetID = ((ConfigDS.SetTargetsRow)cbxConfigSetTargets.SelectedItem).ConfigSetTargetID;
      CopyConfigLines ccl = new CopyConfigLines(selSetID, selConfigSetTargetID);
      if (ccl.ShowDialog(this) == DialogResult.OK)
      {

      }
    }
    #endregion

    #region Event handlers
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

    private void DrawGradientBackground(object sender, PaintEventArgs e)
    {
      Rectangle rect = (sender as Control).ClientRectangle;
      using (Brush br = new LinearGradientBrush(rect, System.Drawing.Color.White, (sender as Control).BackColor, LinearGradientMode.Vertical))
      {
        e.Graphics.FillRectangle(br, rect);
      }
    }

    private void btnAddTarget_Click(object sender, EventArgs e)
    {
      AddConfigTarget();
    }

    private void btnDeleteTarget_Click(object sender, EventArgs e)
    {
      DeleteConfigTargets();
    }

    private void btnEditTarget_Click(object sender, EventArgs e)
    {
      EditConfigTarget();
    }

    private void lvTargets_DoubleClick(object sender, EventArgs e)
    {
      if (Control.ModifierKeys == Keys.Alt) ConnectToTarget();
      else EditConfigTarget();
    }

    private void lvSets_MouseDoubleClick(object sender, MouseEventArgs e)
    {
      if (lvSets.SelectedItems.Count > 0)
      {
        ListViewItem lvi = lvSets.SelectedItems[0];
        if (lvi != null) EditConfigSet((int)lvi.Tag);
      }
    }

    private void btnCreateSet_Click(object sender, EventArgs e)
    {
      CreateConfigSet();
    }

    private void btnDeleteSet_Click(object sender, EventArgs e)
    {
      if (lvSets.SelectedItems.Count > 0)
      {
        ListViewItem lvi = lvSets.SelectedItems[0];
        if (lvi != null) DeleteConfigSet((int)lvi.Tag);
      }
    }

    private void btnEditSet_Click(object sender, EventArgs e)
    {
      if (lvSets.SelectedItems.Count > 0)
      {
        ListViewItem lvi = lvSets.SelectedItems[0];
        if (lvi != null) EditConfigSet((int)lvi.Tag);
      }
    }

    private void lvSets_SelectedIndexChanged(object sender, EventArgs e)
    {
      UpdateSetTargets();
    }

    private void btnAddSetTarget_Click(object sender, EventArgs e)
    {
      if (lvSets.SelectedItems.Count > 0 & lvTargetsNotInSet.SelectedItems.Count > 0)
      {
        ListViewItem targetLVI = lvTargetsNotInSet.SelectedItems[0];
        ListViewItem setLVI = lvSets.SelectedItems[0];
        AddTargetToSet((int)targetLVI.Tag, (int)setLVI.Tag);
        UpdateSetTargets();
      }
    }

    private void btnRemoveSetTarget_Click(object sender, EventArgs e)
    {
      if (lvSets.SelectedItems.Count > 0 & lvTargetsInSet.SelectedItems.Count > 0)
      {
        ListViewItem targetLVI = lvTargetsInSet.SelectedItems[0];
        ListViewItem setLVI = lvSets.SelectedItems[0];
        RemoveTargetFromSet((int)targetLVI.Tag, (int)setLVI.Tag);
        UpdateSetTargets();
      }
    }

    private void cbxConfigSets_Format(object sender, ListControlConvertEventArgs e)
    {
      e.Value = ((ConfigDS.ConfigSetsRow)e.ListItem).ConfigSetName;
    }

    private void cbxConfigSetTargets_Format(object sender, ListControlConvertEventArgs e)
    {
      e.Value = ((ConfigDS.SetTargetsRow)e.ListItem).TargetName;
    }

    private void cbxConfigSets_DropDownClosed(object sender, EventArgs e)
    {
      RefreshTargetList();
    }

    private void cbxConfigSetTargets_DropDownClosed(object sender, EventArgs e)
    {
      ShowConfiguration();
    }

    private void btnSaveConfiguration_Click(object sender, EventArgs e)
    {
      SaveConfigurationToDatabase();
    }

    private void tbConfigurationLines_TextChanged(object sender, EventArgs e)
    {
      targetConfigurationChanged = true;
    }

    private void btnDeploySet_Click(object sender, EventArgs e)
    {
      if (lvSets.SelectedItems.Count > 0)
      {
        ListViewItem setLVI = lvSets.SelectedItems[0];
        Deployer d = new Deployer((int)setLVI.Tag);
        d.ShowDialog(this);
      }
    }

    private void btnPullConfig_Click(object sender, EventArgs e)
    {
      if (lvSets.SelectedItems.Count > 0)
      {
        ListViewItem setLVI = lvSets.SelectedItems[0];
        ConfigPuller cp = new ConfigPuller((int)setLVI.Tag);
        cp.MdiParent = this.MdiParent;
        cp.Show();
      }
    }

    private void tbConfigurationLines_DragDrop(object sender, DragEventArgs e)
    {
      string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
      if (files.Length > 0)
      {
        LoadConfigurationFromFile(files[0]);
      }
    }

    private void tbConfigurationLines_DragEnter(object sender, DragEventArgs e)
    {
      if (e.Data.GetDataPresent(DataFormats.FileDrop))
      {
        e.Effect = DragDropEffects.Copy;
      }
    }

    private void tbConfigurationLines_DragOver(object sender, DragEventArgs e)
    {
      if (e.Data.GetDataPresent(DataFormats.FileDrop))
      {
        e.Effect = DragDropEffects.Copy;
      }
    }

    private void btnLoadFromFile_Click(object sender, EventArgs e)
    {
      LoadConfigurationFromFile();
    }

    private void btnSaveToFile_Click(object sender, EventArgs e)
    {
      SaveConfigurationToFile();
    }

    private void btnImportTargets_Click(object sender, EventArgs e)
    {
      ImportTargets();
    }

    private void btnApplyToOtherTargets_Click(object sender, EventArgs e)
    {
      CopyTargetConfiguration();
    }

    private void ConfigManager_FormClosing(object sender, FormClosingEventArgs e)
    {
      ShowIcon = false; // An error in .NET Mdi form handling requires this
    }

    private void btnConnectToTarget_Click(object sender, EventArgs e)
    {
      ConnectToTarget();
    }

    private void lvTargets_SelectedIndexChanged(object sender, EventArgs e)
    {
      btnConnectToTarget.Enabled = lvTargets.SelectedItems.Count == 1;
    }

    private void cmTargetsConnect_Click(object sender, EventArgs e)
    {
      ConnectToTarget();
    }

    private void cmTargetsAddNew_Click(object sender, EventArgs e)
    {
      AddConfigTarget();
    }

    private void cmTargetsEdit_Click(object sender, EventArgs e)
    {
      EditConfigTarget();
    }

    private void cmTargetsDelete_Click(object sender, EventArgs e)
    {
      DeleteConfigTargets();
    }

    private void cmTargets_Opening(object sender, CancelEventArgs e)
    {
      cmTargetsConnect.Enabled = lvTargets.SelectedItems.Count == 1;
      cmTargetsEdit.Enabled = lvTargets.SelectedItems.Count == 1;
      cmTargetsAddNew.Enabled = true;
      cmTargetsDelete.Enabled = lvTargets.SelectedItems.Count > 0;
    }

    private void tpConfigurations_Enter(object sender, EventArgs e)
    {
      if (lvSets.SelectedItems.Count == 1)
      {
        cbxConfigSets.Text = lvSets.SelectedItems[0].Text;
        RefreshTargetList();
      }
    }

    private void cbxTargetGroupFilter_DropDownClosed(object sender, EventArgs e)
    {
      UpdateSetTargets();
    }

    private void lvTargets_ColumnClick(object sender, ColumnClickEventArgs e)
    {
      if (lvTargets.ListViewItemSorter == null) lvTargets.ListViewItemSorter = new ListViewItemComparer(new int[] { 2, 4 });
      ListViewItemComparer comparer = (ListViewItemComparer)lvTargets.ListViewItemSorter;
      if (comparer.sortByColumnID == e.Column) comparer.ChangeSortOrder();
      else comparer.sortByColumnID = e.Column;
      lvTargets.Sort();
    }

    #endregion
  }
}
