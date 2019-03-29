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
using PGT.ExtensionInterfaces;
using System;
using System.Windows.Forms;

namespace PGT.ConfigurationManager
{
  class PGTInterface : ICustomMenuHandler
  {
    #region Fields
    private Form AppMainForm;
    private WorkInProgress _workInProgress;
    private string _workInProgressText;
    private string _workInProgressCaption;
    #endregion

    #region ICustomMenuHandler Members
    public PGTInterface()
    {
			_workInProgress = new WorkInProgress();
      _workInProgress.Caption = "Please wait";
      _workInProgress.Text = "Loading module...";
      if (!Properties.Settings.Default.HasSettingsUpgraded)
      {
        Properties.Settings.Default.Upgrade();
        Properties.Settings.Default.HasSettingsUpgraded = true;
        Properties.Settings.Default.Save();
      }
    }
    public System.Windows.Forms.ToolStripMenuItem GetMenu()
    {
      ToolStripMenuItem tsmMainMenu = new ToolStripMenuItem();
      ToolStripMenuItem tsmConfigManager = new ToolStripMenuItem();
      ToolStripMenuItem tsmConfigure = new ToolStripMenuItem();

      tsmMainMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { tsmConfigure, tsmConfigManager });

      #region Menu definition
      // 
      // tsmMainMenu
      // 
      tsmMainMenu.Image = Resource1.RegistryEditor_5838_16x;
      tsmMainMenu.ImageTransparentColor = System.Drawing.Color.Black;
      tsmMainMenu.ImageScaling = ToolStripItemImageScaling.None;
      tsmMainMenu.Name = "PGT.ConfigurationManager.tsmMainMenu";
      tsmMainMenu.Text = "Configuration Manager";
      // 
      // tsmConfigure
      // 
      tsmConfigure.Image = Resource1.ManageCounterSets_8769;
      tsmConfigure.ImageTransparentColor = System.Drawing.Color.Black;
      tsmConfigure.ImageScaling = ToolStripItemImageScaling.None;
      tsmConfigure.Name = "PGT.ConfigurationManager.tsmConfigure";
      tsmConfigure.Text = "Configure database";
      tsmConfigure.Click += tsmConfigure_Click;
      // 
      // tsmConfigManager
      // 
      tsmConfigManager.Image = Resource1.DBSchema_12823;
      tsmConfigManager.ImageTransparentColor = System.Drawing.Color.Black;
      tsmConfigManager.ImageScaling = ToolStripItemImageScaling.None;
      tsmConfigManager.Name = "PGT.ConfigurationManager.tsmConfigManager";
      tsmConfigManager.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M)));
      tsmConfigManager.Text = "Manage configurations";
      tsmConfigManager.Click += tsmConfigManager_Click;
      #endregion
      return tsmMainMenu;
    }
		public bool AsyncLoadFrom(string fileName) => false;
    private void tsmConfigManager_Click(object sender, EventArgs e)
    {
      _workInProgress.Caption = "Please wait";
      _workInProgress.Text = "Loading module";
			_workInProgress.Run();
      try
      {
        ConfigManager CM = new ConfigManager();
        CM.Show();
        CM.MdiParent = AppMainForm;
      }
      finally
      {
				_workInProgress.Cancel();
      }
    }
    private void tsmStatisticsView_Click(object sender, EventArgs e)
    {
      //_workInProgress.RunWorkerAsync();
      //try
      //{
      //  ScriptingStatistics sStat = new ScriptingStatistics();
      //  sStat.Show();
      //  sStat.MdiParent = AppMainForm;
      //}
      //finally
      //{
      //  _workInProgress.CancelAsync();
      //}
    }
    private void tsmConfigure_Click(object sender, EventArgs e)
    {
      _workInProgressCaption = "Please wait";
      _workInProgressText = "Configuring SQL Server";
      try
      {
        (new SqlConnectionEditor(_workInProgress)).ShowDialog();
      }
      finally
      {
				_workInProgress.Cancel();
      }
    }
    public void SetMainForm(System.Windows.Forms.Form mainForm)
    {
      AppMainForm = mainForm;
    }
    #endregion
  }
}
