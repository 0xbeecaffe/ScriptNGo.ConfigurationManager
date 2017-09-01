namespace PGT.ConfigurationManager
{
  partial class CopyConfigLines
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
      this.clbTargets = new System.Windows.Forms.CheckedListBox();
      this.label1 = new System.Windows.Forms.Label();
      this.btnSaveConfig = new System.Windows.Forms.Button();
      this.configDS = new PGT.ConfigurationManager.ConfigDS();
      this.setTargetsTA = new PGT.ConfigurationManager.ConfigDSTableAdapters.SetTargetsTableAdapter();
      this.qTA = new PGT.ConfigurationManager.ConfigDSTableAdapters.QueriesTableAdapter();
      this.configLinesTA = new PGT.ConfigurationManager.ConfigDSTableAdapters.ConfigLinesTableAdapter();
      this.btnCancel = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.configDS)).BeginInit();
      this.SuspendLayout();
      // 
      // clbTargets
      // 
      this.clbTargets.FormattingEnabled = true;
      this.clbTargets.Location = new System.Drawing.Point(22, 37);
      this.clbTargets.Name = "clbTargets";
      this.clbTargets.Size = new System.Drawing.Size(411, 169);
      this.clbTargets.TabIndex = 0;
      this.clbTargets.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.clbTargets_Format);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.BackColor = System.Drawing.Color.Transparent;
      this.label1.Location = new System.Drawing.Point(22, 18);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(247, 13);
      this.label1.TabIndex = 1;
      this.label1.Text = "Copy current configuration to the below set targets:";
      // 
      // btnSaveConfig
      // 
      this.btnSaveConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btnSaveConfig.BackColor = System.Drawing.Color.DodgerBlue;
      this.btnSaveConfig.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.btnSaveConfig.Location = new System.Drawing.Point(336, 219);
      this.btnSaveConfig.Name = "btnSaveConfig";
      this.btnSaveConfig.Size = new System.Drawing.Size(97, 30);
      this.btnSaveConfig.TabIndex = 42;
      this.btnSaveConfig.Text = "Copy";
      this.btnSaveConfig.UseVisualStyleBackColor = false;
      this.btnSaveConfig.Click += new System.EventHandler(this.btnSaveConfig_Click);
      // 
      // configDS
      // 
      this.configDS.DataSetName = "ConfigDS";
      this.configDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
      // 
      // setTargetsTA
      // 
      this.setTargetsTA.ClearBeforeFill = true;
      // 
      // configLinesTA
      // 
      this.configLinesTA.ClearBeforeFill = true;
      // 
      // btnCancel
      // 
      this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btnCancel.BackColor = System.Drawing.Color.DarkSeaGreen;
      this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btnCancel.Location = new System.Drawing.Point(25, 219);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(97, 30);
      this.btnCancel.TabIndex = 43;
      this.btnCancel.Text = "Cancel";
      this.btnCancel.UseVisualStyleBackColor = false;
      // 
      // CopyConfigLines
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.DarkViolet;
      this.ClientSize = new System.Drawing.Size(466, 261);
      this.Controls.Add(this.btnCancel);
      this.Controls.Add(this.btnSaveConfig);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.clbTargets);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "CopyConfigLines";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Copy configuration";
      this.Load += new System.EventHandler(this.SaveConfigLines_Load);
      this.Paint += new System.Windows.Forms.PaintEventHandler(this.DrawGradientBackground);
      ((System.ComponentModel.ISupportInitialize)(this.configDS)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.CheckedListBox clbTargets;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button btnSaveConfig;
    private ConfigDS configDS;
    private ConfigDSTableAdapters.SetTargetsTableAdapter setTargetsTA;
    private ConfigDSTableAdapters.QueriesTableAdapter qTA;
    private ConfigDSTableAdapters.ConfigLinesTableAdapter configLinesTA;
    private System.Windows.Forms.Button btnCancel;
  }
}