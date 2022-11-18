//************************************************************************************************
// Copyright © 2013 Steven M Cohn. All Rights Reserved.
//
//************************************************************************************************

namespace CrashLab.Tests
{
	using System;
	using System.ComponentModel;
	using System.Threading;
	using System.Windows.Forms;


	/// <summary>
	/// Force a hang by creating a deadlock condition between two threads.
	/// </summary>

	internal class HangOnDeadlock : TestBase
	{
		private static bool useLock = true;

		private class DatabaseWriter : Object { }

		private static DatabaseWriter resource1;
		private static DatabaseWriter resource2;
		private static Thread lockWorker;

		private ManualResetEvent t1Event;
		private ManualResetEvent t2Event;
		private ManualResetEvent stopEvent;


		/// <summary>
		/// Run the test...
		/// </summary>

		protected override void Execute ()
		{
			DialogResult result;
			bool background = true;

			using (var dialog = new DeadlockDialog())
			{
				result = dialog.ShowDialog((IWin32Window)host);
				if (result == DialogResult.OK)
				{
					useLock = dialog.UseLock;
					background = (useLock && dialog.Background);
				}
			}

			if (result == DialogResult.Cancel)
			{
				return;
			}

			if (useLock)
			{
				CreateLockDeadlock(background);
			}
			else
			{
				HangManualDeadlock();
			}
		}


		// - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

		private void CreateLockDeadlock (bool background)
		{
			if (background)
			{
				base.EnableStoppable();
				new Thread(new ThreadStart(HangLockDeadlock)).Start();
			}
			else
			{
				HangLockDeadlock();
			}
		}


		private void HangLockDeadlock ()
		{
			resource1 = new DatabaseWriter();
			resource2 = new DatabaseWriter();

			host.Log("Starting...");

			lockWorker = new Thread(new ParameterizedThreadStart(LockWorker));
			lockWorker.Start(host);

			Thread.Sleep(500);
			lock (resource2)
			{
				Thread.Sleep(500);

				lock (resource1)
				{
					Log("Worker 1: updating resource1");
				}

				Log("Worker 1: updated resource1");
			}

			Log("Worker 1: updated resource2");
		}

		private void LockWorker (object data)
		{
			var host = data as IHost;

			lock (resource1)
			{
				Thread.Sleep(1000);

				lock (resource2)
				{
					host.Log("Worker 2: updating resource2");
				}

				host.Log("Worker 2: updated resource2");
			}

			host.Log("Worker 2: updated resource1");
		}


		// - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

		private void HangManualDeadlock ()
		{
			Log("Both threads 1 and 2 will \"complete\" if successfull:");

			base.EnableStoppable();

			this.t1Event = new ManualResetEvent(false);
			this.t2Event = new ManualResetEvent(false);
			this.stopEvent = new ManualResetEvent(false);

			this.stopEvent.Reset();
			new Thread(new ThreadStart(Worker1)).Start();
			new Thread(new ThreadStart(Worker2)).Start();
		}


		/// <summary>
		/// Override the base Abort functionality so we can release reset events.
		/// </summary>

		protected override void Abort ()
		{
			base.Abort();

			if (useLock)
			{
				lockWorker.Abort();
			}
			else
			{
				stopEvent.Set();
			}
		}


		private void Worker1 ()
		{
			t1Event.Reset();
			Thread.Sleep(1000);
			Log("Thread 1 waiting...");

			WaitHandle.WaitAny(new WaitHandle[] { t2Event, stopEvent });

			Log("Thread 1 completed");
		}


		private void Worker2 ()
		{
			t2Event.Reset();
			Thread.Sleep(1000);
			Log("Thread 2 waiting...");

			WaitHandle.WaitAny(new WaitHandle[] { t1Event, stopEvent});

			Log("Thread 2 completed");
		}
	}
}
