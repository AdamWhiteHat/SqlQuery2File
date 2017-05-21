using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlFileClient
{
	public class ColumnSchema
	{
		public int Ordinal { get; private set; }
		public string Name { get; private set; }
		public string Type { get; private set; }
		public static readonly ColumnSchema Empty = new ColumnSchema(-1, string.Empty, string.Empty);

		public ColumnSchema(int ordinal, string name, string type)
		{
			Ordinal = ordinal;
			Name = name;
			Type = type;
		}
	}
}
