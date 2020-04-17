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

using System.Linq;
using System.Windows.Forms;

namespace Scriptngo.ConfigurationManager
{
  public partial class CSVHeaderMapper : Form
  {
    private string _NoSelectionText;
    private string[] Headers;
    public CSVHeaderMapper(string[] Headers, string NotMappedText)
    {
      InitializeComponent();
      this.Headers = Headers;
      _NoSelectionText = NotMappedText;
      //--
      cbxTargetNameColumn.Items.AddRange(Headers);
      cbxTargetGroupNameColumn.Items.AddRange(Headers);
      cbxTargetGroupNameColumn.Items.Insert(0, NotMappedText);
      cbxTargetIPColumn.Items.AddRange(Headers);
      cbxJumpServerIPColumn.Items.AddRange(Headers);
      cbxJumpServerIPColumn.Items.Insert(0, NotMappedText);
      cbxProtocolColumn.Items.AddRange(Headers);
      cbxProtocolColumn.Items.Insert(0, NotMappedText);
      cbxNoteColumn.Items.AddRange(Headers);
      cbxNoteColumn.Items.Insert(0, NotMappedText);
      cbxVendorColumn.Items.AddRange(Headers);
      cbxVendorColumn.Items.Insert(0, NotMappedText);
      cbxVendorColumn.Items.AddRange(Scriptngo.Common.VendorsManager.SupportedVendors().ToArray());
    }
    public int GetTargetNameColumnIndex
    {
      get
      {
        if (cbxTargetNameColumn.Text == _NoSelectionText) return -2;
        else if (Headers.Contains(cbxTargetNameColumn.Text)) return cbxTargetNameColumn.SelectedIndex;
        else return cbxTargetNameColumn.SelectedIndex; 
      }
    }
    public int GetTargetGroupNameColumnIndex
    {
      get
      {
        if (cbxTargetGroupNameColumn.Text == _NoSelectionText) return -2;
        else if (Headers.Contains(cbxTargetGroupNameColumn.Text)) return cbxTargetGroupNameColumn.SelectedIndex - 1;// decrease by one, because NotMappedText was inserted at position 0
        else return -1;
      }
    }
    public int GetTargetIPColumnIndex
    {
      get
      {
        if (cbxTargetIPColumn.Text == _NoSelectionText) return -2;
        else return cbxTargetIPColumn.SelectedIndex;
      }
    }
    public int GetJumpServerIPColumnIndex
    {
      get
      {
        if (cbxJumpServerIPColumn.Text == _NoSelectionText) return -2;
        else return cbxJumpServerIPColumn.SelectedIndex - 1;// decrease by one, because NotMappedText was inserted at position 0
      }
    }

    public int GetProtocolColumnIndex
    {
      get
      {
        if (cbxProtocolColumn.Text == _NoSelectionText) return -2;
        else return cbxProtocolColumn.SelectedIndex - 1; // decrease by one, because NotMappedText was inserted at position 0
      }
    }
    /// <summary>
    /// Returns :
    /// -2 : if NotMappedText was selected
    /// -1 : if the selected text is not among the headers but is a supported vendor. Use GetVendorText() in this case to get the selected vendor text.
    /// other : the column index of the header selected
    /// </summary>
    public int GetNoteColumnIndex
    {
      get
      {
        if (cbxNoteColumn.Text == _NoSelectionText) return -2;
        else if (Headers.Contains(cbxNoteColumn.Text)) return cbxNoteColumn.SelectedIndex - 1;// decrease by one, because NotMappedText was inserted at position 0
        else return  - 1; 
      }
    }
    /// <summary>
    /// Returns :
    /// -1 : if the selected text is not among the headers but is a supported vendor. Use GetVendorText() in this case to get the selected vendor text.
    /// other : the column index of the header selected
    /// </summary>
    public int GetVendorColumnIndex
    {
      get
      {
        if (Headers.Contains(cbxVendorColumn.Text)) return cbxVendorColumn.SelectedIndex - 1;
        else return - 1; 
      }
    }
    public string GetTargetNameText { get { return cbxTargetNameColumn.Text; } }
    public string GetTargeGroupNameText { get { return cbxTargetGroupNameColumn.Text; } }
    public string GetNoteText { get { return cbxNoteColumn.Text; } }
    public string GetVendorText { get { return cbxVendorColumn.Text; } }
  }
}
