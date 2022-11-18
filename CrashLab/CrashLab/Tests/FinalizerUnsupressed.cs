//************************************************************************************************
// Copyright © 2013 Steven M Cohn. All Rights Reserved.
//
//************************************************************************************************

namespace CrashLab.Tests
{
	using System;


	/// <summary>
	/// A bad example of the Dispose pattern.
	/// </summary>

	internal class FinalizerUnsupressed : TestBase
	{

		/// <summary>
		/// Run the test...
		/// </summary>

		protected override void Execute ()
		{
			for (int i = 0; i < 10; i++)
			{
				var mortal = new Mortal(host);
				mortal.SupressFinalizer = false;
				mortal.SynchronizeFinalizer = false;
				mortal.Dispose();
			}

			Log("Test completed");
		}
	}
}
