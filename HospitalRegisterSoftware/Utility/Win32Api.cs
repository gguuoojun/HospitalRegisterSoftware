using System;
using System.Runtime.InteropServices;

namespace Utility
{
	internal class Win32Api
	{
		public const int SW_SHOWNORMAL = 1;

		public const int SW_RESTORE = 9;

		public const int SW_SHOWNOACTIVATE = 4;

		[DllImport("user32.dll", SetLastError = true)]
		public static extern bool ShowWindow(IntPtr hWnd, uint nCmdShow);

		[DllImport("user32.dll", SetLastError = true)]
		public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetForegroundWindow(IntPtr hWnd);

		[DllImport("user32.dll")]
		public static extern IntPtr SetActiveWindow(IntPtr hWnd);
	}
}
