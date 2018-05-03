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
using PGT.ConfigurationManager.Properties;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace PGT.ConfigurationManager
{
  public partial class SqlConnectionEditor : Form
  {
    private WorkInProgress _animation;
    public SqlConnectionEditor(WorkInProgress animation = null)
    {
      InitializeComponent();
      _animation = animation;
      cbxSQLServerName.DataSource = Settings.Default.SQLServerNames;
      cbxSQLServerName.Text = Settings.Default.SQLServerName;
    }

    private void btnOK_Click(object sender, EventArgs e)
    {
    }

    private void SqlConnectionEditor_FormClosed(object sender, FormClosedEventArgs e)
    {
      Settings curSettings = Settings.Default;
      if (DialogResult == System.Windows.Forms.DialogResult.OK)
      {
				_animation.Run();
        try
        {
          if (curSettings.SQLServerNames == null) curSettings.SQLServerNames = new System.Collections.Specialized.StringCollection();
          if (!curSettings.SQLServerNames.Contains(cbxSQLServerName.Text))
          {
            curSettings.SQLServerNames.Add(cbxSQLServerName.Text);
          }
          curSettings.SQLServerName = cbxSQLServerName.Text;
          curSettings.Save();
          Hide();
          DatabaseManager.RegisterDatabase(curSettings.SQLServerName, curSettings.DatabaseName, curSettings.SQLIntegratedSecurity, curSettings.SQLServerUsername, curSettings.SQLServerPassword, _animation);
        }
        finally
        {
					_animation?.Cancel();
        }
        MessageBox.Show("Application needs to be restarted for the updated configuration to take effect.", "Restart required", MessageBoxButtons.OK, MessageBoxIcon.Information);
      }
    }

    private void checkBox1_CheckStateChanged(object sender, EventArgs e)
    {
      tbSQLUser.Enabled = !checkBox1.Checked;
      tbSQLPassword.Enabled = !checkBox1.Checked;
    }

  }
}
