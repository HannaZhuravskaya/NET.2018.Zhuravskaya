using System;

namespace No2.Solution
{
    /// <summary>
    /// Bank class.
    /// </summary>
    public class Bank
    {
        /// <summary>
        /// Initializes a new instance of Bank class.
        /// </summary>
        /// <param name="name">
        /// bank name.
        /// </param>
        public Bank(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(nameof(name) + " must not be null, empty or whitespace.");
            }

            this.Name = name;
        }

        /// <summary>
        /// Bank name.
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
        public void Register(Stock stock)
        {
            if (stock == null)
            {
                throw new ArgumentNullException(nameof(stock) + " must not be null.");
            }

            stock.NewInfo += Update;
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
                stockInfo.Euro > 40
                    ? $"Bank {this.Name} sells euros; Euro rate:{stockInfo.Euro}"
                    : $"Bank {this.Name} is buying euros; Euro rate: {stockInfo.Euro}");
        }
    }
}
