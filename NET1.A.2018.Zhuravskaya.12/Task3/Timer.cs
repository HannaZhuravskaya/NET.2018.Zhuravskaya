using System;

namespace Task3
{
    /// <summary>
    ///  Counts down the specified number of seconds.
    /// </summary>
    public sealed class Timer
    {
        /// <summary>
        /// Initializes a new instance of the Timer class, and sets all the properties to their initial values.
        /// </summary>
        /// <param name="clock">
        /// The object of Clock class.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Clock is null.
        /// </exception>
        public Timer(Clock clock)
        {
            ClockObjectInputValidation(clock);

            clock.TimeOut += TimeIsOut;
        }

        /// <summary>
        /// Unsubscribes from the clock event.
        /// </summary>
        /// <param name="clock">
        /// The object of Clock class.
        /// </param>
        ///  /// <exception cref="ArgumentNullException">
        /// Clock is null.
        /// </exception>
        public void Unregister(Clock clock)
        {
            ClockObjectInputValidation(clock);

            clock.TimeOut -= TimeIsOut;
        }

        private void TimeIsOut(object sender, ClockEventArgs eventArgs)
        {
            Console.WriteLine($"{eventArgs.Time} seconds have expired.");
        }

        private void ClockObjectInputValidation(Clock clock)
        {
            if (clock is null)
            {
                throw new ArgumentNullException();
            }
        }
    }
}
