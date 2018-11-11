using System;

namespace Task1and2.IFilterImplementations
{
    /// <summary>
    /// The implementation of IFilter interface. Determines whether a resource string matches a pattern.
    /// </summary>
    public class StringLengthPattern : IFilter<string>
    {
        private readonly int _length;

        /// <summary>
        /// Initializes a new instance of the StringLengthPattern class.
        /// </summary>
        /// <param name="length">
        /// Pattern length of string.
        /// </param>
        /// <exception cref="ArgumentException">
        /// Pattern length must not be less than zero.
        /// </exception>
        public StringLengthPattern(int length)
        {
            InputValidation(length);

            _length = length;
        }

        /// <summary>
        /// The method determines whether a resource string matches a pattern.
        /// </summary>
        /// <param name="source">
        /// Source to filtering.
        /// </param>
        /// <returns>
        /// Is source fit the pattern.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Source string must not be null.
        /// </exception>
        public bool IsFitThePattern(string source)
        {
            if (source is null)
            {
                throw new ArgumentNullException();
            }

            return source.Length == _length;
        }

        private void InputValidation(int length)
        {
            if (length < 0)
            {
                throw new ArgumentException();
            }
        }
    }
}
