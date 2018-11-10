using System;
using System.Collections.Generic;
using System.Timers;

namespace Task3
{
    public class Clock
    {
        private readonly Dictionary<System.Timers.Timer, ClockEventArgs> _timers = new Dictionary<System.Timers.Timer, ClockEventArgs>();

        public event EventHandler<ClockEventArgs> TimeOut = delegate { };

        public void StartClock(string fromWhat, int time)
        {
            System.Timers.Timer timer = new System.Timers.Timer(time * 1000);
            _timers[timer] = new ClockEventArgs(fromWhat, time);
            timer.Elapsed += TimerOnElapsed;
            timer.AutoReset = false;
            timer.Enabled = true;
        }

        protected virtual void OnClockEventArgs(object sender, ClockEventArgs e)
        {
            TimeOut?.Invoke(this, e);
        }

        private void TimerOnElapsed(object sender, ElapsedEventArgs e)
        {
            if (sender is System.Timers.Timer timer && _timers.TryGetValue(timer, out var clockEventArgs))
            {
                _timers.Remove(timer);
                timer.Stop();
                timer.Dispose();
                TimeOut?.Invoke(this, clockEventArgs);
            }
        }
    }
}