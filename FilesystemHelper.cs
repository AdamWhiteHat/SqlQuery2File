using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;

namespace SqlFileClient
{
	public class FilesystemHelper
	{
		public static string CollisionFreeFilename(string preferedPathAndFilename)
		{
			string inputFullFilePath = preferedPathAndFilename;

			string inFilename = Path.GetFileNameWithoutExtension(inputFullFilePath);
			string inExtension = Path.GetExtension(inputFullFilePath);
			string inPath = Path.GetDirectoryName(inputFullFilePath);

			// Create directory tree if not exists
			DirectoryInfo dirInfo = new DirectoryInfo(inPath);
			if (!dirInfo.Exists)
			{
				dirInfo = Directory.CreateDirectory(inPath);
			}
			inPath = dirInfo.FullName;

			// Default, GUID-based filename
			string result = inputFullFilePath;
			if (string.IsNullOrWhiteSpace(inputFullFilePath))
			{
				inFilename = Guid.NewGuid().ToString(); // "00000000-0000-0000-0000-000000000000"
				result = Path.ChangeExtension(inFilename, "file"); // "00000000-0000-0000-0000-000000000000.file"
				result = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, result); // "C:\Path\00000000-0000-0000-0000-000000000000.file"		
			}

			while (File.Exists(result))
			{
				result = $"{inFilename}__({counter})"; // "Filename__(001)"
				result = Path.ChangeExtension(result, inExtension); // "Filename__(001).ext"
				result = Path.Combine(inPath, result);  // "C:\Path\Filename__(001).ext"
			}

			return result;
		}

		private static Counter counter = new Counter();
		private class Counter
		{
			public Counter(int startValue = 1)
			{
				counter = startValue;
			}

			private int counter;
			private static string counterFormatString = "{0:000}";

			public override string ToString()
			{
				return string.Format(counterFormatString, counter++);
			}
		}

		/*
		private static string lastDirectory = "C:\\Temp";
		public static string BrowseForFolder()
		{
			string result = "";
			using (FolderBrowserDialog browseDialog = new FolderBrowserDialog())
			{
				browseDialog.ShowNewFolderButton = true;
				browseDialog.SelectedPath = lastDirectory;
				if (browseDialog.ShowDialog() == DialogResult.OK)
				{
					lastDirectory = browseDialog.SelectedPath;
					result = browseDialog.SelectedPath;
				}
			}
			return result;
		}
		*/
	}
}
