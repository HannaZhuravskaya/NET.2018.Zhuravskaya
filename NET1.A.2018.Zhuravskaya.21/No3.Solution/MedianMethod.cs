using System.Collections.Generic;
using System.Linq;

namespace No3.Solution
{
    /// <summary>
    /// Median method
    /// </summary>
    public class MedianMethod : IAveragingMethod
    {
        /// <summary>
        /// Calculate median average.
        /// </summary>
        /// <param name="values">
        /// IEnumerable'1 of double elements.
        /// </param>
        /// <returns>
        /// average value.
        /// </returns>
        public double CalculateAverage(IEnumerable<double> values)
        {
            var sortedValues = values.OrderBy(x => x).ToArray();
            int n = sortedValues.Length;
            if (n % 2 == 1)
            {
                return sortedValues[(n - 1) / 2];
            }

            return (sortedValues[sortedValues.Length / 2 - 1] + sortedValues[n / 2]) / 2;
        }
    }
}
