using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TimesheetHelper
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var mon = new EventMonitor();
            mon.Activate();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new TrayIcon());
            mon.Deactivate();
        }
    }
}
