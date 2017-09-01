namespace PGT.ConfigurationManager
{
  partial class CSVHeaderMapper
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.label3 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.cbxTargetNameColumn = new System.Windows.Forms.ComboBox();
      this.cbxTargetIPColumn = new System.Windows.Forms.ComboBox();
      this.cbxProtocolColumn = new System.Windows.Forms.ComboBox();
      this.label4 = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      this.btnOK = new System.Windows.Forms.Button();
      this.btnCancelImport = new System.Windows.Forms.Button();
      this.cbxNoteColumn = new System.Windows.Forms.ComboBox();
      this.label7 = new System.Windows.Forms.Label();
      this.cbxVendorColumn = new System.Windows.Forms.ComboBox();
      this.label8 = new System.Windows.Forms.Label();
      this.cbxJumpServerIPColumn = new System.Windows.Forms.ComboBox();
      this.label9 = new System.Windows.Forms.Label();
      this.cbxTargetGroupNameColumn = new System.Windows.Forms.ComboBox();
      this.label10 = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(19, 134);
      this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(97, 17);
      this.label3.TabIndex = 6;
      this.label3.Text = "Target name :";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(19, 170);
      this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(70, 17);
      this.label1.TabIndex = 7;
      this.label1.Text = "Target IP:";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(19, 240);
      this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(64, 17);
      this.label2.TabIndex = 8;
      this.label2.Text = "Protocol:";
      // 
      // cbxTargetNameColumn
      // 
      this.cbxTargetNameColumn.FormattingEnabled = true;
      this.cbxTargetNameColumn.Location = new System.Drawing.Point(203, 130);
      this.cbxTargetNameColumn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.cbxTargetNameColumn.Name = "cbxTargetNameColumn";
      this.cbxTargetNameColumn.Size = new System.Drawing.Size(259, 24);
      this.cbxTargetNameColumn.TabIndex = 0;
      // 
      // cbxTargetIPColumn
      // 
      this.cbxTargetIPColumn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbxTargetIPColumn.FormattingEnabled = true;
      this.cbxTargetIPColumn.Location = new System.Drawing.Point(203, 166);
      this.cbxTargetIPColumn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.cbxTargetIPColumn.Name = "cbxTargetIPColumn";
      this.cbxTargetIPColumn.Size = new System.Drawing.Size(259, 24);
      this.cbxTargetIPColumn.TabIndex = 1;
      // 
      // cbxProtocolColumn
      // 
      this.cbxProtocolColumn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbxProtocolColumn.FormattingEnabled = true;
      this.cbxProtocolColumn.Location = new System.Drawing.Point(203, 236);
      this.cbxProtocolColumn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.cbxProtocolColumn.Name = "cbxProtocolColumn";
      this.cbxProtocolColumn.Size = new System.Drawing.Size(259, 24);
      this.cbxProtocolColumn.TabIndex = 3;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(224, 62);
      this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(222, 17);
      this.label4.TabIndex = 12;
      this.label4.Text = "Select  columns  or specify value :";
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(19, 62);
      this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(119, 17);
      this.label5.TabIndex = 13;
      this.label5.Text = "Required values :";
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label6.Location = new System.Drawing.Point(16, 22);
      this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(443, 17);
      this.label6.TabIndex = 14;
      this.label6.Text = "Use the following map to import column values from CSV file";
      // 
      // btnOK
      // 
      this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.btnOK.Location = new System.Drawing.Point(353, 351);
      this.btnOK.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new System.Drawing.Size(109, 28);
      this.btnOK.TabIndex = 6;
      this.btnOK.Text = "OK";
      this.btnOK.UseVisualStyleBackColor = true;
      // 
      // btnCancelImport
      // 
      this.btnCancelImport.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btnCancelImport.Location = new System.Drawing.Point(23, 351);
      this.btnCancelImport.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.btnCancelImport.Name = "btnCancelImport";
      this.btnCancelImport.Size = new System.Drawing.Size(116, 28);
      this.btnCancelImport.TabIndex = 5;
      this.btnCancelImport.Text = "Cancel";
      this.btnCancelImport.UseVisualStyleBackColor = true;
      // 
      // cbxNoteColumn
      // 
      this.cbxNoteColumn.FormattingEnabled = true;
      this.cbxNoteColumn.Location = new System.Drawing.Point(203, 304);
      this.cbxNoteColumn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.cbxNoteColumn.Name = "cbxNoteColumn";
      this.cbxNoteColumn.Size = new System.Drawing.Size(259, 24);
      this.cbxNoteColumn.TabIndex = 4;
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(19, 308);
      this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(38, 17);
      this.label7.TabIndex = 17;
      this.label7.Text = "Note";
      // 
      // cbxVendorColumn
      // 
      this.cbxVendorColumn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbxVendorColumn.FormattingEnabled = true;
      this.cbxVendorColumn.Location = new System.Drawing.Point(203, 271);
      this.cbxVendorColumn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.cbxVendorColumn.Name = "cbxVendorColumn";
      this.cbxVendorColumn.Size = new System.Drawing.Size(259, 24);
      this.cbxVendorColumn.TabIndex = 18;
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Location = new System.Drawing.Point(19, 274);
      this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(54, 17);
      this.label8.TabIndex = 19;
      this.label8.Text = "Vendor";
      // 
      // cbxJumpServerIPColumn
      // 
      this.cbxJumpServerIPColumn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbxJumpServerIPColumn.FormattingEnabled = true;
      this.cbxJumpServerIPColumn.Location = new System.Drawing.Point(203, 202);
      this.cbxJumpServerIPColumn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.cbxJumpServerIPColumn.Name = "cbxJumpServerIPColumn";
      this.cbxJumpServerIPColumn.Size = new System.Drawing.Size(259, 24);
      this.cbxJumpServerIPColumn.TabIndex = 20;
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Location = new System.Drawing.Point(19, 206);
      this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(106, 17);
      this.label9.TabIndex = 21;
      this.label9.Text = "Jump server IP:";
      // 
      // cbxTargetGroupNameColumn
      // 
      this.cbxTargetGroupNameColumn.FormattingEnabled = true;
      this.cbxTargetGroupNameColumn.Location = new System.Drawing.Point(203, 97);
      this.cbxTargetGroupNameColumn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.cbxTargetGroupNameColumn.Name = "cbxTargetGroupNameColumn";
      this.cbxTargetGroupNameColumn.Size = new System.Drawing.Size(259, 24);
      this.cbxTargetGroupNameColumn.TabIndex = 22;
      // 
      // label10
      // 
      this.label10.AutoSize = true;
      this.label10.Location = new System.Drawing.Point(19, 101);
      this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label10.Name = "label10";
      this.label10.Size = new System.Drawing.Size(138, 17);
      this.label10.TabIndex = 23;
      this.label10.Text = "Target group name :";
      // 
      // CSVHeaderMapper
      // 
      this.AcceptButton = this.btnOK;
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.btnCancelImport;
      this.ClientSize = new System.Drawing.Size(492, 404);
      this.Controls.Add(this.cbxTargetGroupNameColumn);
      this.Controls.Add(this.label10);
      this.Controls.Add(this.cbxJumpServerIPColumn);
      this.Controls.Add(this.label9);
      this.Controls.Add(this.cbxVendorColumn);
      this.Controls.Add(this.label8);
      this.Controls.Add(this.cbxNoteColumn);
      this.Controls.Add(this.label7);
      this.Controls.Add(this.btnCancelImport);
      this.Controls.Add(this.btnOK);
      this.Controls.Add(this.label6);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.cbxProtocolColumn);
      this.Controls.Add(this.cbxTargetIPColumn);
      this.Controls.Add(this.cbxTargetNameColumn);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.label3);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "CSVHeaderMapper";
      this.ShowIcon = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Import - CSV Header Mapper";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.ComboBox cbxTargetNameColumn;
    private System.Windows.Forms.ComboBox cbxTargetIPColumn;
    private System.Windows.Forms.ComboBox cbxProtocolColumn;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Button btnOK;
    private System.Windows.Forms.Button btnCancelImport;
    private System.Windows.Forms.ComboBox cbxNoteColumn;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.ComboBox cbxVendorColumn;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.ComboBox cbxJumpServerIPColumn;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.ComboBox cbxTargetGroupNameColumn;
    private System.Windows.Forms.Label label10;
  }
}