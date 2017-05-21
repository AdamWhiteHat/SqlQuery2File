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
			this.btnExecuteQuery = new System.Windows.Forms.Button();
			this.tbOutput = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.tbCommandText = new System.Windows.Forms.TextBox();
			this.tbConnectionString = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.tbFilepathMask = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.numFileDataIndex = new System.Windows.Forms.NumericUpDown();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numFileDataIndex)).BeginInit();
			this.SuspendLayout();
			// 
			// btnExecuteQuery
			// 
			this.btnExecuteQuery.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btnExecuteQuery.Location = new System.Drawing.Point(240, 316);
			this.btnExecuteQuery.Name = "btnExecuteQuery";
			this.btnExecuteQuery.Size = new System.Drawing.Size(163, 40);
			this.btnExecuteQuery.TabIndex = 14;
			this.btnExecuteQuery.Text = "Execute SQL Command (F5)";
			this.btnExecuteQuery.UseVisualStyleBackColor = true;
			this.btnExecuteQuery.Click += new System.EventHandler(this.btnExecuteQuery_Click);
			// 
			// tbOutput
			// 
			this.tbOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbOutput.Location = new System.Drawing.Point(4, 364);
			this.tbOutput.Multiline = true;
			this.tbOutput.Name = "tbOutput";
			this.tbOutput.ReadOnly = true;
			this.tbOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbOutput.Size = new System.Drawing.Size(664, 108);
			this.tbOutput.TabIndex = 8;
			this.tbOutput.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textbox_KeyUp);
			// 
			// label4
			// 
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(4, 348);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(42, 13);
			this.label4.TabIndex = 15;
			this.label4.Text = "Output:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(12, 76);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(77, 13);
			this.label2.TabIndex = 5;
			this.label2.Text = "Command text:";
			// 
			// tbCommandText
			// 
			this.tbCommandText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbCommandText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbCommandText.Location = new System.Drawing.Point(24, 92);
			this.tbCommandText.Multiline = true;
			this.tbCommandText.Name = "tbCommandText";
			this.tbCommandText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbCommandText.Size = new System.Drawing.Size(636, 112);
			this.tbCommandText.TabIndex = 1;
			this.tbCommandText.Text = "SELECT [FileType], [FileName], [FileExt], [FileData_VARBINARY]\r\nFROM [FileTable]";
			this.tbCommandText.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textbox_KeyUp);
			// 
			// tbConnectionString
			// 
			this.tbConnectionString.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbConnectionString.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbConnectionString.Location = new System.Drawing.Point(24, 40);
			this.tbConnectionString.Multiline = true;
			this.tbConnectionString.Name = "tbConnectionString";
			this.tbConnectionString.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbConnectionString.Size = new System.Drawing.Size(636, 32);
			this.tbConnectionString.TabIndex = 0;
			this.tbConnectionString.Text = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=Tru" +
    "e;Persist Security Info=False;\r\n";
			this.tbConnectionString.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textbox_KeyUp);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(8, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(91, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "ConnectionString:";
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.tbConnectionString);
			this.groupBox1.Controls.Add(this.tbCommandText);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox1.Location = new System.Drawing.Point(0, 4);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(668, 204);
			this.groupBox1.TabIndex = 17;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "1) Craft your SQL query:";
			// 
			// tbFilepathMask
			// 
			this.tbFilepathMask.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbFilepathMask.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbFilepathMask.Location = new System.Drawing.Point(24, 39);
			this.tbFilepathMask.Name = "tbFilepathMask";
			this.tbFilepathMask.Size = new System.Drawing.Size(372, 20);
			this.tbFilepathMask.TabIndex = 16;
			this.tbFilepathMask.Text = "C:\\Temp\\{0}\\{1}.{2}";
			this.tbFilepathMask.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textbox_KeyUp);
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(8, 24);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(75, 13);
			this.label3.TabIndex = 6;
			this.label3.Text = "Save file path:";
			// 
			// label6
			// 
			this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(8, 64);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(173, 13);
			this.label6.TabIndex = 17;
			this.label6.Text = "Column name or index of binary file:";
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.numFileDataIndex);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.tbFilepathMask);
			this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox2.Location = new System.Drawing.Point(4, 216);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(672, 100);
			this.groupBox2.TabIndex = 18;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "2) Choose your output naming pattern:";
			// 
			// numFileDataIndex
			// 
			this.numFileDataIndex.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.numFileDataIndex.Location = new System.Drawing.Point(24, 80);
			this.numFileDataIndex.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.numFileDataIndex.Name = "numFileDataIndex";
			this.numFileDataIndex.Size = new System.Drawing.Size(80, 20);
			this.numFileDataIndex.TabIndex = 19;
			this.numFileDataIndex.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(670, 473);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.tbOutput);
			this.Controls.Add(this.btnExecuteQuery);
			this.MinimumSize = new System.Drawing.Size(686, 511);
			this.Name = "MainForm";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
			this.Text = "SqlFileStream 2 File System";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			this.Shown += new System.EventHandler(this.MainForm_Shown);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numFileDataIndex)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button btnExecuteQuery;
		private System.Windows.Forms.TextBox tbOutput;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox tbCommandText;
		private System.Windows.Forms.TextBox tbConnectionString;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox tbFilepathMask;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.NumericUpDown numFileDataIndex;
	}
}

