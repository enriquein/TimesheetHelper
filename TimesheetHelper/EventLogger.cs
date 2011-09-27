using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimesheetHelper.Data;

namespace TimesheetHelper
{
    public class EventLogger
    {
        private DateTime _lastUpdate;
        // Delay database writes to avoid having too many entries.
        private int _saveDelay = 30;
        private GlobalKbHook _kbHook;

        public EventLogger(GlobalKbHook kbHook)
        {
            _lastUpdate = DateTime.Now.AddMinutes(-10);
            _kbHook = kbHook;
            _kbHook.GlobalKeyDown += new EventHandler<EventArgs>(On_kbHook_GlobalKeyDown);
        }

        private void On_kbHook_GlobalKeyDown(object sender, EventArgs e)
        {
            Log();
        }

        private void Log()
        {
            TimeSpan ts = DateTime.Now - _lastUpdate;
            if (ts.TotalSeconds >= _saveDelay)
            {
                DbAccess.SaveEvent(new EventInfo(Win32.GetCurrentWindowTitle(), "Keypress"));
                _lastUpdate = DateTime.Now;
            }
        }
    }
}
