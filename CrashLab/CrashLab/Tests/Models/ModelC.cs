//************************************************************************************************
// Copyright © 2013 Steven M Cohn. All Rights Reserved.
//
//************************************************************************************************

namespace CrashLab.Tests
{
	using System;


	/// <summary>
	/// A value type
	/// </summary>

	internal struct ModelC
	{
		public byte[] data;


		public ModelC (long data)
		{
			this.data = BitConverter.GetBytes(data);
		}


		/// <summary>
		/// 
		/// </summary>

		public long Data
		{
			get { return BitConverter.ToInt64(data, 0); }
			set { data = BitConverter.GetBytes(value); }
		}
	}
}
