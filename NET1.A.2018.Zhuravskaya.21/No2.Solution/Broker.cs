using System;

namespace No2.Solution
{
    /// <summary>
    /// Broker class.
    /// </summary>
    public class Broker
    {
        /// <summary>
        /// Initializes a new instance of Broker class.
        /// </summary>
        /// <param name="name">
        /// broker name.
        /// </param>
        public Broker(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(nameof(name) + " must not be null, empty or whitespace.");
            }

            this.Name = name;
        }

        /// <summary>
        /// Broker name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Register a stock.
        /// </summary>
        /// <param name="stock">
        /// stock to register.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// stock must not be null.
        /// </exception>
        public void StartTrade(Stock stock)
        {
            if (stock == null)
            {
                throw new ArgumentNullException(nameof(stock) + " must not be null.");
            }

            stock.NewInfo += Update;
        }

        /// <summary>
        /// Unregister a stock.
        /// </summary>
        /// <param name="stock">
        /// stock to unregister.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// stock must not be null.
        /// </exception>
        public void StopTrade(Stock stock)
        {
            if (stock == null)
            {
                throw new ArgumentNullException(nameof(stock) + " must not be null.");
            }

            stock.NewInfo -= Update;
        }

        /// <summary>
        /// Update StockInfo.
        /// </summary>
        /// <param name="sender">
        /// Event sender.
        /// </param>
        /// <param name="e">
        /// StockEventArgs object.
        /// </param>
        public void Update(object sender, StockEventArgs e)
        {
            StockInfo stockInfo = e.StockInfo;

            Console.WriteLine(
                stockInfo.USD > 30
                    ? $"Broker {this.Name} sells dollars; Dollar rate: {stockInfo.USD}"
                    : $"Broker {this.Name} buys dollars; Dollar rate: {stockInfo.USD}");
        }
    }
}
