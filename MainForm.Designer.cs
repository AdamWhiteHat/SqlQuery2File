namespace SqlFileClient
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
			this.SuspendLayout();
			// 
			// tbConnectionString
			// 
			this.tbConnectionString.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbConnectionString.Location = new System.Drawing.Point(104, 12);
			this.tbConnectionString.Multiline = true;
			this.tbConnectionString.Name = "tbConnectionString";
			this.tbConnectionString.Size = new System.Drawing.Size(556, 40);
			this.tbConnectionString.TabIndex = 0;
			this.tbConnectionString.Text = "Integrated Security=true;server=(local)";
			// 
			// tbCommandText
			// 
			this.tbCommandText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbCommandText.Location = new System.Drawing.Point(104, 56);
			this.tbCommandText.Multiline = true;
			this.tbCommandText.Name = "tbCommandText";
			this.tbCommandText.Size = new System.Drawing.Size(556, 40);
			this.tbCommandText.TabIndex = 1;
			this.tbCommandText.Text = "SELECT Chart.PathName() FROM Archive.dbo.Records WHERE SerialNumber = 3";
			// 
			// tbFilename
			// 
			this.tbFilename.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbFilename.Location = new System.Drawing.Point(104, 100);
			this.tbFilename.Name = "tbFilename";
			this.tbFilename.Size = new System.Drawing.Size(476, 20);
			this.tbFilename.TabIndex = 2;
			this.tbFilename.Text = "C:\\Temp\\output.ext";
			// 
			// btnBrowse
			// 
			this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnBrowse.Location = new System.Drawing.Point(584, 100);
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
			this.label1.Location = new System.Drawing.Point(8, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(92, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "Connection string:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(24, 60);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(77, 13);
			this.label2.TabIndex = 5;
			this.label2.Text = "Command text:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(16, 104);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(84, 13);
			this.label3.TabIndex = 6;
			this.label3.Text = "Output filename:";
			// 
			// btnExecuteQuery
			// 
			this.btnExecuteQuery.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnExecuteQuery.Location = new System.Drawing.Point(252, 132);
			this.btnExecuteQuery.Name = "btnExecuteQuery";
			this.btnExecuteQuery.Size = new System.Drawing.Size(163, 32);
			this.btnExecuteQuery.TabIndex = 7;
			this.btnExecuteQuery.Text = "Execute SQL Command";
			this.btnExecuteQuery.UseVisualStyleBackColor = true;
			this.btnExecuteQuery.Click += new System.EventHandler(this.btnExecuteQuery_Click);
			// 
			// tbOutput
			// 
			this.tbOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbOutput.Location = new System.Drawing.Point(4, 172);
			this.tbOutput.Multiline = true;
			this.tbOutput.Name = "tbOutput";
			this.tbOutput.ReadOnly = true;
			this.tbOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbOutput.Size = new System.Drawing.Size(664, 104);
			this.tbOutput.TabIndex = 8;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(670, 280);
			this.Controls.Add(this.tbOutput);
			this.Controls.Add(this.btnExecuteQuery);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnBrowse);
			this.Controls.Add(this.tbFilename);
			this.Controls.Add(this.tbCommandText);
			this.Controls.Add(this.tbConnectionString);
			this.MinimumSize = new System.Drawing.Size(686, 318);
			this.Name = "MainForm";
			this.Text = "SQL Query 2 File";
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
	}
}

