namespace No2.Solution.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var stock = new Stock();

            var bank = new Bank("BPS");
            bank.Register(stock);
            var broker = new Broker("Mark");
            broker.StartTrade(stock);

            stock.Market();

            System.Console.ReadLine();
        }
    }
}
