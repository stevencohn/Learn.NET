//************************************************************************************************
// Copyright © 2013 Steven M Cohn. All Rights Reserved.
//
//************************************************************************************************

namespace CrashLab.Tests
{
	using System;
	using System.Collections;
	using System.Threading;
	using System.Windows.Forms;


	/// <summary>
	/// 
	/// </summary>

	internal class PerformanceAnalysis : TestBase
	{

		/// <summary>
		/// Run the test...
		/// </summary>

		protected override void Execute ()
		{
			Pressure pressure = null;

			using (var dialog = new PressureDialog(100000, 700))
			{
				DialogResult result = dialog.ShowDialog((IWin32Window)host);
				if (result == DialogResult.OK)
				{
					pressure = dialog.Pressure;
				}
			}

			if (pressure != null)
			{
				base.EnableStoppable();
				ThreadPool.QueueUserWorkItem(new WaitCallback(Analyze), pressure);
			}
		}


		private void Analyze (object state)
		{
			long mem = GC.GetTotalMemory(false);
			Log("Total Memory = " + mem);

			var start = DateTime.Now;
			Log("Begin - " + start.TimeOfDay.ToString());

			var pressure = state as Pressure;

			var analyzers = new ArrayList();
			int interval = pressure.Iterations / 10;

			for (int i = 0, counter = 0; i < pressure.Iterations; i++)
			{
				if (!base.active)
				{
					break;
				}

				if ((i % interval) == 0)
				{
					long totalLen = 0L;
					foreach (Analysis analyzer in analyzers)
					{
						totalLen += analyzer.LengthOf("text");
						totalLen += analyzer.LengthOf("data");
					}

					Log((++counter) + ") Allocated: " + (pressure.Size * 100) + " + of " + totalLen);

					// do not dispose the analyzers
					analyzers.Clear();
				}

				analyzers.Add(new Analysis(pressure, pressure.Size));
			}

			base.Complete();

			var finish = DateTime.Now;
			Log("Done - " + finish.TimeOfDay.ToString());
			Log("Elapsed - " + finish.Subtract(start).ToString());
		}
	}
}
