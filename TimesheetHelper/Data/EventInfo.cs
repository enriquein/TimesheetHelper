using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimesheetHelper.Data
{
    public class EventInfo
    {
        public int Id { get; set; }
        public string WindowTitle { get; set; }
        public DateTime EventDate { get; set; }
        public string EventType { get; set; }        
        
        public EventInfo(){}

        public EventInfo(string windowTitle, string eventType)
        {
            WindowTitle = windowTitle;
            EventType = eventType;
        }


    }
}
