//************************************************************************************************
// Copyright © 2013 Steven M Cohn. All Rights Reserved.
//
//************************************************************************************************

namespace CrashLab.Tests
{
	using System;
	using System.Runtime.InteropServices;


	/// <summary>
	/// Interops
	/// </summary>
	
	internal static class Win32
	{
		[return: MarshalAs(UnmanagedType.Bool)]
		[DllImport("kernel32")]
		public static extern bool CloseHandle (IntPtr hObject);


		[DllImport("kernel32")]
		public static extern void DebugBreak ();


		[DllImport("kernel32")]
		public static extern IntPtr GetCurrentProcess ();


		[DllImport("kernel32")]
		public static extern int GetCurrentThreadId ();


		[DllImport("kernel32")]
		public static extern int GetProcessHeap ();

	
		[DllImport("kernel32")]
		public static extern int HeapAlloc (int heap, int flags, int size);
	}
}
