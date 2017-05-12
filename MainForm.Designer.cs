﻿namespace SqlFileClient
{
	partial class MainForm
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
			this.tbConnectionString = new System.Windows.Forms.TextBox();
			this.tbCommandText = new System.Windows.Forms.TextBox();
			this.tbFilename = new System.Windows.Forms.TextBox();
			this.btnBrowse = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.btnExecuteQuery = new System.Windows.Forms.Button();
			this.tbOutput = new System.Windows.Forms.TextBox();
			this.chkBoxNameFromColumn = new System.Windows.Forms.CheckBox();
			this.radioBtnName1 = new System.Windows.Forms.RadioButton();
			this.radioBtnName2 = new System.Windows.Forms.RadioButton();
			this.radioBtnName3 = new System.Windows.Forms.RadioButton();
			this.SuspendLayout();
			// 
			// tbConnectionString
			// 
			this.tbConnectionString.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbConnectionString.Location = new System.Drawing.Point(100, 8);
			this.tbConnectionString.Multiline = true;
			this.tbConnectionString.Name = "tbConnectionString";
			this.tbConnectionString.Size = new System.Drawing.Size(564, 40);
			this.tbConnectionString.TabIndex = 0;
			this.tbConnectionString.Text = "Integrated Security=true;server=(local)";
			// 
			// tbCommandText
			// 
			this.tbCommandText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbCommandText.Location = new System.Drawing.Point(100, 52);
			this.tbCommandText.Multiline = true;
			this.tbCommandText.Name = "tbCommandText";
			this.tbCommandText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbCommandText.Size = new System.Drawing.Size(564, 140);
			this.tbCommandText.TabIndex = 1;
			this.tbCommandText.Text = "SELECT FilePath, FileValue FROM Archive.dbo.Records WHERE SerialNumber = 3";
			// 
			// tbFilename
			// 
			this.tbFilename.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbFilename.Location = new System.Drawing.Point(100, 198);
			this.tbFilename.Name = "tbFilename";
			this.tbFilename.Size = new System.Drawing.Size(484, 20);
			this.tbFilename.TabIndex = 2;
			this.tbFilename.Text = "C:\\Temp\\output.ext";
			// 
			// btnBrowse
			// 
			this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnBrowse.Location = new System.Drawing.Point(584, 198);
			this.btnBrowse.Name = "btnBrowse";
			this.btnBrowse.Size = new System.Drawing.Size(75, 23);
			this.btnBrowse.TabIndex = 3;
			this.btnBrowse.Text = "Browse...";
			this.btnBrowse.UseVisualStyleBackColor = true;
			this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(8, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(92, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "Connection string:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(20, 56);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(77, 13);
			this.label2.TabIndex = 5;
			this.label2.Text = "Command text:";
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 202);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(84, 13);
			this.label3.TabIndex = 6;
			this.label3.Text = "Output filename:";
			// 
			// btnExecuteQuery
			// 
			this.btnExecuteQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnExecuteQuery.Location = new System.Drawing.Point(212, 252);
			this.btnExecuteQuery.Name = "btnExecuteQuery";
			this.btnExecuteQuery.Size = new System.Drawing.Size(163, 40);
			this.btnExecuteQuery.TabIndex = 14;
			this.btnExecuteQuery.Text = "Execute SQL Command";
			this.btnExecuteQuery.UseVisualStyleBackColor = true;
			this.btnExecuteQuery.Click += new System.EventHandler(this.btnExecuteQuery_Click);
			// 
			// tbOutput
			// 
			this.tbOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbOutput.Location = new System.Drawing.Point(4, 308);
			this.tbOutput.Multiline = true;
			this.tbOutput.Name = "tbOutput";
			this.tbOutput.ReadOnly = true;
			this.tbOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbOutput.Size = new System.Drawing.Size(664, 162);
			this.tbOutput.TabIndex = 8;
			// 
			// chkBoxNameFromColumn
			// 
			this.chkBoxNameFromColumn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.chkBoxNameFromColumn.AutoSize = true;
			this.chkBoxNameFromColumn.Location = new System.Drawing.Point(104, 220);
			this.chkBoxNameFromColumn.Name = "chkBoxNameFromColumn";
			this.chkBoxNameFromColumn.Size = new System.Drawing.Size(338, 17);
			this.chkBoxNameFromColumn.TabIndex = 9;
			this.chkBoxNameFromColumn.Text = "Use first column value in file name (only if output to a folder above)";
			this.chkBoxNameFromColumn.UseVisualStyleBackColor = true;
			this.chkBoxNameFromColumn.CheckedChanged += new System.EventHandler(this.chkBoxNameFromColumn_CheckedChanged);
			// 
			// radioBtnName1
			// 
			this.radioBtnName1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.radioBtnName1.AutoSize = true;
			this.radioBtnName1.Checked = true;
			this.radioBtnName1.Enabled = false;
			this.radioBtnName1.Location = new System.Drawing.Point(116, 245);
			this.radioBtnName1.Name = "radioBtnName1";
			this.radioBtnName1.Size = new System.Drawing.Size(65, 17);
			this.radioBtnName1.TabIndex = 11;
			this.radioBtnName1.TabStop = true;
			this.radioBtnName1.Text = "Prepend";
			this.radioBtnName1.UseVisualStyleBackColor = true;
			// 
			// radioBtnName2
			// 
			this.radioBtnName2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.radioBtnName2.AutoSize = true;
			this.radioBtnName2.Enabled = false;
			this.radioBtnName2.Location = new System.Drawing.Point(116, 264);
			this.radioBtnName2.Name = "radioBtnName2";
			this.radioBtnName2.Size = new System.Drawing.Size(62, 17);
			this.radioBtnName2.TabIndex = 12;
			this.radioBtnName2.Text = "Append";
			this.radioBtnName2.UseVisualStyleBackColor = true;
			// 
			// radioBtnName3
			// 
			this.radioBtnName3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.radioBtnName3.AutoSize = true;
			this.radioBtnName3.Enabled = false;
			this.radioBtnName3.Location = new System.Drawing.Point(116, 284);
			this.radioBtnName3.Name = "radioBtnName3";
			this.radioBtnName3.Size = new System.Drawing.Size(65, 17);
			this.radioBtnName3.TabIndex = 13;
			this.radioBtnName3.Text = "Replace";
			this.radioBtnName3.UseVisualStyleBackColor = true;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(670, 473);
			this.Controls.Add(this.radioBtnName3);
			this.Controls.Add(this.radioBtnName2);
			this.Controls.Add(this.radioBtnName1);
			this.Controls.Add(this.chkBoxNameFromColumn);
			this.Controls.Add(this.tbOutput);
			this.Controls.Add(this.btnExecuteQuery);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnBrowse);
			this.Controls.Add(this.tbFilename);
			this.Controls.Add(this.tbCommandText);
			this.Controls.Add(this.tbConnectionString);
			this.MinimumSize = new System.Drawing.Size(686, 511);
			this.Name = "MainForm";
			this.Text = "SqlFileStream 2 File System";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox tbConnectionString;
		private System.Windows.Forms.TextBox tbCommandText;
		private System.Windows.Forms.TextBox tbFilename;
		private System.Windows.Forms.Button btnBrowse;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btnExecuteQuery;
		private System.Windows.Forms.TextBox tbOutput;
        private System.Windows.Forms.CheckBox chkBoxNameFromColumn;
        private System.Windows.Forms.RadioButton radioBtnName1;
        private System.Windows.Forms.RadioButton radioBtnName2;
        private System.Windows.Forms.RadioButton radioBtnName3;
	}
}

