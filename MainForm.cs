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
			using (SaveFileDialog saveDialog = new SaveFileDialog())
			{
				saveDialog.CheckFileExists = false;
				saveDialog.CheckPathExists = true;
				saveDialog.InitialDirectory = lastDirectory;
				if (saveDialog.ShowDialog() == DialogResult.OK)
				{
					tbFilename.Text = saveDialog.FileName;
					lastDirectory = Path.GetFullPath(saveDialog.FileName);
				}
			}
		}

		private void btnExecuteQuery_Click(object sender, EventArgs e)
		{
			string outFilename = tbFilename.Text;
			string connectionString = tbConnectionString.Text;
			string commandText = tbCommandText.Text;

			string result = SqlQuery2File.GetSqlFile(connectionString, commandText, outFilename);

			tbOutput.Text = result;
		}
	}
}
