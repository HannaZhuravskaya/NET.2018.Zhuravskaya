using System;
using System.Text.RegularExpressions;
using Task1and2.Interfaces;

namespace Task1and2.IFilterImplementations
{
    /// <summary>
    /// The implementation of IFilter interface. Determines whether a resource string matches a pattern.
    /// </summary>
    public class PatternMatching : IFilter<string>
    {
        private readonly string _pattern;

        /// <summary>
        /// Initializes a new instance of the PatternMatching class.
        /// </summary>
        /// <param name="pattern">
        /// Pattern string.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Pattern string must not be null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Pattern string length must not be null.
        /// </exception>
        public PatternMatching(string pattern)
        {
            InputValidation(pattern);

            _pattern = pattern;
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
        public bool Filter(string source)
        {
            if (source is null)
            {
                throw new ArgumentNullException();
            }

            return Regex.IsMatch(source, _pattern, RegexOptions.IgnoreCase);
        }

        private void InputValidation(string sourceString)
        {
            if (sourceString is null)
            {
                throw new ArgumentNullException();
            }

            if (sourceString.Length == 0)
            {
                throw new ArgumentException();
            }
        }
    }
}
