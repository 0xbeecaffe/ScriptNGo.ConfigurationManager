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

using System;
using System.Linq;
using System.Windows.Forms;

namespace PGT.ConfigurationManager
{
  public partial class ConfigSet : Form
  {
    /// <summary>
    /// Opens a new Config Set Editor dialog.
    /// </summary>
    /// <param name="ConfigSetID">The ID of the Set to Edit. If empty or set to -1 dialog goes into insert mode</param>
    public ConfigSet(int ConfigSetID = -1)
    {
      InitializeComponent();
      if (ConfigSetID != -1)
      {
        this.configSetsTableAdapter.FillByConfigSetID(this.configDS.ConfigSets, ConfigSetID);
        cbxCreateSetFrom.Enabled = false;
        label1.Enabled = false;
        tbNote.Enabled = true;
      }
      else
      {
        ConfigDS.ConfigSetsRow newRow = this.configDS.ConfigSets.NewConfigSetsRow();
        newRow.ConfigSetName = "New Configuration Set";
        newRow.Note = "";
        this.configDS.ConfigSets.AddConfigSetsRow(newRow);
        ConfigDS.ConfigSetsDataTable csdt = this.configSetsTableAdapter.GetData();
        ConfigDS.ConfigSetsRow er = csdt.NewConfigSetsRow();
        er.ConfigSetName = "<empty configuration set>";
        csdt.Rows.InsertAt(er, 0);
        cbxCreateSetFrom.DataSource = csdt.ToList();
      }
    }
    private void btnOK_Click(object sender, EventArgs e)
    {
      if (cbxCreateSetFrom.SelectedIndex == 0)
      {
        configSetsBindingSource.EndEdit();
        configSetsTableAdapter.Update(configDS);
      }
      else
      {
        qTA.CloneConfigSet(((ConfigDS.ConfigSetsRow)cbxCreateSetFrom.SelectedItem).ConfigSetID, tbConfigSetName.Text);
        configSetsBindingSource.CancelEdit();
      }
    }
    private void cbxCreateSetFrom_Format(object sender, ListControlConvertEventArgs e)
    {
      e.Value = ((ConfigDS.ConfigSetsRow)e.ListItem).ConfigSetName;
    }

    private void cbxCreateSetFrom_DropDownClosed(object sender, EventArgs e)
    {
      tbNote.Enabled = cbxCreateSetFrom.SelectedIndex == 0;
      if (cbxCreateSetFrom.SelectedIndex > 0)
      {
        if (!((ConfigDS.ConfigSetsRow)cbxCreateSetFrom.SelectedItem).IsNoteNull())
          tbNote.Text = ((ConfigDS.ConfigSetsRow)cbxCreateSetFrom.SelectedItem).Note;
      }
    }
  }
}
