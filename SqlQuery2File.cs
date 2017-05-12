using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace SqlFileClient
{
	public static class SqlQuery2File
	{
		public static string GenerateFilename(string myFileName, int appendName, bool boolConflict)
		{
			if (myFileName.Contains("/"))
			{
				myFileName = myFileName.Substring(myFileName.LastIndexOf("/") + 1);
			}

			string returnName = "";
			if (appendName == 1)
			{
				returnName = System.Guid.NewGuid().ToString() + "_" + myFileName;
			}
			else if (appendName == -1)
			{
				returnName = System.Guid.NewGuid().ToString();
			}
			else if (appendName == 2 && boolConflict == false)
			{
				returnName = myFileName;
			}
			else
			{
				returnName = myFileName + "_" + System.Guid.NewGuid().ToString();
			}
			return returnName;
		}

		public static string GetSqlFile(string connectionString, string commandText, string outDirectory, bool useColumnValueForName, int appendName)
		{
			SqlConnection sqlConnection = null;

			try
			{
				sqlConnection = new SqlConnection(connectionString);

				SqlCommand sqlCommand = new SqlCommand();
				sqlCommand.Connection = sqlConnection;
				sqlCommand.CommandText = commandText;
				sqlCommand.CommandTimeout = 0;
				sqlConnection.Open();

				FileStream fs;
				BinaryWriter bw;

				int bufferSize = 2000;
				byte[] outbyte = new byte[bufferSize];
				long retval;
				long startIndex = 0;


				SqlDataReader reader = sqlCommand.ExecuteReader(CommandBehavior.SequentialAccess);
				while (reader.Read())
				{
					string fName = "";
					// Get filename
					if (useColumnValueForName)
					{
						object tmpFname = reader.GetValue(0);
						fName = tmpFname.ToString();
						if (fName.Length > 200)
						{
							fName = "";
						}
					}

					// Get output path
					string fPath = Path.Combine(outDirectory, GenerateFilename(fName, appendName, false));
					// while exists
					while (File.Exists(fPath) == true)
					{
						fPath = Path.Combine(outDirectory, GenerateFilename(fName, appendName, true));
					}

					// Create a file to write the output to
					fs = new FileStream(fPath, FileMode.OpenOrCreate, FileAccess.Write);
					bw = new BinaryWriter(fs);

					// Reset the starting byte for the new BLOB.
					startIndex = 0;

					// Read the bytes into outbyte[] and retain the number of bytes returned.
					retval = reader.GetBytes(1, startIndex, outbyte, 0, bufferSize);

					// Continue reading and writing while there are bytes beyond the size of the buffer.
					while (retval == bufferSize)
					{
						bw.Write(outbyte);
						bw.Flush();

						// Reposition the start index to the end of the last buffer and fill the buffer.
						startIndex += bufferSize;
						retval = reader.GetBytes(1, startIndex, outbyte, 0, bufferSize);
					}

					// Write the remaining buffer.
					if (retval > 0) // if file size can divide to buffer size
					{
						bw.Write(outbyte, 0, (int)retval - 1);
					}
					bw.Flush();

					// Close the output file.
					bw.Close();
					fs.Close();
				}

				return $"Success: {outDirectory}";
			}
			catch (System.Exception ex)
			{
				return ex.ToString();
			}
			finally
			{
				if (sqlConnection != null)
				{
					sqlConnection.Close();
					sqlConnection.Dispose();
				}
			}
		}
	}
}
