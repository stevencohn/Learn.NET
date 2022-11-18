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
	/// Force a low-CPU load so we can track down the offending thread and code.
	/// </summary>

	internal class HangOnLowCPU : TestBase
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

				for (int i = 0; i < 10; i++)
				{
					if (!base.Mysterious)
					{
						Log("Creating ThreadPool thread " + i);
					}

					ThreadPool.QueueUserWorkItem(new WaitCallback(HangLow), null);
				}
			}
			else
			{
				HangLow(null);
			}
		}


		private void HangLow (object s)
		{
			if (!base.Mysterious)
			{
				Log("Waiting for lock: threadID=" + Win32.GetCurrentThreadId());
			}

			lock (this)
			{
				if (!base.Mysterious)
				{
					Log("Acquired lock: threadID=" + Win32.GetCurrentThreadId());
				}

				while (active)
				{
					host.LogDot();
					Thread.Sleep(1000);
				}

				Log("Aborted");
			}
		}
	}
}
