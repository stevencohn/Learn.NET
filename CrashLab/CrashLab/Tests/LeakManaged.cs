//************************************************************************************************
// Copyright © 2013 Steven M Cohn. All Rights Reserved.
//
//************************************************************************************************

namespace CrashLab.Tests
{
	using System;
	using System.Collections.Generic;
	using System.Threading;
	using System.Windows.Forms;


	/// <summary>
	/// Cause managed memory to leak and persist beyond the lifetime of this test.
	/// </summary>

	internal class LeakManaged : TestBase	
	{

		private class Binary
		{
			private byte[] data;
			public Binary (int size) { data = new byte[size]; }
		}


		/// <summary>
		/// Run the test...
		/// </summary>

		protected override void Execute ()
		{
			Pressure pressure = null;

			using (var dialog = new PressureDialog())
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
				ThreadPool.QueueUserWorkItem(new WaitCallback(ManagedWorker), pressure);
			}
		}


		private void ManagedWorker (object data)
		{
			var pressure = data as Pressure;

			if (base.Mysterious)
			{
				Log("Test started.  What's it doing?  Can you quantify it?");
			}

			var cache = new List<Binary>();

			for (int i = 0, count = 0; i < pressure.Iterations; i++)
			{
				if (!base.active)
				{
					break;
				}

				if ((i % 10) == 0)
				{
					if (base.Mysterious)
					{
						host.LogDot();
					}
					else
					{
						Log((++count) + ") Allocated: " + (pressure.Size * (i *10)) + " bytes");
					}
				}

				Thread.Sleep(10);

				cache.Add(new Binary(pressure.Size));
			}

			base.Complete();
			Log("Completed");
		}
	}
}
