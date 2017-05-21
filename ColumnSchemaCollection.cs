using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace SqlFileClient
{
	public class ColumnSchemaCollection
	{
		public List<string> Names { get { return _internalList.Select(s => s.Name).ToList(); } }
		public List<string> Types { get { return _internalList.Select(s => s.Type).ToList(); } }
		public int Count { get { return _internalList.Count; } }

		private List<ColumnSchema> _internalList = new List<ColumnSchema>();

		public ColumnSchemaCollection()
		{
			_internalList = new List<ColumnSchema>();
		}
		public ColumnSchemaCollection(List<ColumnSchema> list)
		{
			_internalList = list ?? new List<ColumnSchema>();
		}

		public void Add(ColumnSchema columnSchema)
		{
			_internalList.Add(columnSchema);
		}

		public List<ColumnSchema>.Enumerator GetEnumerator()
		{
			return _internalList.GetEnumerator();
		}

		public ColumnSchema this[int index] { get { return _internalList[index]; } }
		public ColumnSchema this[string name]
		{
			get
			{
				IEnumerable<ColumnSchema> nameMatches = _internalList.Where(csi => csi.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase));
				return nameMatches.Any() ? nameMatches.First() : ColumnSchema.Empty;
			}
		}


		public static string ReplaceTokens(string pattern, ColumnSchemaCollection columnSchemas, List<string> tokenValues)
		{
			StringBuilder result = new StringBuilder(pattern);
			foreach (ColumnSchema column in columnSchemas)
			{
				result.Replace($"{{{column.Ordinal}}}", tokenValues[column.Ordinal]);
				result.Replace($"{{{column.Name}}}", tokenValues[column.Ordinal]);
			}
			return result.ToString();
		}

		public static ColumnSchemaCollection GetTableSchema(string commandText, string connectionString)
		{
			DataTable schemaTable = new DataTable();

			using (SqlConnection sqlConnection = new SqlConnection(connectionString))
			{
				using (SqlCommand sqlCommand = new SqlCommand())
				{
					sqlCommand.Connection = sqlConnection;
					sqlCommand.CommandText = commandText;
					sqlCommand.CommandTimeout = 0;
					sqlConnection.Open();

					using (SqlDataReader dataReader = sqlCommand.ExecuteReader(CommandBehavior.SchemaOnly))
					{
						schemaTable = dataReader.GetSchemaTable();
					}
				}
			}

			if (schemaTable == null || schemaTable.Columns.Count == 0 || schemaTable.Rows.Count == 0)
			{
				throw new Exception("SqlDataReader returned an empty schema table!");
			}

			ColumnSchemaCollection result = new ColumnSchemaCollection();
			foreach (DataRow row in schemaTable.Rows)
			{
				int ordinal = (int)row[SchemaTableColumn.ColumnOrdinal];

				ColumnSchema columnInfo =
					new ColumnSchema(
						ordinal,
						 row[SchemaTableColumn.ColumnName].ToString(),
						 row[SchemaTableColumn.DataType].ToString()
					);

				result.Add(columnInfo);
			}
			return result;
		}
	}
}
