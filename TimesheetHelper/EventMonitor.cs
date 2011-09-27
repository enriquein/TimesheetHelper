using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MouseKeyboardActivityMonitor;
using MouseKeyboardActivityMonitor.WinApi;
using TimesheetHelper.Data;

namespace TimesheetHelper
{
    public class EventMonitor
    {
        private KeyboardHookListener _kbListener;
        private MouseHookListener _mouseListener;

        // We want to keep track of this so that we only save once each few seconds or so.
        private DateTime _lastSave = DateTime.MinValue;
        private int _saveDelay = 15; // measured in seconds.
        
        public void Activate()
        {
            _kbListener = new KeyboardHookListener(new GlobalHooker());
            _mouseListener = new MouseHookListener(new GlobalHooker());

            _mouseListener.Enabled = true;
            _kbListener.Enabled = true;

            _mouseListener.MouseDownExt += MouseListener_MouseDownExt;
            _kbListener.KeyDown += new KeyEventHandler(KbListener_KeyDown);
            _lastSave = DateTime.Now.AddMinutes(-10);
        }

        public void Deactivate()
        {
            _mouseListener.Dispose();
            _kbListener.Dispose();
        }       
        
        private void KbListener_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            SaveEvent("Keypress");   
        }

        private void MouseListener_MouseDownExt(object sender, MouseEventExtArgs e)
        {
            SaveEvent("Mouseclick");
        }

        private void SaveEvent(string eventType)
        {
            TimeSpan ts = DateTime.Now - _lastSave;
            if (ts.TotalSeconds > _saveDelay)
            {
                DbAccess.SaveEvent(new EventInfo()
                {
                    WindowTitle = Win32.GetCurrentWindowTitle(),
                    EventType = eventType
                });
                _lastSave = DateTime.Now;
            }
        }
    }
}
