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
	/// Force a high-CPU load so we can track down the offending thread and code.
	/// </summary>

	internal class HangOnHighCPU : TestBase
	{


		/// <summary>
		/// Run the test...
		/// </summary>

		protected override void Execute ()
		{
			DialogResult result;
			bool background = true;

			using (var dialog = new HangDialog())
			{
				result = dialog.ShowDialog((IWin32Window)host);
				if (result == DialogResult.OK)
				{
					background = dialog.Background;
				}
			}

			if (result == DialogResult.Cancel)
			{
				return;
			}

			if (background)
			{
				base.EnableStoppable();
				new Thread(new ThreadStart(HangHigh)).Start();
			}
			else
			{
				HangHigh();
			}
		}


		private void HangHigh ()
		{
			if (!base.Mysterious)
			{
				Log("Starting high CPU work on low priority threadID=" + Win32.GetCurrentThreadId());
			}

			Thread.CurrentThread.Priority = ThreadPriority.BelowNormal;

			long x = 0L;
			long z = 0L;

			while (base.active)
			{
				x += 1L;
				z = 0L;
				for (int y = 0; y < 10000; y++)
				{
					z += 1L;
				}

				host.LogDot();
			}

			Thread.CurrentThread.Priority = ThreadPriority.Normal;
			Log("Aborted");
		}
	}
}
