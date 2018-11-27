using System;

namespace No2.Solution
{
    /// <summary>
    /// Stock class.
    /// </summary>
    public class Stock 
    {
        /// <summary>
        /// NewInfo event.
        /// </summary>
        public event EventHandler<StockEventArgs> NewInfo;

        /// <summary>
        /// Get new StockInfo.
        /// </summary>
        public void Market()
        { 
            Random rand = new Random();
            var info = new StockInfo {USD = rand.Next(20, 40), Euro = rand.Next(30, 50)};
            
            OnNewInfo(this, new StockEventArgs(info));
        }
       
        protected virtual void OnNewInfo(object sender, StockEventArgs e)
        {
            NewInfo?.Invoke(this, e);
        }
    }

    /// <summary>
    /// StockEventArgs class.
    /// </summary>
    public class StockEventArgs : EventArgs
    {
        /// <summary>
        /// StockInfo.
        /// </summary>
        public readonly StockInfo StockInfo;

        /// <summary>
        /// Initializes a new instance of StockEventArgs.
        /// </summary>
        /// <param name="info">
        /// StockInfo.
        /// </param>
        internal StockEventArgs(StockInfo info)
        {
            StockInfo = info ?? throw new ArgumentNullException(nameof(info) + "must not be null");
        }

        /// <summary>
        /// Info.
        /// </summary>
        public string Info { get; set; }
    }
}
