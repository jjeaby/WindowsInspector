namespace WindowsInspector.Import
{
    using System;
    using System.Runtime.InteropServices;

    public static class User32
    {
        private const string User32Dll = "user32.dll";

        /// <summary>
        /// Retrieves a handle to the desktop window.
        /// The desktop window covers the entire screen.
        /// The desktop window is the area on top of which other windows are painted.
        /// </summary>
        /// <returns>The return value is a <see cref="IntPtr"/> handle to the desktop window.</returns>
        [DllImport(User32Dll, ExactSpelling = true, CharSet = Constants.CharSetDefault, SetLastError = Constants.SetLastErrorDefault)]
        public static extern IntPtr GetDesktopWindow();

        /// <summary>
        /// Retrieves a <see cref="IntPtr"/> handle to a window that has the specified relationship (Z-Order or owner) to the specified window.
        /// </summary>
        /// <param name="hWnd">A <see cref="IntPtr"/> handle to a window.</param>
        /// <param name="uCmd">The relationship between the specified window and the window whose handle is to be retrieved.</param>
        /// <returns>If the function succeeds, the return value is a <see cref="IntPtr"/> window handle.
        /// If no window exists with the specified relationship to the specified window,
        /// the return value is <see cref="IntPtr.Zero"/>.</returns>
        /// <remarks>The hWnd handle retrieved is relative to this window, based on the value of the uCmd parameter.</remarks>
        [DllImport(User32Dll, CharSet = Constants.CharSetDefault, SetLastError = Constants.SetLastErrorDefault)]
        public static extern IntPtr GetWindow(IntPtr hWnd, GetWindow uCmd);

        //[DllImport(User32Dll, CharSet = Constants.CharSetDefault, SetLastError = Constants.SetLastErrorDefault)]
        //internal static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        //[DllImport(User32Dll, CharSet = Constants.CharSetDefault, SetLastError = Constants.SetLastErrorDefault)]
        //internal static extern int GetClassName(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        //[DllImport(User32Dll, CharSet = Constants.CharSetDefault, SetLastError = Constants.SetLastErrorDefault)]
        //internal static extern IntPtr GetMenu(IntPtr hWnd);

        //[DllImport(User32Dll, CharSet = Constants.CharSetDefault, SetLastError = Constants.SetLastErrorDefault)]
        //internal static extern bool GetWindowInfo(IntPtr hWnd, Data.WindowInfo windowInfo);
    }
}
