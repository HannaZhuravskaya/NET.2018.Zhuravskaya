using System;
using System.Collections.Generic;

namespace No3.Solution
{
    /// <summary>
    /// Calculator class.
    /// </summary>
    public class Calculator
    {
        /// <summary>
        /// Calculate average value of IEnumerable'1 of double elements.
        /// </summary>
        /// <param name="values">
        /// IEnumerable'1 od double elements.
        /// </param>
        /// <param name="averagingMethod">
        /// IAveragingMethod object. 
        /// </param>
        /// <returns>
        /// average value
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// averagingMethod must not be null.
        /// values must not be null.
        /// </exception>
         public double CalculateAverage(IEnumerable<double> values, IAveragingMethod averagingMethod)
        {
            if (averagingMethod == null)
            {
                throw new ArgumentNullException(nameof(averagingMethod) + "must not be null");
            }

            return CalculateAverage(values, averagingMethod.CalculateAverage);
        }

        /// <summary>
        /// Calculate average value of IEnumerable'1 of double elements.
        /// </summary>
        /// <param name="values">
        /// IEnumerable'1 od double elements.
        /// </param>
        /// <param name="averagingMethod">
        /// Func delegate.
        /// </param>
        /// <returns>
        /// average value
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// averagingMethod must not be null.
        /// values must not be null.
        /// </exception>
        public double CalculateAverage(IEnumerable<double> values, Func<IEnumerable<double>, double> averagingMethod)
        {
            if (values == null)
            {
                throw new ArgumentNullException(nameof(values) + "must not be null");
            }

            if (averagingMethod == null)
            {
                throw new ArgumentNullException(nameof(averagingMethod) + "must not be null");
            }

            return averagingMethod.Invoke(values);
        }
    }
}
