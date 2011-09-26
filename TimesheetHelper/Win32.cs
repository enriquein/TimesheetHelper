using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace TimesheetHelper
{
    static class Win32
    {
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern int GetWindowTextLength(IntPtr hWnd);

        public static string GetCurrentWindowTitle()
        { 
            IntPtr hWnd = GetForegroundWindow();
            if (hWnd == null)
                return string.Empty;

            int length = GetWindowTextLength(hWnd) + 1; // Need to account for that \0
            StringBuilder sb = new StringBuilder(length);
            GetWindowText(hWnd, sb, length);

            return sb.ToString();
        }
    }
}
