// Adapted from: http://blogs.msdn.com/b/toub/archive/2006/05/03/589423.aspx
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimesheetHelper
{
    public class GlobalKbHook
    {
        private Win32.LowLevelKeyboardProc _proc;
        private IntPtr _hookId = IntPtr.Zero;
        
        // This is where we hook up whatever it is we want to do when the event fires
        public event EventHandler<EventArgs> GlobalKeyDown; 

        public GlobalKbHook()
        {
            _proc = HookCallback;
        }

        public void Hook()
        {
            _hookId = Win32.SetHook(_proc);
        }

        public void Unhook()
        {
            Win32.UnhookWindowsHookEx(_hookId);
        }

        private IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (GlobalKeyDown != null)
                GlobalKeyDown(this, EventArgs.Empty);

            return Win32.CallNextHookEx(_hookId, nCode, wParam, lParam);
        }
    }
}
