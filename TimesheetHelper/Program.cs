using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace TimesheetHelper
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            var gh = new GlobalKbHook();
            var logger = new EventLogger(gh);
            gh.Hook();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new TrayIcon());
            gh.Unhook();
        }
    }
}
