namespace WindowsInspector.UnsafeNative.Data
{
    using System.Runtime.InteropServices;


    [StructLayout(LayoutKind.Sequential, CharSet = Constants.CharSetDefault)]
    internal class WindowInfo
    {
        private static readonly uint CbSizeValue = (uint)Marshal.SizeOf<WindowInfo>();

        public readonly uint cbSize = CbSizeValue;
        public Rect rcWindow;
        public Rect rcClient;
        public uint dwStyle;
        public uint dwExStyle;
        public uint dwWindowStatus;
        public uint cxWindowBorders;
        public uint cyWindowBorders;
        public ushort atomWindowType;
        public ushort wCreatorVersion;
    }
}
