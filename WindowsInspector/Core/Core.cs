namespace WindowsInspector
{
    using System;
    using System.Collections;
    using System.Text;
    using System.Windows.Controls;
    using Models;
    using UnsafeNative;
    using UnsafeNative.Methods;
    using System.Collections.Generic;

    internal static class Core
    {
        private const int StrMaxVal = 256;

        private static HwndInfo CreateHwndInfo(IntPtr hWnd)
        {

            int textLen, classNameLen;

            var hwndInfo = new HwndInfo();
            hwndInfo.Handle = hWnd;
            hwndInfo.Text = GetwindowTextOrDefault(hWnd, out textLen);
            hwndInfo.ClassName = GetWindowClassNameOrDefault(hWnd, out classNameLen);
            hwndInfo.MenuHandle = User32.GetMenu(hWnd);

            List<string> name = new List<string>(3);

            if (textLen != 0)
            {
                name.Add(hwndInfo.Text);
            }

            if (classNameLen != 0)
            {
                name.Add(hwndInfo.ClassName);
            }

            name.Add(hWnd.ToString());

            hwndInfo.Header = string.Join(" : ", name);

            var windowInfo = new UnsafeNative.Data.WindowInfo();
            if (User32.GetWindowInfo(hWnd, windowInfo))
            {
                hwndInfo.Additional = new AdditionalInfo(windowInfo);
            }

            return hwndInfo;
        }

        private static string GetWindowAnnotations(IntPtr hWnd, Func<IntPtr, StringBuilder, int, int> func, out int maxCount)
        {
            var buffer = new StringBuilder(StrMaxVal);
            maxCount = func(hWnd, buffer, StrMaxVal);
            return buffer.ToString();
        }

        private static string GetwindowTextOrDefault(IntPtr hWnd, out int maxCount)
        {
            return GetWindowAnnotations(hWnd, User32.GetWindowText, out maxCount);
        }

        private static string GetWindowClassNameOrDefault(IntPtr hWnd, out int maxCount)
        {
            return GetWindowAnnotations(hWnd, User32.GetClassName, out maxCount);
        }

        private static void GetWindows(IntPtr hWnd, IList parentItem)
        {

            var item = AddItem(hWnd, parentItem);

            var childOrNext = User32.GetWindow(hWnd, Constants.GetWindow.GW_CHILD);
            if (childOrNext != IntPtr.Zero)
            {
                GetWindows(childOrNext, item.Items);
            }

            childOrNext = User32.GetWindow(hWnd, Constants.GetWindow.GW_HWNDNEXT);
            if (childOrNext != IntPtr.Zero)
            {
                GetWindows(childOrNext, parentItem);
            }
        }

        private static TreeViewItem AddItem(IntPtr hWnd, IList parentItem)
        {
            var hwndInfo = CreateHwndInfo(hWnd);

            var item = new TreeViewItem
            {
                DataContext = hwndInfo,
                Header = hwndInfo.Text != "Win32Project1" ? hwndInfo.Header : ">>>>>>>>>>>>>>>>" + hwndInfo.Header
            };

            parentItem.Add(item);

            return item;
        }

        public static void Fill(ItemCollection itemCollection)
        {
            itemCollection.Clear();
            GetWindows(User32.GetDesktopWindow(), itemCollection);
        }
    }
}
