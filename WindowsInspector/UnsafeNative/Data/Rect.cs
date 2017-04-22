namespace WindowsInspector.UnsafeNative.Data
{
    using System.Runtime.InteropServices;
    using System.Drawing;

    [StructLayout(LayoutKind.Sequential, CharSet = Constants.CharSetDefault)]
    internal struct Rect
    {
        public int left;
        public int top;
        public int right;
        public int bottom;

        public static implicit operator Rectangle(Rect rect)
        {
            return new Rectangle(rect.left, rect.top, rect.right - rect.left, rect.bottom - rect.top);
        }

    }
}
