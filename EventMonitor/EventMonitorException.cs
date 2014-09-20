using System;

namespace EventMonitor
{
    public class EventMonitorException : Exception
    {
        public EventMonitorException(string message)
            : base(message)
        {

        }
    }
}