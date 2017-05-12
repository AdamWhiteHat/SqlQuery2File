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

namespace SqlFileClient
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		private string lastDirectory = "C:\\Temp";
		private void btnBrowse_Click(object sender, EventArgs e)
		{
			using (FolderBrowserDialog browseDialog = new FolderBrowserDialog())
			{
				browseDialog.ShowNewFolderButton = true;
				browseDialog.SelectedPath = lastDirectory;
				if (browseDialog.ShowDialog() == DialogResult.OK)
				{
					tbFolderPath.Text = browseDialog.SelectedPath;
					lastDirectory = browseDialog.SelectedPath;
				}
			}
		}

		private void chkBoxNameFromColumn_CheckedChanged(object sender, EventArgs e)
		{
			bool enabled = chkBoxNameFromColumn.Checked;
			radioBtnName1.Enabled = enabled;
			radioBtnName2.Enabled = enabled;
			radioBtnName3.Enabled = enabled;
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
			string outFilename = tbFolderPath.Text;
			string connectionString = tbConnectionString.Text;
			string commandText = tbCommandText.Text;

			int passValue = -1;
			if (radioBtnName1.Checked == true)
			{
				passValue = 0;
			}
			else if (radioBtnName2.Checked == true)
			{
				passValue = 1;
			}
			else if (radioBtnName3.Checked == true)
			{
				passValue = 2;
			}

			btnExecuteQuery.Enabled = false;

			string result = SqlQuery2File.GetSqlFile(connectionString, commandText, outFilename, chkBoxNameFromColumn.Checked, passValue);
			tbOutput.Text = result;

			btnExecuteQuery.Enabled = true;
		}
	}
}
