//************************************************************************************************
// Copyright © 2013 Steven M Cohn. All Rights Reserved.
//
//************************************************************************************************

namespace CrashLab.Tests
{
	using System;
	using System.Threading;
	using System.Windows.Forms;


	/// <summary>
	/// Cause unmanaged memory to leak and persist beyond the lifetime of this test.
	/// </summary>

	internal class LeakUnmanaged : TestBase
	{

		/// <summary>
		/// 
		/// </summary>
		/// <param name="host"></param>
		/// <param name="mysterious"></param>

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
				ThreadPool.QueueUserWorkItem(new WaitCallback(UnmanagedWorker), pressure);
			}
		}


		private void UnmanagedWorker (object data)
		{
			var pressure = data as Pressure;

			if (base.Mysterious)
			{
				Log("Test started.  What's it doing?  Can you quantify it?");
			}

			int handle = Win32.GetProcessHeap();
			int address = 0;

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
						LogDot();
					}
					else
					{
						Log((++count) + ") Allocated: " + (pressure.Size * 10) + " bytes");
					}
				}

				Thread.Sleep(10);

				address = Win32.HeapAlloc(handle, 0, pressure.Size);
			}

			base.Complete();
			Log("Completed");
		}
	}
}
