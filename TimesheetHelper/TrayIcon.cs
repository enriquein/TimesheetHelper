using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TimesheetHelper.Data;

namespace TimesheetHelper
{
    public partial class TrayIcon : Form
    {
        // We want to keep track of this so that we only save once each few seconds or so.
        private DateTime _lastSave = DateTime.Now.AddMinutes(-1);
        private int _saveDelay = 15; // measured in seconds.

        public TrayIcon()
        {
            InitializeComponent();
        }

        private void OnGlobalKeyPress(object sender, KeyPressEventArgs e)
        {
            SaveEvent("Keypress");
        }

        private void OnGlobalMouseClick(object sender, MouseEventArgs e)
        {
            SaveEvent("MouseClick");
        }

        private void SaveEvent(string eventType)
        {
            TimeSpan ts = DateTime.Now - _lastSave;
            if (ts.TotalSeconds > _saveDelay)
            {
                DbAccess.SaveEvent(new EventInfo() { 
                    WindowTitle = Win32.GetCurrentWindowTitle(), 
                    EventType = eventType 
                });
            }
        }
    }
}
