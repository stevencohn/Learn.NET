//************************************************************************************************
// Copyright © 2013 Steven M Cohn. All Rights Reserved.
//
//************************************************************************************************

namespace CrashLab
{
	using System;
	using System.Diagnostics;
	using System.Linq;
	using System.Text;
	using System.Windows.Forms;
	using System.Xml.Linq;


	/// <summary>
	/// Report performance information for this process
	/// </summary>

	internal sealed class PerfReporter
	{
		private static bool initializing = true;


		private string procName;
		private IHost host;


		/// <summary>
		/// 
		/// </summary>
		/// <param name="host"></param>

		public PerfReporter (IHost host)
		{
			this.host = host;
			this.procName = Process.GetCurrentProcess().ProcessName;
		}


		/// <summary>
		/// Purposely runs on the UI thread so we don't create an extra thread that would
		/// need to be accounted for in the report.
		/// </summary>

		public void Report ()
		{
			var form = host as Form;
			form.Cursor = System.Windows.Forms.Cursors.WaitCursor;

			host.Log(String.Empty);
			host.Log("PERFORMANCE REPORT");

			if (initializing)
			{
				host.Log("One moment while WMI assemblies are loaded...");
				initializing = false;
			}

			var root = XElement.Parse(Properties.Resources.PerfCounters);

			int labelMax =
				(from e in root.Elements()
				 select e.Attribute("name").Value.Length).Max();

			var counters =
				from e in root.Elements()
				select new
				{
					Category = e.Attribute("category").Value,
					Name = e.Attribute("name").Value,
					Type = e.Attribute("type").Value
				};

			foreach (var counter in counters)
			{
				long value = GetCountAsLong(counter.Category, counter.Name);

				if (counter.Type.Equals("proctime")) // special case
				{
					using (var process = Process.GetCurrentProcess())
					{
						host.Log(Stretch(counter.Name, labelMax)
							+ process.TotalProcessorTime.ToString()
							+ " (" + GetCountAsLong(counter.Category, counter.Name) + "%)");
					}
				}
				else
				{
					host.Log(Stretch(counter.Name, labelMax)
						+ GetCountAsLong(counter.Category, counter.Name).ToString("N0"));
				}
			}

			form.Cursor = System.Windows.Forms.Cursors.Arrow;
		}


		private string Stretch (string label, int length)
		{
			var builder = new StringBuilder(label);
			while (builder.Length < length)
			{
				builder.Append('.');
			}

			builder.Append(": ");

			return builder.ToString();
		}


		private long GetCountAsLong (string category, string name)
		{
			long count = 0;

			using (var counter =
				new PerformanceCounter(category, name, procName))
			{
				count = (long)counter.NextValue();
			}

			return count;
		}
	}
}
