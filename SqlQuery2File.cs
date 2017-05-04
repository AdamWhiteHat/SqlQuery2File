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
		public static string GetSqlFile(string connectionString, string commandText, string outDirectory)
		{
			SqlConnection sqlConnection = null;

			try
			{
				sqlConnection = new SqlConnection(connectionString);

				SqlCommand sqlCommand = new SqlCommand();
				sqlCommand.Connection = sqlConnection;
				sqlCommand.CommandText = commandText;
				sqlConnection.Open();

				FileStream fs;                          // Writes the BLOB to a file (*.bmp).
				BinaryWriter bw;                        // Streams the BLOB to the FileStream object.

				int bufferSize = 2000;                // Size of the BLOB buffer.
				byte[] outbyte = new byte[bufferSize];  // The BLOB byte[] buffer to be filled by GetBytes.
				long retval;                            // The bytes returned from GetBytes.
				long startIndex = 0;                    // The starting position in the BLOB output.

				string pub_id = "";                     // The publisher id to use in the file name.

				SqlDataReader reader = sqlCommand.ExecuteReader(CommandBehavior.SequentialAccess);
				while (reader.Read())
				{
					// Get the publisher id, which must occur before getting the logo.

					// Create a file to hold the output.
					fs = new FileStream(Path.Combine(outDirectory, Path.GetFileName(Path.GetTempFileName())), FileMode.OpenOrCreate, FileAccess.Write);
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
