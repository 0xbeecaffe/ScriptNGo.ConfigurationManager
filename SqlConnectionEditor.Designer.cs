namespace PGT.ConfigurationManager
{
  partial class SqlConnectionEditor
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
      this.btnOK = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.btnCancel = new System.Windows.Forms.Button();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.tbSQLPassword = new System.Windows.Forms.TextBox();
      this.tbSQLUser = new System.Windows.Forms.TextBox();
      this.checkBox1 = new System.Windows.Forms.CheckBox();
      this.tbDatabaseName = new System.Windows.Forms.TextBox();
      this.cbxSQLServerName = new System.Windows.Forms.ComboBox();
      this.SuspendLayout();
      // 
      // btnOK
      // 
      this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.btnOK.Location = new System.Drawing.Point(266, 169);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new System.Drawing.Size(75, 23);
      this.btnOK.TabIndex = 0;
      this.btnOK.Text = "OK";
      this.btnOK.UseVisualStyleBackColor = true;
      this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(13, 18);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(95, 13);
      this.label1.TabIndex = 1;
      this.label1.Text = "SQL server name :";
      // 
      // btnCancel
      // 
      this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btnCancel.Location = new System.Drawing.Point(12, 169);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(75, 23);
      this.btnCancel.TabIndex = 3;
      this.btnCancel.Text = "Cancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(13, 44);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(88, 13);
      this.label2.TabIndex = 5;
      this.label2.Text = "Database name :";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(13, 133);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(53, 13);
      this.label3.TabIndex = 10;
      this.label3.Text = "Password";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(13, 107);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(55, 13);
      this.label4.TabIndex = 8;
      this.label4.Text = "Username";
      // 
      // tbSQLPassword
      // 
      this.tbSQLPassword.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::PGT.ConfigurationManager.Properties.Settings.Default, "SQLServerPassword", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.tbSQLPassword.Location = new System.Drawing.Point(150, 133);
      this.tbSQLPassword.Name = "tbSQLPassword";
      this.tbSQLPassword.PasswordChar = '*';
      this.tbSQLPassword.Size = new System.Drawing.Size(191, 20);
      this.tbSQLPassword.TabIndex = 11;
      this.tbSQLPassword.Text = global::PGT.ConfigurationManager.Properties.Settings.Default.SQLServerPassword;
      // 
      // tbSQLUser
      // 
      this.tbSQLUser.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::PGT.ConfigurationManager.Properties.Settings.Default, "SQLServerUsername", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.tbSQLUser.Location = new System.Drawing.Point(150, 107);
      this.tbSQLUser.Name = "tbSQLUser";
      this.tbSQLUser.Size = new System.Drawing.Size(191, 20);
      this.tbSQLUser.TabIndex = 9;
      this.tbSQLUser.Text = global::PGT.ConfigurationManager.Properties.Settings.Default.SQLServerUsername;
      // 
      // checkBox1
      // 
      this.checkBox1.AutoSize = true;
      this.checkBox1.Checked = global::PGT.ConfigurationManager.Properties.Settings.Default.SQLIntegratedSecurity;
      this.checkBox1.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::PGT.ConfigurationManager.Properties.Settings.Default, "SQLIntegratedSecurity", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.checkBox1.Location = new System.Drawing.Point(16, 76);
      this.checkBox1.Name = "checkBox1";
      this.checkBox1.Size = new System.Drawing.Size(163, 17);
      this.checkBox1.TabIndex = 7;
      this.checkBox1.Text = "Use Windows Authentication";
      this.checkBox1.UseVisualStyleBackColor = true;
      this.checkBox1.CheckStateChanged += new System.EventHandler(this.checkBox1_CheckStateChanged);
      // 
      // tbDatabaseName
      // 
      this.tbDatabaseName.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::PGT.ConfigurationManager.Properties.Settings.Default, "DatabaseName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.tbDatabaseName.Location = new System.Drawing.Point(150, 44);
      this.tbDatabaseName.Name = "tbDatabaseName";
      this.tbDatabaseName.Size = new System.Drawing.Size(191, 20);
      this.tbDatabaseName.TabIndex = 6;
      this.tbDatabaseName.Text = global::PGT.ConfigurationManager.Properties.Settings.Default.DatabaseName;
      // 
      // cbxSQLServerName
      // 
      this.cbxSQLServerName.FormattingEnabled = true;
      this.cbxSQLServerName.Location = new System.Drawing.Point(150, 18);
      this.cbxSQLServerName.Name = "cbxSQLServerName";
      this.cbxSQLServerName.Size = new System.Drawing.Size(191, 21);
      this.cbxSQLServerName.TabIndex = 12;
      // 
      // SqlConnectionEditor
      // 
      this.AcceptButton = this.btnOK;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.btnCancel;
      this.ClientSize = new System.Drawing.Size(366, 206);
      this.Controls.Add(this.cbxSQLServerName);
      this.Controls.Add(this.tbSQLPassword);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.tbSQLUser);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.checkBox1);
      this.Controls.Add(this.tbDatabaseName);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.btnCancel);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.btnOK);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.Name = "SqlConnectionEditor";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Sql Connection Editor";
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SqlConnectionEditor_FormClosed);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button btnOK;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.TextBox tbDatabaseName;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.CheckBox checkBox1;
    private System.Windows.Forms.TextBox tbSQLPassword;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox tbSQLUser;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.ComboBox cbxSQLServerName;
  }
}