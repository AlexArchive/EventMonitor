using System;
using System.Threading.Tasks;

namespace EventMonitor.UnitTest.Support
{
    public class AsynchronousObservable
    {
        public event Action Induced;

        public void Induce(bool actuallyInduce)
        {
            if (actuallyInduce)
            {
                Task.Run(Induced);
            }
        }
    }
}