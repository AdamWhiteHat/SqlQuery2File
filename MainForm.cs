using System;
using System.IO;
using System.Drawing;
using System.Xml.Linq;
using System.Threading;
using System.Collections;
using System.Windows.Forms;

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
			string outputFilepath = tbFilepathMask.Text;
			string filedataColumnName = tbFileDataColumn.Text;
			//int fileData_Index = (int)numFileDataIndex.Value;


			SetControlsEnabled(false);

			// Launch long running SQL query on a different thread than the UI thread
			new Thread(() =>
			{
				string result = SqlQuery2File.GetSqlFile(connectionString, commandText, outputFilepath, filedataColumnName);
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

		private static string lastValuesFilenames = "lastValues.save";

		private void MainForm_Shown(object sender, EventArgs e)
		{
			if (File.Exists(lastValuesFilenames))
			{
				XDocument xDoc = XDocument.Load(lastValuesFilenames, LoadOptions.None);
				//XDocument xdoc = XDocument.Parse(lastValuesFilenames, LoadOptions.PreserveWhitespace);

				XElement xRoot = xDoc.Root;

				string connectionString = xRoot.Element("ConnectionString").Value;
				string commandText = xRoot.Element("CommandText").Value;
				string outputFilepath = xRoot.Element("OutputFilepath").Value;
				string fileDataColumn = xRoot.Element("FileDataColumn").Value.Trim();

				if (!string.IsNullOrWhiteSpace(commandText))
				{
					commandText = commandText.Replace("\n", Environment.NewLine);
				}

				tbConnectionString.Text = connectionString;
				tbCommandText.Text = commandText;
				tbFilepathMask.Text = outputFilepath;
				tbFileDataColumn.Text = fileDataColumn;
			}
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			string connectionString = tbConnectionString.Text;
			string commandText = tbCommandText.Text;
			string outputFilepath = tbFilepathMask.Text;
			string fileDataColumn = tbFileDataColumn.Text;

			XElement xRoot =
				new XElement("root",
					new XElement("ConnectionString", connectionString),
					new XElement("CommandText", commandText),
					new XElement("OutputFilepath", outputFilepath),
					new XElement("FileDataColumn", fileDataColumn)
				);

			XDocument xDoc = new XDocument();
			xDoc.Add(xRoot);

			//xDoc.Save(lastValuesFilenames, SaveOptions.DisableFormatting);
			File.WriteAllText(lastValuesFilenames, xDoc.ToString(SaveOptions.DisableFormatting));
		}

		private void tbCommandText_TextChanged(object sender, EventArgs e)
		{

		}
	}
}
