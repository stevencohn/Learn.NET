//************************************************************************************************
// Copyright © 2013 Steven M Cohn. All Rights Reserved.
//
//************************************************************************************************

namespace CrashLab.Tests
{
	using System;


	/// <summary>
	/// Base class for all tests, provides common functionality for both synchronous
	/// and asynchronous operations, with start and stop notifications and abort option.
	/// </summary>

	internal abstract class TestBase : ITest
	{
		protected IHost host;						// reference to host container for IO
		protected bool active;						// true while async ops are active
		protected bool stoppable;					// true if stoppable enabled
		private AbortHandler abort;					// handler to stop async ops


		/// <summary>
		/// Event to signal container that this test has completed.
		/// </summary>

		public event CompletedHandler Completed;


		/// <summary>
		/// Event to signal container that this test has started.
		/// </summary>

		public event StartedHandler Started;


		/// <summary>
		/// Gets the mysterious setting.
		/// </summary>

		protected bool Mysterious { get { return host.Mysterious; } }

		/// <summary>
		/// This handler is subscribed to the host.AbortTest event.  The host will signal
		/// an abort request when the Stop button is clicked by the user.
		/// </summary>

		protected virtual void Abort ()
		{
			host.Log("Aborting");
			Complete();
		}


		/// <summary>
		/// Informs the host that this test is complete.  This is invoked
		/// automatically for sync test but must be called explictly by async tests.
		/// </summary>

		public void Complete ()
		{
			if (abort != null)
			{
				host.AbortTest -= abort;
				abort = null;
			}

			if (Completed != null)
			{
				Completed();
			}

			active = false;
		}


		/// <summary>
		/// Must be called by asynchronous tests during initialization phase.
		/// This registers the Abort handler with the host and signals a Start event.
		/// </summary>

		protected void EnableStoppable ()
		{
			host.AbortTest += (abort = new AbortHandler(Abort));
			stoppable = true;

			if (Started != null)
			{
				Started();
			}
		}


		/// <summary>
		/// Test implementations must complete this entry point!
		/// </summary>

		protected abstract void Execute ();


		/// <summary>
		/// Entry point for the host to invoke test executions.
		/// </summary>
		/// <param name="host">A reference to the host</param>
		/// <param name="mysterious">True if in mysterious mode</param>

		public void Execute (IHost host)
		{
			this.host = host;

			active = true;

			Execute();
		}


		#region IHost wrappers

		protected void Log (Exception exc)
		{
			host.Log(exc);
		}


		protected void Log (string text)
		{
			host.Log(text);
		}


		protected void LogDot ()
		{
			host.LogDot();
		}

		#endregion IHost wrappers
	}
}
