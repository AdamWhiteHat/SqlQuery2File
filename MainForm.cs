using System;
using System.IO;
using System.Xml;
using System.Data;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Xml.Linq;
using System.Threading;
using System.Collections;
using System.Windows.Forms;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;

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
			string FiledataColumnName = tbVarBinaryColumn.Text;

			SetControlsEnabled(false);

			// Launch long running SQL query on a different thread than the UI thread
			new Thread(() =>
			{
				string result = SqlQuery2File.GetSqlFile(connectionString, commandText, outputFilepath, FiledataColumnName);
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
				XDocument doc = XDocument.Load(lastValuesFilenames, LoadOptions.PreserveWhitespace);
				string connectionString = doc.Root.Element("ConnectionString").Value;
				string commandText = doc.Root.Element("CommandText").Value;
				string outputFilepath = doc.Root.Element("OutputFilepath").Value;
				string FiledataColumnName = doc.Root.Element("FiledataColumnName").Value;

				tbConnectionString.Text = connectionString;
				tbCommandText.Text = commandText;
				tbFilepathMask.Text = outputFilepath;
				tbVarBinaryColumn.Text = FiledataColumnName;
			}
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			string connectionString = tbConnectionString.Text;
			string commandText = tbCommandText.Text;
			string outputFilepath = tbFilepathMask.Text;
			string FiledataColumnName = tbVarBinaryColumn.Text;

			XDocument doc = new XDocument(
				new XElement("Save",
					new XElement("ConnectionString", connectionString),
					new XElement("CommandText", commandText),
					new XElement("OutputFilepath", outputFilepath),
					new XElement("FiledataColumnName", FiledataColumnName)
				)
			);

			doc.Save(lastValuesFilenames, SaveOptions.DisableFormatting);
		}
	}
}
