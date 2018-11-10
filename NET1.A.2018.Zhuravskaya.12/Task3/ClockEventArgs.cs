namespace Task3
{
    public class ClockEventArgs
    {
        public readonly string TimeFromWhat;

        public readonly int Time;

        public ClockEventArgs(string timeFromWhat, int time)
        {
            TimeFromWhat = timeFromWhat;
            Time = time;
        }
    }
}