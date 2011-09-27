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
        private int _saveDelay = 5;
        private GlobalKbHook _kbHook;

        public EventLogger(GlobalKbHook kbHook)
        {
            _lastUpdate = DateTime.Now.AddMinutes(-10);
            _kbHook = kbHook;
        }

        public void Log()
        {
            TimeSpan ts = DateTime.Now - _lastUpdate;
            if (ts.TotalSeconds >= _saveDelay)
            {
                DbAccess.SaveEvent(new EventInfo(Win32.GetCurrentWindowTitle(), "Keypress"));
            }
        }
    }
}
