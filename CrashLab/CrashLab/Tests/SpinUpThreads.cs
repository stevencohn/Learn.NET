//************************************************************************************************
// Copyright © 2013 Steven M Cohn. All Rights Reserved.
//
//************************************************************************************************

namespace CrashLab.Tests
{
	using System;


	/// <summary>
	/// Spin up a buch of threads and then Break.
	/// </summary>

	internal class SpinUpThreads : TestBase
	{

		/// <summary>
		/// Run the test...
		/// </summary>

		protected override void Execute ()
		{
			var weaver = new Weaver(10000);

			weaver.SpinUpPooledThreads(5, host);
			weaver.SpinUpNormalThreads(5, host);

			if (base.Mysterious)
			{
				Log(
					"Test run and Break called.  So... what happened?");
			}
			else
			{
				Log(
					"SpinUpThreads invoked and Break called..  How many threads?  " +
					"Which function created them?  Which object owns them?");
			}

			Win32.DebugBreak();

			Complete();
		}
	}
}
