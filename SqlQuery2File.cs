using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Data;
using System.Threading;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace SqlFileClient
{
	public static class SqlQuery2File
	{
		private static string RemoveWhitespace(string input)
		{
			return new string(input.Where(c => !char.IsWhiteSpace(c)).ToArray());
		}

		private static string StringReplaceColumnIndexTokens(DataTable table, string tokenString)
		{
			string result = tokenString;
			foreach (int col in Enumerable.Range(0, table.Columns.Count))
			{

				result = result.Replace($"{{{col}}}", table.Columns[col].ColumnName);
			}
			return RemoveWhitespace(result).Replace("{", "").Replace("}", "");
		}

		public static string GetSqlFile(string connectionString, string commandText, string filenameMask, string binaryDataColumnName)
		{
			DataTable dataTableResult = new DataTable();

			try
			{
				using (SqlConnection sqlConnection = new SqlConnection(connectionString))
				{
					using (SqlCommand sqlCommand = new SqlCommand())
					{
						sqlCommand.Connection = sqlConnection;
						sqlCommand.CommandText = commandText;
						sqlCommand.CommandTimeout = 0;
						sqlConnection.Open();

						// Generally this will throw an exception if there is anything wrong
						using (SqlDataReader reader = sqlCommand.ExecuteReader(CommandBehavior.SequentialAccess))
						{
							if(reader == null)
							{
								return "Query return a null SqlDataReader? Aborting..." + Environment.NewLine;
							}
							else if (!reader.HasRows )
							{
								return "Query failed to return any rows." + Environment.NewLine;
							}
							else if (reader.FieldCount < 1)
							{
								return "Query failed to return any columns." + Environment.NewLine;
							}

							dataTableResult.Load(reader, LoadOption.OverwriteChanges); // Store SQL Query results in a DataTable class
						}
					}
				}
			}
			catch (Exception ex)
			{
				return ex.ToString();
			}


			string fileDataColumnName = binaryDataColumnName;
			if (!string.IsNullOrWhiteSpace(fileDataColumnName))
			{
				fileDataColumnName = StringReplaceColumnIndexTokens(dataTableResult, fileDataColumnName);
			}

			try
			{
				string resultMessage = $"Query returned '{dataTableResult.Columns.Count}' columns and '{dataTableResult.Rows.Count}' rows." + Environment.NewLine;

				int filesWritten = 0;
				long bytesWritten = 0;

				// For each row returned by query...
				foreach (DataRow currentRow in dataTableResult.Rows)
				{
					IEnumerable<DataColumn> dataColumns =
						dataTableResult.Columns.Cast<DataColumn>()
						.Where(col =>
							col.ColumnName != fileDataColumnName
							&&
							!currentRow.IsNull(col.Ordinal)
						);

					// Create a Tuple that holds: <SearchToken,ReplaceValue>
					IEnumerable<Tuple<string, string>> columnsReplacements =
						dataColumns.SelectMany(col =>
						{
							string replaceValue = currentRow[col].ToString();
							return new Tuple<string, string>[]
							{
								new Tuple<string, string>($"{{{col.Ordinal}}}", replaceValue),
								new Tuple<string, string>($"{{{col.ColumnName.ToLowerInvariant()}}}", replaceValue)
							};
						});

					string filePattern = filenameMask.ToLowerInvariant(); // Case insensitive
					foreach (Tuple<string, string> tup in columnsReplacements)
					{
						// Replace file pattern masks with the values from matching column names
						filePattern = filePattern.Replace(tup.Item1, tup.Item2);
					}

					// Returns a unique, non-existent file path
					string outputFilepath = FilesystemHelper.CollisionFreeFilename(filePattern);

					var dataColumn = dataTableResult.Columns[fileDataColumnName];
					Type dataType = dataColumn.DataType;
					string dataTypeString = dataType.ToString();

					int byteLength = 0;

					//SqlDbType.Char / SqlDbType.NChar / SqlDbType.VarChar / SqlDbType.NVarChar
					//SqlDbType.Binary / SqlDbType.VarBinary / SqlDbType.Image
					//SqlDbType.BigInt/ SqlDbType.Int / SqlDbType.SmallInt / SqlDbType.TinyInt / SqlDbType.Byte
					//SqlDbType.Real / SqlDbType.Float / SqlDbType.Decimal
					//SqlDbType.Money / SqlDbType.SmallMoney
					//SqlDbType.Text / SqlDbType.NText
					//SqlDbType.Xml

					if (dataType == typeof(byte[]))
					{
						byte[] fileBytes = currentRow[fileDataColumnName] as byte[]; // Get varbinary column file data  as bytes
						byteLength = fileBytes.Length;

						File.WriteAllBytes(outputFilepath, fileBytes); // Write bytes out to file
						fileBytes = new byte[0]; // Clear byte array, as it can be large
					}
					else// if (dataType == typeof(string))
					{
						string fileText = currentRow[fileDataColumnName].ToString(); // as string; // Get varchar, nvarchar or string column data  as string						
						byteLength = Encoding.UTF8.GetByteCount(fileText); // fileText.Length;

						File.WriteAllText(outputFilepath, fileText); // Write text string out to file
					}

					FileInfo writtenFileInfo = new FileInfo(outputFilepath);
					if (!writtenFileInfo.Exists || writtenFileInfo.Length != byteLength) // Check if file exists, is of expected length
					{
						return resultMessage + $"Failed to write the {byteLength} byte file: \"{outputFilepath}\"." + Environment.NewLine + "Aborted." + Environment.NewLine;
					}

					filesWritten++; // Increment file count
					bytesWritten += byteLength; // Increment total bytes written
				}

				if (filesWritten > 0)
				{
					resultMessage += $"Wrote {filesWritten} file(s) ({bytesWritten} bytes) out to disk." + Environment.NewLine;
				}

				return resultMessage;
			}
			catch (Exception ex)
			{
				return ex.ToString(); // Display error
			}
		}
	}
}
