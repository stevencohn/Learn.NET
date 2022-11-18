//************************************************************************************************
// Copyright © 2013 Steven M Cohn. All Rights Reserved.
//
//************************************************************************************************

namespace CrashLab.Tests
{
	using System;
	using System.Threading;


	/// <summary>
	/// Waste some time spinning up multiple threads and doing some fake work (sleep).
	/// </summary>
	
	internal class Weaver
	{
		private int worktime;


		/// <summary>
		/// Initialize a new instance with the given sleep time.
		/// </summary>
		/// <param name="worktime"></param>

		public Weaver (int worktime)
		{
			this.worktime = worktime;
		}


		/// <summary>
		/// Create and start the specified number of normal managed threads.
		/// </summary>
		/// <param name="count"></param>
		/// <param name="host"></param>
		/// <param name="mysterious"></param>

		public void SpinUpNormalThreads (int count, IHost host)
		{
			for (int i = 0; i < count; i++)
			{
				if (!host.Mysterious)
				{
					host.Log("Creating managed thread [" + i + "]");
				}

				new Thread(new ThreadStart(NormalWorker)).Start();
			}
		}

		private void NormalWorker ()
		{
			DelegateNormalWork();
		}

		private void DelegateNormalWork ()
		{
			Work(worktime);
		}

		private void Work (int time)
		{
			Thread.Sleep(time);
		}


		/// <summary>
		/// Create and start the specified number of thread pool threads.
		/// </summary>
		/// <param name="count"></param>
		/// <param name="host"></param>
		/// <param name="mysterious"></param>

		public void SpinUpPooledThreads (int count, IHost host)
		{
			for (int i = 0; i < count; i++)
			{
				if (!host.Mysterious)
				{
					host.Log("Creating ThreadPool thread [" + i + "]");
				}

				ThreadPool.QueueUserWorkItem(new WaitCallback(PooledWorker), null);
			}
		}

		private void PooledWorker (object data)
		{
			DelegatePooledWork(data);
		}

		private void DelegatePooledWork (object data)
		{
			Work(worktime);
		}
	}
}
