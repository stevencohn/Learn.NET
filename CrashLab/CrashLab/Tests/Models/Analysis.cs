//************************************************************************************************
// Copyright © 2013 Steven M Cohn. All Rights Reserved.
//
//************************************************************************************************

namespace CrashLab.Tests
{
	using System;
	using System.Runtime.InteropServices;
	using System.Text;


	/// <summary>
	/// 
	/// </summary>
	
	internal class Analysis : IDisposable
	{
		private object sync;
		private byte[] data;
		private string text;
		private IntPtr handle;
		private int[] lengths;
		private bool isDisposed;


		/// <summary>
		/// 
		/// </summary>
		/// <param name="sync"></param>
		/// <param name="size"></param>

		public Analysis (object sync, int size)
		{
			this.sync = sync;
			this.data = new byte[size];
			this.text = new StringBuilder(size / 2).ToString();
			this.handle = Win32.GetCurrentProcess();
			this.isDisposed = false;
		}


		~Analysis ()
		{
			lock (sync)
			{
				Dispose(false);
			}
		}


		public void Dispose ()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}


		public virtual void Dispose (bool disposing)
		{
			if (!isDisposed)
			{
				if (disposing)
				{
				}

				Win32.CloseHandle(handle);
				isDisposed = true;
			}
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>

		public int LengthOf (string item)
		{
			try
			{
				// yes, this will raise exception first time!

				if (item == "data")
				{
					return lengths[0];
				}
				if (item == "text")
				{
					return lengths[1];
				}
			}
			catch (NullReferenceException)
			{
				lengths = new int[] { data.Length, text.Length };
				return LengthOf(item);
			}

			return 0;
		}
	}
}

