namespace WindowsInspector.Models
{
    using System;

    public class HwndInfo
    {
        public string Header { get; set; }

        public string Text { get; set; }

        public string ClassName { get; set; }

        public IntPtr Handle { get; set; }

        public IntPtr MenuHandle { get; set; }

        public AdditionalInfo Additional { get; set; }
    }
}
