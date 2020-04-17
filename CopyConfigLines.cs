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

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Scriptngo.ConfigurationManager
{
  public partial class CopyConfigLines : Form
  {
    #region Fields
    /// <summary>
    /// The ID of the configuration set beeing deployed
    /// </summary>
    private int _configurationSetID;
    private int _sourceSetTargetID;
    #endregion
    public CopyConfigLines(int ConfigurationSetID, int sourceSetTargetID)
    {
      InitializeComponent();
      _configurationSetID = ConfigurationSetID;
      _sourceSetTargetID = sourceSetTargetID;
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


    private void DrawGradientBackground(object sender, PaintEventArgs e)
    {
      Rectangle rect = (sender as Control).ClientRectangle;
      using (Brush br = new LinearGradientBrush(rect, System.Drawing.Color.White, (sender as Control).BackColor, LinearGradientMode.Vertical))
      {
        e.Graphics.FillRectangle(br, rect);
      }
    }

    private void SaveConfigLines_Load(object sender, EventArgs e)
    {
      setTargetsTA.FillTargetsInSet(configDS.SetTargets, _configurationSetID);

      foreach (var item in configDS.SetTargets)
      {
        if (item.ConfigSetTargetID != _sourceSetTargetID) clbTargets.Items.Add(item, true);
      }
      if (clbTargets.Items.Count == 0)
      {
        btnSaveConfig.Enabled = false;
        MessageBox.Show("There are no targets in this set to copy the configuration to.", "Empty configuration set", MessageBoxButtons.OK, MessageBoxIcon.Error);
        DialogResult = System.Windows.Forms.DialogResult.Cancel;
        Close();
      }
    }

    private void DoCopy()
    {
      try
      {
        foreach (var target in configDS.SetTargets)
        {
          if (IsTargetSelected(target.ConfigTargetID))
          {
            int destSetTargetID = target.ConfigSetTargetID;
            qTA.CopyConfigLines(_sourceSetTargetID, destSetTargetID);
          }
        }
        MessageBox.Show("Operation finished successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
      }
      catch (Exception Ex)
      {
        MessageBox.Show("Unfortunately an unexpected error occurred during copy operation : " + Ex.Message, "Copy error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void btnSaveConfig_Click(object sender, EventArgs e)
    {
      DoCopy();
    }

    private void clbTargets_Format(object sender, ListControlConvertEventArgs e)
    {
      ConfigDS.SetTargetsRow r = (e.ListItem as ConfigDS.SetTargetsRow);
      e.Value = string.Format("{0} :: {1} ({2})", r.TargetGroup, r.TargetName, r.TargetIP);
    }
  }
}
