using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace SqlFileClient
{
	public static class SqlQuery2File
	{
		private static string FileDataColumnArgumentErrorMessage = "FAILED: Unable to parse the 'File Data' column specifier as a index or a column name." + Environment.NewLine + "Value passed: '{0}'.";
		private static string ArgumentMissingErrorMessage = "Parameter '{0}' must not be null, empty or whitespace.";
		public static string GetSqlFile(string connectionString, string commandText, string filenameMask, string fileDataColumn)
		{
			if (string.IsNullOrWhiteSpace(connectionString))
			{
				return string.Format(ArgumentMissingErrorMessage, "ConnectionString");
			}
			else if (string.IsNullOrWhiteSpace(commandText))
			{
				return string.Format(ArgumentMissingErrorMessage, "Command Text");
			}
			else if (string.IsNullOrWhiteSpace(filenameMask))
			{
				return string.Format(ArgumentMissingErrorMessage, "Filename Mask");
			}
			else if (string.IsNullOrWhiteSpace(fileDataColumn))
			{
				return string.Format(ArgumentMissingErrorMessage, "File Data Column");
			}

			int filesWritten = 0;
			int fileDataColumnIndex = -1;
			string fileDataColumnName = string.Empty;
			List<string> failedFiles = new List<string>();
			ColumnSchemaCollection rowSchema;

			try
			{
				rowSchema = ColumnSchemaCollection.GetTableSchema(commandText, connectionString);

				string columnIdentifier = fileDataColumn.Replace("{", "").Replace("}", "").Trim();

				fileDataColumnIndex = -1;

				if (columnIdentifier.All(c => char.IsDigit(c)))
				{
					fileDataColumnIndex = int.Parse(columnIdentifier);
				}
				else
				{
					ColumnSchema dataColumnInfo = rowSchema[columnIdentifier];

					if (dataColumnInfo == ColumnSchema.Empty)
					{
						return string.Format(FileDataColumnArgumentErrorMessage, columnIdentifier);
					}

					fileDataColumnIndex = dataColumnInfo.Ordinal;
				}

				using (SqlConnection sqlConnection = new SqlConnection(connectionString))
				{
					using (SqlCommand sqlCommand = new SqlCommand())
					{
						sqlCommand.Connection = sqlConnection;
						sqlCommand.CommandText = commandText;
						sqlCommand.CommandTimeout = 0;
						sqlConnection.Open();

						// Generally this will throw an exception if there is anything wrong
						using (SqlDataReader dataReader = sqlCommand.ExecuteReader(CommandBehavior.SequentialAccess))
						{
							if (dataReader == null)
							{
								return "SqlCommand.ExecuteReader() returned a null SqlDataReader? That should not have been possible. Aborting...";
							}
							else if (!dataReader.HasRows)
							{
								return "Query failed to return any rows.";
							}
							else if (dataReader.FieldCount < 1)
							{
								return "Query failed to return any columns.";
							}

							int rowCount = 1;
							while (dataReader.Read()) // Gets next ROW
							{
								object[] rawColumns = new object[dataReader.FieldCount];
								int colCount = dataReader.GetValues(rawColumns);

								List<object> cells = rawColumns.ToList();
								rawColumns = null; // Tidy up

								object fileData = cells[fileDataColumnIndex]; // Save the column containing the file data
								cells.RemoveAt(fileDataColumnIndex); // Remove the file data column from the list
								cells.Insert(fileDataColumnIndex, (object)string.Empty); // Re-add the column  with empty string at the same position, so columns after that position are not shifted an position index of -1

								List<string> columnValueStrings = cells.Select(obj => DBNull.Value != obj ? obj.ToString() : string.Empty).ToList(); // Convert rest of columns to strings
								cells.Clear(); // Tidy up

								string customFilename = ColumnSchemaCollection.ReplaceTokens(filenameMask, rowSchema, columnValueStrings);
								columnValueStrings.Clear(); // Tidy up

								string outFilename = FilesystemHelper.CollisionFreeFilename(customFilename);

								if (fileData is byte[]) // binary, varbinary & image (as well as timestamp, rowversion & FILESTREAM )
								{
									File.WriteAllBytes(outFilename, (byte[])fileData);
								}
								else if (fileData is string) // char, nchar, varchar, nvarchar, text & ntext
								{
									File.WriteAllText(outFilename, (string)fileData);
								}
								else if (fileData is char[]) //  char, nchar, varchar, nvarchar, text & ntext
								{
									File.WriteAllText(outFilename, new string((char[])fileData));
								}
								else if (DBNull.Value == fileData)
								{
									continue;
								}
								else // What about xml, sql_variant, others?
								{
									return $"Unexpected data type encountered while reading cells from SQL query results: '{fileData.GetType()}'."
										+ $"FAILED AT ROW # {rowCount}";
								}

								fileData = null; // Tidy up

								if (!File.Exists(outFilename))
								{
									failedFiles.Add(outFilename);
								}

								rowCount++;
								filesWritten++;
							}
						} /* END: using(SqlDataReader) { ... */
					} /* END: using(SqlCommandn) { ... */
				} /* END: using(SqlConnection) { ... */
			}
			catch (Exception ex)
			{
				return ex.ToString();
			}

			StringBuilder resultMessage = new StringBuilder();

			if (filesWritten > 0)
			{
				resultMessage.AppendLine($"Finished!");
				resultMessage.AppendLine($"Wrote a total of {filesWritten} file(s) out to disk.");
			}

			if (failedFiles.Any())
			{
				resultMessage.AppendLine($"Failed to write some files:");
				resultMessage.AppendLine(string.Join(Environment.NewLine + "\tFAILED:\t ", failedFiles));
			}

			return resultMessage.ToString();
		}
	}
}
