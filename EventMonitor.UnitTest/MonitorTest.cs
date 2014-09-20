using System;
using EventMonitor.UnitTest.Support;
using Xunit;

namespace EventMonitor.UnitTest
{
    public class MonitorTest
    {
        [Fact]
        public void AssertRaised_EventRaised_DoesNotInduceError()
        {
            var observable = new AsynchronousObservable();

            Action exercise = () => observable.Induce(true);

            EventMonitor.AssertRaised(
                exercise, handler => observable.Induced += handler);
        }

        [Fact]
        public void AssertRaised_EventNotRaised_InducesError()
        {
            var observable = new AsynchronousObservable();

            Action exercise = () => observable.Induce(false);

            Assert.Throws<EventMonitorException>(() => EventMonitor.AssertRaised(
                exercise, handler => observable.Induced += handler));
        }
    }
}