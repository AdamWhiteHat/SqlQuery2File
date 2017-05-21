using System;
using System.IO;
using System.Xml;
using System.Text;
using System.Linq;
using System.Data;
using System.Data.Sql;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Data.Linq.SqlClient;
using System.Data.Linq.SqlClient.Implementation;
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

		private static string ReplaceTokens(string pattern, List<string> tokenValues)
		{
			int tokenIndex = 0;
			StringBuilder result = new StringBuilder(pattern);
			foreach (string replaceValue in tokenValues)
			{
				//result = // will save an assignment step if we can avoid this
				result.Replace($"{{{tokenIndex}}}", replaceValue);
				tokenIndex++;
			}
			return result.ToString();
		}

		public static string GetSqlFile(string connectionString, string commandText, string filenameMask, int binaryDataColumnIndex)
		{
			int filesWritten = 0;
			List<string> failedFiles = new List<string>();

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
						using (SqlDataReader dataReader = sqlCommand.ExecuteReader(CommandBehavior.SequentialAccess))
						{
							if (dataReader == null)
							{
								return "SqlCommand.ExecuteReader() returned a null SqlDataReader? That should not have been possible. Aborting..." + Environment.NewLine;
							}
							else if (!dataReader.HasRows)
							{
								return "Query failed to return any rows." + Environment.NewLine;
							}
							else if (dataReader.FieldCount < 1)
							{
								return "Query failed to return any columns." + Environment.NewLine;
							}

							while (dataReader.Read()) // Gets next ROW
							{
								object[] rawColumns = new object[dataReader.FieldCount];
								int colCount = dataReader.GetValues(rawColumns);

								List<object> cells = rawColumns.ToList();
								rawColumns = null; // Tidy up

								object fileData = cells[binaryDataColumnIndex]; // Save the column containing the file data
								cells.RemoveAt(binaryDataColumnIndex); // Remove the file data column from the list
								cells.Insert(binaryDataColumnIndex, (object)string.Empty); // Re-add the column  with empty string at the same position, so columns after that position are not shifted an position index of -1

								List<string> columnsAsStrings = cells.Select(obj => DBNull.Value != obj ? ((string)obj) : string.Empty).ToList(); // Convert rest of columns to strings								
								cells.Clear(); // Tidy up

								string customFilename = ReplaceTokens(filenameMask, columnsAsStrings);
								columnsAsStrings.Clear(); // Tidy up

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
								//else if (fileData is XElement)
								//{
								//	XElement xml = (XElement)fileData;
								//	xml.Save(outFilename);
								//	xml = null;
								//}
								else // What about , xml, sql_variant
								{
									return $"Unexpected data type encountered while reading cells from SQL query results: \"{fileData.GetType()}\".";
								}

								fileData = null; // Tidy up

								if (!File.Exists(outFilename))
								{
									failedFiles.Add(outFilename);
								}

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

			string resultMessage = string.Empty;






			if (filesWritten > 0)
			{
				resultMessage += $"Finished! \nWrote a total of {filesWritten} file(s) out to disk.";
			}

			return resultMessage;
		}
	}
}
