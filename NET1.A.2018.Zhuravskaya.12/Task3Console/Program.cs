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
            Timer timer1 = new Timer(clock);
            Timer timer2 = new Timer(clock);
            clock.StartClock(4, "time to birthday");
            Thread.Sleep(5000);
            timer1.Unregister(clock);
            clock.StartClock(1);
            Thread.Sleep(3000);
        }
    }
}