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
	/// Create objects that will be blocked on the fReachable thread.
	/// </summary>

	internal class FinalizerBlock : TestBase
	{
		private Thread worker;


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
				worker = new Thread(new ThreadStart(HangFinalizer));
				worker.Start();
			}
			else
			{
				HangFinalizer();
			}
		}


		private void HangFinalizer ()
		{
			lock (Mortal.Sync)
			{
				for (int i = 0; i < 10; i++)
				{
					for (int j = 0; j < 10; j++)
					{
						var mortal = new Mortal(host)
						{
							SupressFinalizer = false,
							SynchronizeFinalizer = true,
							HangFinalizaer = true
						};

						Thread.Sleep(50);
					}

					if (base.Mysterious)
					{
						LogDot();
					}

					Application.DoEvents();
				}

				Log("Test completed");

				if (base.stoppable)
				{
					base.Complete();
				}
			}
		}


		protected override void Abort ()
		{
			base.Abort();
			worker.Abort();
		}
	}
}
