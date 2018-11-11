using System;
using System.Linq;

namespace Task1and2.IFilterImplementations
{
    /// <summary>
    /// The implementation of IFilter interface. Determines whether a resource integer matches a pattern.
    /// </summary>
    public class ContainsDigitPattern : IFilter<int>
    {
        private readonly int _digit;

        /// <summary>
        /// Initializes a new instance of the StringLengthPattern class.
        /// </summary>
        /// <param name="digitPattern">
        /// Digit pattern.
        /// </param>
        /// <exception cref="ArgumentException">
        /// Digit pattern must not be less than zero and greater than nine.
        /// </exception>
        public ContainsDigitPattern(int digitPattern)
        {
            InputValidation(digitPattern);

            _digit = digitPattern;
        }

        /// <summary>
        /// The method determines whether a resource integer matches a pattern.
        /// </summary>
        /// <param name="source">
        /// Source to filtering.
        /// </param>
        /// <returns>
        /// Is source fit the pattern.
        /// </returns>
        public bool IsFitThePattern(int source)
        {
            var sourceArray = source.ToString();

            return sourceArray.Contains(_digit.ToString());
        }

        private void InputValidation(int source)
        {
            if (source > 9 || source < 0)
            {
                throw new ArgumentException();
            }
        }
    }
}
