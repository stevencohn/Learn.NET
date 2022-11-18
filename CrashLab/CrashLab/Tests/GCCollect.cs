//************************************************************************************************
// Copyright © 2013 Steven M Cohn. All Rights Reserved.
//
//************************************************************************************************

namespace CrashLab.Tests
{
	using System;


	/// <summary>
	/// Simply invokes GC.Collect().  Can be used during other asynchronous tests or as
	/// a stand-alone operation in between other tests.
	/// </summary>

	internal class GCCollect : TestBase
	{

		/// <summary>
		/// Run the test...
		/// </summary>

		protected override void Execute ()
		{
			GC.Collect();
			Log("GC.Collect() invoked");
		}
	}
}
