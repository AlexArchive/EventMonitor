using System;
using System.Threading;

namespace EventMonitor
{
    public class EventMonitor
    {
        public static void AssertRaised(Action exercise, Action<Action> handler)
        {
            ManualResetEvent completion = new ManualResetEvent(false);
            bool invoked = false;
            
            handler(() =>
            {
                invoked = true;
                completion.Set();
            });

            exercise();

            completion.WaitOne(TimeSpan.FromSeconds(2));

            if (invoked == false)
            {
                throw new EventMonitorException("");
            }
        }
    }
}