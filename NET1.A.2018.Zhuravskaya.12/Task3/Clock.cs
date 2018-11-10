using System;
using System.Collections.Generic;
using System.Timers;

namespace Task3
{
    /// <summary>
    ///  Counts down the specified number of seconds.
    /// </summary>
    public class Clock
    {
        private readonly Dictionary<System.Timers.Timer, ClockEventArgs> _timers = new Dictionary<System.Timers.Timer, ClockEventArgs>();

        /// <summary>
        /// Occurs when the time elapses.
        /// </summary>
        public event EventHandler<ClockEventArgs> TimeOut = delegate { };

        /// <summary>
        /// The method counts down the specified number of seconds.
        /// </summary>
        /// <param name="nameOfEvent">
        /// An event up to which counts the number of seconds.
        /// </param>
        /// <param name="time">
        /// Time to event.
        /// </param>
        public void StartClock(int time, string nameOfEvent = null)
        {
            System.Timers.Timer timer = new System.Timers.Timer(time * 1000);
            _timers[timer] = new ClockEventArgs(nameOfEvent, time);
            timer.Elapsed += TimerOnElapsed;
            timer.AutoReset = false;
            timer.Enabled = true;
        }

        protected virtual void OnTimeOut(object sender, ClockEventArgs e)
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
                OnTimeOut(sender, clockEventArgs);
            }
        }
    }
}