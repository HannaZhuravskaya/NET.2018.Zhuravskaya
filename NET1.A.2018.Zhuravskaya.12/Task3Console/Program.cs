using System.Threading;
using Task3;
using Timer = Task3.Timer;

namespace Task3Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Clock clock = new Clock();
            Timer countdown = new Timer(clock);
            Timer countdown1 = new Timer(clock);
            clock.StartClock("time to birthday", 4);
            Thread.Sleep(5000);
            countdown.Unregister(clock);
            clock.StartClock("time to birthday", 1);
            Thread.Sleep(12000);
        }
    }
}