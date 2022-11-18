//************************************************************************************************
// Copyright © 2013 Steven M Cohn. All Rights Reserved.
//
//************************************************************************************************

namespace CrashLab.Tests
{
	using System;
	using System.Drawing;
	using System.Threading;
	

	/// <summary>
	/// A finalizable object with customizable behavior.
	/// </summary>
	
	internal class Mortal : IDisposable
	{
		public static object Sync;

		private static int gate;
		private static int total;

		private int instanceID;
		private bool isDisposed;
		private IHost host;
		private object data;


		static Mortal ()
		{
			gate = 0;
			total = 0;
			Sync = new Object();
		}


		public Mortal (IHost host)
		{
			this.isDisposed = false;
			this.SupressFinalizer = true;

			gate = Interlocked.Increment(ref gate);
			this.instanceID = gate;

			total = Interlocked.Increment(ref total);

			this.data = new SolidBrush(Color.FromArgb(255 % gate, Color.AliceBlue));

			this.host = host;

			if (!host.Mysterious)
			{
				host.Log("Created new Mortal #" + instanceID + ", total=" + total);
			}
		}


		~Mortal ()
		{
			if (SynchronizeFinalizer)
			{
				lock (Sync)
				{
					Interlocked.Decrement(ref total);

					if (HangFinalizaer)
					{
						Thread.Sleep(Timeout.Infinite);
					}

					if (!host.Mysterious)
					{
						host.Log("Finalized Mortal #" + instanceID + ", total=" + total);
					}
				}
			}

			Dispose(false);
		}


		public void Dispose ()
		{
			Dispose(true);

			if (SupressFinalizer)
			{
				GC.SuppressFinalize(this);
			}
		}


		protected virtual void Dispose (bool disposing)
		{
			if (!isDisposed)
			{
				if (disposing && SupressFinalizer)
				{
					Interlocked.Decrement(ref total);
				}

				isDisposed = true;
			}
		}


		/// <summary>
		/// 
		/// </summary>

		public bool HangFinalizaer { get; set; }

	
		/// <summary>
		/// 
		/// </summary>

		public bool SupressFinalizer { get; set; }


		/// <summary>
		/// 
		/// </summary>

		public bool SynchronizeFinalizer { get; set; }
	}
}
