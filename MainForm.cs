using System;
using System.IO;
using System.Data;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Threading;

namespace SqlFileClient
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		private void btnExecuteQuery_Click(object sender, EventArgs e)
		{
			ExecuteQuery();
		}

		private void textbox_KeyUp(object sender, KeyEventArgs e)
		{
			TextBox eventTextBox = (TextBox)sender;

			if (e.Control && e.KeyCode == Keys.A)
			{
				eventTextBox.SelectAll();
			}
			else if (e.KeyCode == Keys.F5 && btnExecuteQuery.Enabled)
			{
				ExecuteQuery();
			}
		}

		private void ExecuteQuery()
		{
			string connectionString = tbConnectionString.Text;
			string commandText = tbCommandText.Text;

			string outFilepath = tbFilepathMask.Text;
			string binaryColumnName = tbVarBinaryColumn.Text;

			SetControlsEnabled(false);

			// Launch long running SQL query on a different thread than the UI thread
			new Thread(() =>
			{
				string result = SqlQuery2File.GetSqlFile(connectionString, commandText, outFilepath, binaryColumnName);
				SetControlsEnabled(true, result);
			}
			).Start();
		}

		private void SetControlsEnabled(bool enabled, string outputText = "")
		{
			if (btnExecuteQuery.InvokeRequired) // If called from NOT the UI thread, switch to UI thread
			{
				btnExecuteQuery.Invoke(new MethodInvoker(() => SetControlsEnabled(enabled, outputText)));
			}
			else
			{
				groupBox1.Enabled = enabled;
				groupBox2.Enabled = enabled;
				btnExecuteQuery.Enabled = enabled;
				if (!string.IsNullOrWhiteSpace(outputText))
				{
					tbOutput.Text = outputText;
				}
			}
		}
	}
}
