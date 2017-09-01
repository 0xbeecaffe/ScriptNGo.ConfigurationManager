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
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace PGT.ConfigurationManager
{
  public partial class ConfigTarget : Form
  {
    /// <summary>
    /// Opens a new Config Target Editor dialog.
    /// </summary>
    /// <param name="ConfigTargetID">The ID of the Target to Edit. If empty or set to -1 dialog goes into insert mode</param>
    /// 
    public ConfigTarget(int ConfigTargetID = -1)
    {
      InitializeComponent();
      if (ConfigTargetID != -1)
      {
        this.configTargetsTableAdapter.FillByConfigTargetID(this.configDS.ConfigTargets, ConfigTargetID);
      }
      else
      {
        this.Text = "Add new Configuration Target";
        ConfigDS.ConfigTargetsRow newRow = this.configDS.ConfigTargets.NewConfigTargetsRow();
        newRow.TargetGroup = "default";
        newRow.TargetName = "";
        newRow.TargetIP = "0.0.0.0";
        newRow.DeviceVendor = "Cisco";
        newRow.Protocol = "Telnet";
        newRow.JumpServerIP = "";
        this.configDS.ConfigTargets.AddConfigTargetsRow(newRow);
      }
      distinctTargetGroupsTableAdapter.Fill(configDS.DistinctTargetGroups);
      var distinctGroupNames = from groupname in configDS.DistinctTargetGroups select groupname.DistinctTargetGroup;
      cbxTargetGroup.DataSource = distinctGroupNames.ToList();
    }

    private void ConfigTarget_Load(object sender, EventArgs e)
    {
      InitLookupLists();
    }

    private void DrawGradientBackground(object sender, PaintEventArgs e)
    {
      Rectangle rect = (sender as Control).ClientRectangle;
      using (Brush br = new LinearGradientBrush(rect, System.Drawing.Color.White, (sender as Control).BackColor, LinearGradientMode.Vertical))
      {
        e.Graphics.FillRectangle(br, rect);
      }
    }

    private void InitLookupLists()
    {
      // populate vendors
      cbxVendors.DataSource = Common.VendorsManager.SupportedVendors();
      if (!string.IsNullOrEmpty(Properties.Settings.Default.MRUVendor)) cbxVendors.Text = Properties.Settings.Default.MRUVendor;
      if (!string.IsNullOrEmpty(Properties.Settings.Default.MRUProtocol)) cbxProtocols.Text = Properties.Settings.Default.MRUProtocol;
      // populate jump servers
      cbxJumpServers.Items.Clear();
      var js = JumpServersManager.GetJumpServers();
      PGTDataSet.JumpServersRow emptyRow = JumpServersManager.DefaultJumpServerSettings();
      emptyRow.IPAddress = "";
      emptyRow.HostName = "";
      List<PGTDataSet.JumpServersRow> jumpServerList = js.ToList();
      jumpServerList.Insert(0, emptyRow);
      cbxJumpServers.DataSource = jumpServerList;
      // set values for dropdown lists
      if (!string.IsNullOrEmpty(Properties.Settings.Default.MRUJumpServer)) cbxJumpServers.Text = Properties.Settings.Default.MRUJumpServer;
      ConfigDS.ConfigTargetsRow curRow = (ConfigDS.ConfigTargetsRow)((DataRowView)configTargetsBS.Current).Row;
      if (curRow != null)
      {
        PGTDataSet.JumpServersRow thisJumpServer = jumpServerList.FirstOrDefault(j => j.IPAddress == curRow.JumpServerIP);
        cbxJumpServers.SelectedItem = thisJumpServer;
        cbxVendors.Text = curRow.DeviceVendor;
        cbxProtocols.Text = curRow.Protocol;
      }
    }

    private void btnOK_Click(object sender, EventArgs e)
    {
      try
      {
        if (targetNameTextBox.Text != "")
        {
          if (targetIPTextBox.Text.IsValidIP())
          {
            int? port = null;
            int p = -1;
            if (int.TryParse(portTextBox.Text, out p)) port = p;
            int? count = (int?)qTA.GetTargetCount(cbxTargetGroup.Text, targetIPTextBox.Text, port);
            if (count == 0)
            {
              ConfigDS.ConfigTargetsRow curRow = (ConfigDS.ConfigTargetsRow)((DataRowView)configTargetsBS.Current).Row;
              if (cbxJumpServers.SelectedValue != null) curRow.JumpServerIP = (cbxJumpServers.SelectedItem as PGTDataSet.JumpServersRow).IPAddress;
              configTargetsBS.EndEdit();
              configTargetsTableAdapter.Update(configDS);
            }
            else
            {
              MessageBox.Show("It is not allowed to add more targets to the same Target Group with the same ip address.", "Invalid data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
              DialogResult = DialogResult.None;
            }
          }
          else
          {
            MessageBox.Show("A Target must have a valid IPv4 address", "Invalid data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            DialogResult = DialogResult.None;
          }
        }
        else
        {
          MessageBox.Show("A Target must have a name.", "nIvalid data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
          DialogResult = DialogResult.None;
        }
      }
      catch (Exception Ex)
      {
        MessageBox.Show("An error occurred while saving target to database : " + Ex.Message, "Database error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void cbxJumpServers_Format(object sender, ListControlConvertEventArgs e)
    {
      string address = ((PGTDataSet.JumpServersRow)e.ListItem).IPAddress;
      string hostname = ((PGTDataSet.JumpServersRow)e.ListItem).HostName;
      if (string.IsNullOrEmpty(hostname)) e.Value = address;
      else e.Value = string.Format("{0} ( {1} )", address, hostname);
    }
  }
}
