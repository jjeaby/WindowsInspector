namespace WindowsInspector.UnsafeNative.Methods
{
    using System;
    using System.Runtime.InteropServices;
    using System.Text;

    internal static class User32
    {
        private const string User32Dll = "user32.dll";

        [DllImport(User32Dll, CharSet = Constants.CharSetDefault, SetLastError = Constants.SetLastErrorDefault)]
        internal static extern IntPtr GetWindow(IntPtr hWnd, int uCmd);

        [DllImport(User32Dll, CharSet = Constants.CharSetDefault, SetLastError = Constants.SetLastErrorDefault)]
        internal static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport(User32Dll, CharSet = Constants.CharSetDefault, SetLastError = Constants.SetLastErrorDefault)]
        internal static extern int GetClassName(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport(User32Dll, ExactSpelling = true, CharSet = Constants.CharSetDefault, SetLastError = Constants.SetLastErrorDefault)]
        internal static extern IntPtr GetDesktopWindow();

        [DllImport(User32Dll, CharSet = Constants.CharSetDefault, SetLastError = Constants.SetLastErrorDefault)]
        internal static extern IntPtr GetMenu(IntPtr hWnd);

        [DllImport(User32Dll, CharSet = Constants.CharSetDefault, SetLastError = Constants.SetLastErrorDefault)]
        internal static extern bool GetWindowInfo(IntPtr hWnd, Data.WindowInfo windowInfo);
    }
}
