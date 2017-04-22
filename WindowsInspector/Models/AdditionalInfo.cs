namespace WindowsInspector.Models
{
    using System.Drawing;
    using UnsafeNative.Data;

    public class AdditionalInfo
    {
        internal AdditionalInfo(WindowInfo windowInfo)
        {
            Window = windowInfo.rcWindow;
            Client = windowInfo.rcClient;
            Style = (WindowStyle) windowInfo.dwStyle;
            ExStyle = (ExtendedWindowStyle) windowInfo.dwExStyle;
            WindowStatus = windowInfo.dwWindowStatus;
            Border = new Size((int) windowInfo.cxWindowBorders, (int) windowInfo.cyWindowBorders);
            AtomWindowType = windowInfo.atomWindowType;
            CreatorVersion = windowInfo.wCreatorVersion;
        }

        public Rectangle Window { get; private set; }

        public Rectangle Client { get; private set; }

        public WindowStyle Style { get; private set; }

        public ExtendedWindowStyle ExStyle { get; private set; }

        public uint WindowStatus { get; private set; }

        public Size Border { get; private set; }

        public ushort AtomWindowType { get; private set; }
        public ushort CreatorVersion { get; private set; }
    }
}
