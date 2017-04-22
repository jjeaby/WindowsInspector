namespace UnitTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using WindowsInspector.Import;

    [TestClass]
    public class UnitTestsUser32
    {
        [TestMethod]
        public void TestGetDesktopWindowMethod()
        {
            IntPtr desktopHwnd = IntPtr.Zero;

            try
            {
                desktopHwnd = User32.GetDesktopWindow();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

            Assert.IsFalse(desktopHwnd == IntPtr.Zero);
        }

        [TestMethod]
        public void TestGetWindowMethod()
        {
            IntPtr hwnd = IntPtr.Zero;

            try
            {
                IntPtr desktopHwnd = User32.GetDesktopWindow();
                hwnd = User32.GetWindow(desktopHwnd, GetWindow.GW_CHILD);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

            Assert.IsFalse(hwnd == IntPtr.Zero);
        }

    }
}
