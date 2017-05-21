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
			if (string.IsNullOrWhiteSpace(preferedPathAndFilename))
			{
				return // Return  Default, GUID-based filename
					Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
						Path.ChangeExtension(Guid.NewGuid().ToString(), "file") // "00000000-0000-0000-0000-000000000000.file"
					);
			}

			string inPath = Path.GetDirectoryName(preferedPathAndFilename);

			// Create directory tree if not exists
			if (!Directory.Exists(inPath))
			{
				Directory.CreateDirectory(inPath);
				return preferedPathAndFilename; // If the directory didn't exist, then neither can have the file; return immediately.
			}

			// Detect if there is a filename collision
			if (!File.Exists(preferedPathAndFilename))
			{
				return preferedPathAndFilename; // Return immediately if there is no collision
			}

			// else ... Append a count to the filename if it already exists, like: filename__001.ext

			string result = preferedPathAndFilename;
			string inFilename = Path.GetFileNameWithoutExtension(result);
			string inExtension = Path.GetExtension(result);

			// Actually, if we don't reset the counter, it will be more performant for repeated collisions of the same file,
			// however for one or a few collisions per file, the number appended will be stratified across all files causing a collision.
			// counter.Reset() 

			do // do ... while instead of while because we already know there is a collision before first iteration
			{
				result = $"{inFilename}__({counter})"; // "Filename__(001)"
				result = Path.ChangeExtension(result, inExtension); // "Filename__(001).ext"
				result = Path.Combine(inPath, result);  // "C:\Path\Filename__(001).ext"
			}
			while (File.Exists(result)); // in case we have already done this before. deja vu

			return result;
		}

		private static Counter counter = new Counter();


		private class Counter
		{			
			private int _count; //public int Count { get { return _count; } }

			public Counter(int startValue = 1) { _count = startValue; }

			//public void Reset() { _count = 1; }
			public override string ToString()
			{
				return string.Format(counterFormatString, _count++);
			}
			private static string counterFormatString = "{0:000}";
		}
	}
}
