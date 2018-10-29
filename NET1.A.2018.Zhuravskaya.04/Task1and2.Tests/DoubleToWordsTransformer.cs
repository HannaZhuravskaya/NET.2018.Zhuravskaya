using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1and2.Tests
{
    /// <summary>
    /// The implementation of ITransformer interface. Transform double to word format.
    /// </summary>
    public class DoubleToWordsTransformer : ITransformer
    {
        /// <summary>
        /// Method takes real number and converts it into "word format".
        /// </summary>
        /// <param name="number">Real numbers.</param>
        /// <returns>"Word format" number.</returns>
        public string Transform(double number)
        {
            if (double.IsNaN(number))
            {
                return "NaN";
            }

            var symbolToWord = new Dictionary<char, string>()
            {
                {'1', "one"},
                {'2', "two"},
                {'3', "three"},
                {'4', "four"},
                {'5', "five"},
                {'6', "six"},
                {'7', "seven"},
                {'8', "eight"},
                {'9', "nine"},
                {'0', "zero"},
                {',', "point"},
                {'-', "minus"},
                {'+', "plus"},
                {'E', "exp"}
            };

            var numberInStringFormat = ((decimal)number).ToString();
            var result = new string[numberInStringFormat.Length];
            for (int i = 0; i < numberInStringFormat.Length; ++i)
            {
                result[i] = symbolToWord[numberInStringFormat[i]];
            }

            return string.Join(" ", result);
        }
    }
}