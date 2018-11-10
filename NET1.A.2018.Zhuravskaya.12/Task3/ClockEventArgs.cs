namespace Task3
{
    public class ClockEventArgs
    {
        /// <summary>
        /// Name of event when the Clock was started.
        /// </summary>
        public readonly string TimeFromWhat;

        /// <summary>
        /// Time to event when the Clock was started.
        /// </summary>
        public readonly int Time;

        internal ClockEventArgs(string timeFromWhat, int time)
        {
            TimeFromWhat = timeFromWhat;
            Time = time;
        }
    }
}