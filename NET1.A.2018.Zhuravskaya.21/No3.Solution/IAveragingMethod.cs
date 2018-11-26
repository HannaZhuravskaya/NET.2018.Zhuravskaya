using System.Collections.Generic;

namespace No3.Solution
{
    /// <summary>
    /// Averaging method
    /// </summary>
    public interface IAveragingMethod
    {
        /// <summary>
        /// Calculate average.
        /// </summary>
        /// <param name="values">
        /// IEnumerable'1 of double elements.
        /// </param>
        /// <returns>
        /// average value.
        /// </returns>
        double CalculateAverage(IEnumerable<double> values);
    }
}
