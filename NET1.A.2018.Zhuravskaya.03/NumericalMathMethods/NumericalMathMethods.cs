using System;

namespace NumericalMathMethods
{ 
    /// <summary>
    /// Contains mathematical numerical methods.
    /// </summary>
    public static class NumericalMathMethods
    {
        /// <summary>
        /// The method takes a positive integer and returns the closest largest integer consisting of the digits of the source number. 
        /// </summary>
        /// <param name="number">Source number.</param>
        /// <returns>The closest largest integer consisting of the digits of the source number or -1 if no such number exists.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Number should be positive.
        /// </exception>
        public static int FindNextBiggerNumber(int number)
        {
            if (number <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (number < 10)
            {
                return -1;
            }

            var digits = ParseIntToIntArray(number);

            if (!TryToFindTheIndexNumbersToChange(digits, out var indexNumbersToChange))
            {
                return -1;
            }

            Swap(ref digits[indexNumbersToChange.Item1], ref digits[indexNumbersToChange.Item2]);
            Array.Sort(digits, indexNumbersToChange.Item1, digits.Length - indexNumbersToChange.Item1);

            return ParseIntArrayToInt(digits);
        }

        /// <summary>
        /// The method takes a real number and calculates the Nth root by the Newton method with a given accuracy.
        /// </summary>
        /// <param name="number">Source number.</param>
        /// <param name="degree">Root degree.</param>
        /// <param name="accuracy">Method accuracy.</param>
        /// <returns>The Nth root of a source number.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Degree should be integer and positive number.
        /// Accuracy should be greater than 0.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// It is impossible to calculate the even root of a negative number.
        /// </exception>
        public static double FindNthRoot(double number, int degree, double accuracy)
        {
            CheckFindNthRootMethodConditions(number, degree, accuracy);

            var x0 = number / degree;
            var x1 = (1 / (double)degree) * ((((double)degree - 1) * x0) + number / PowForIntegerDegree(x0, degree - 1));
            while (Math.Abs(x1 - x0) > accuracy)
            {
                x0 = x1;
                x1 = (1 / (double)degree) * (((double)degree - 1) * x0 + number / PowForIntegerDegree(x0, degree - 1));
            }
            
            return x1;
        }

        private static bool TryToFindTheIndexNumbersToChange(int[] digits, out (int, int) indexNumbersToChange)
        {
            bool hasBiggerNumber = false;
            int digitIndexToChange = -1;
            for (int i = digits.Length - 1; i > 0; i--)
            {
                if (digits[i] > digits[i - 1])
                {
                    hasBiggerNumber = true;
                    digitIndexToChange = i;
                    break;
                }
            }

            indexNumbersToChange = (digitIndexToChange, digitIndexToChange - 1);

            return hasBiggerNumber;
        }

        private static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        private static double PowForIntegerDegree(double number, int degree)
        {
            double result = 1;
            for (var i = 0; i < degree; ++i)
            {
                result *= number;
            }

            return result;
        }

        private static int ParseIntArrayToInt(int[] array)
        {
            int number = 0;
            for (int i = 0; i < array.Length; i++)
            {
                number *= 10;
                number += array[i];
            }

            return number;
        }

        private static int[] ParseIntToIntArray(int number)
        {
            int[] digits = new int[(int)Math.Log10(number) + 1];
            for (int i = 0; i < digits.Length; ++i)
            {
                digits[i] = number % 10;
                number /= 10;
            }

            Array.Reverse(digits);

            return digits;
        }

        private static void CheckFindNthRootMethodConditions(double number, int degree, double accuracy)
        {
            if (degree <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (accuracy <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (degree % 2 == 0 && number < 0)
            {
                throw new ArgumentException();
            }
        }
    }
}