using System.Collections.Generic;
using System.Linq;

namespace No3.Solution
{
    /// <summary>
    /// Mean method
    /// </summary>
    public class MeanMethod : IAveragingMethod
    {
        /// <summary>
        /// Calculate mean average.
        /// </summary>
        /// <param name="values">
        /// IEnumerable'1 of double elements.
        /// </param>
        /// <returns>
        /// average value.
        /// </returns>
        public double CalculateAverage(IEnumerable<double> values)
        {
            var array = values as double[] ?? values.ToArray();

            return array.Sum() / array.Length;
        }
    }
}
