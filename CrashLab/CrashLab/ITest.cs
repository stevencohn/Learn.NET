//************************************************************************************************
// Copyright © 2013 Steven M Cohn. All Rights Reserved.
//
//************************************************************************************************

namespace CrashLab
{
	using System;


	/// <summary>
	/// Signal that this test has completed.
	/// </summary>

	internal delegate void CompletedHandler ();


	/// <summary>
	/// Signal container that this test has started.
	/// </summary>
	
	internal delegate void StartedHandler ();


	// - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

	/// <summary>
	/// Basic requirements of each test, used by MainForm only.
	/// <para>
	/// Note that tests need to derive from TestBase and override the protected method Execute().
	/// Asynchronous test should call base.EnableStoppable() as the test begins and then call
	/// Complete() when the test finishes.  Syncronous test do not need to worry about start/stop.
	/// </para>
	/// </summary>

	internal interface ITest
	{

		/// <summary>
		/// Event to signal container that this test has completed.
		/// </summary>

		event CompletedHandler Completed;


		/// <summary>
		/// Event to signal container that this test has started.
		/// </summary>

		event StartedHandler Started;


		/// <summary>
		/// Executes the test.
		/// </summary>
		/// <param name="host"></param>

		void Execute (IHost host);
	}
}
