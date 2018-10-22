using System;

namespace Task1
{
    /// <summary>
    /// The class implements type conversion methods.
    /// </summary>
    public static class Transform
    {
        /// <summary>
        /// Method takes an array of real numbers and converts it into an array of strings, so that each real number is converted into its "word format".
        /// </summary>
        /// <param name="numbers">Array of real numbers.</param>
        /// <returns>Array of "word format" numbers.</returns>
        /// <exception cref="ArgumentNullException">
        /// Array should not be NULL.
        /// </exception>
        public static string[] TransformToWords(double[] numbers)
        {
            CheckTransformToWordsMethodConditions(numbers);

            string[] result = new string[numbers.Length];

            for (int i = 0; i < numbers.Length; ++i)
            {
                result[i] = TransformToWord(numbers[i]);
            }

            return result;
        }

        private static string TransformToWord(double number)
        { 
            var numberInStringFormat = ((decimal)number).ToString();
            var result = new string[numberInStringFormat.Length];
            for (int i = 0; i < numberInStringFormat.Length; ++i)
            {
                result[i] = TransformDigitToWord(numberInStringFormat[i]);
            }

            return string.Join(" ", result);
        }

        private static string TransformDigitToWord(char digit)
        {
            switch (digit)
            {
                case '1':
                    return "one";
                case '2':
                    return "two";
                case '3':
                    return "three";
                case '4':
                    return "four";
                case '5':
                    return "five";
                case '6':
                    return "six";
                case '7':
                    return "seven";
                case '8':
                    return "eight";
                case '9':
                    return "nine";
                case '0':
                    return "zero";
                case ',':
                    return "point";
                case '-':
                    return "minus";
                default:
                    return null;
            }
        }

        private static void CheckTransformToWordsMethodConditions(double[] numbers)
        {
            if (numbers == null)
            {
                throw new ArgumentNullException();
            }
        }
    }
}
