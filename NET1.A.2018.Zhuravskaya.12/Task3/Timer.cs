using System;

namespace Task3
{
    public sealed class Timer
    { 
        public Timer(Clock clock)
        {
            clock.TimeOut += TimeIsOut;
        }

        public void Unregister(Clock clock)
        {
            clock.TimeOut -= TimeIsOut;
        }

        private void TimeIsOut(object sender, ClockEventArgs eventArgs)
        {
            Console.WriteLine($"{eventArgs.Time} seconds have expired.");
        }
    }
}
