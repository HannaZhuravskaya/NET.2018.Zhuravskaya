using System;
using System.Diagnostics;

namespace GreatestCommonDivisor
{
    /// <summary>
    /// Class contains methods for calculating the greatest common divisor.
    /// </summary>
    public static class GreatestCommonDivisor
    {
        private delegate int GreatestCommonDivisorOfTwoNumbers(int firstNumber, int secondNumber);

        /// <summary>
        /// Calculates the greatest common divisor of two numbers by the Euclidean method.
        /// </summary>
        /// <param name="firstNumber">First number.</param>
        /// <param name="secondNumber">Second number.</param>
        /// <returns>The greatest common divisor of two numbers.</returns>
        public static int EuclideanAlgorithm(int firstNumber, int secondNumber)
        {
            firstNumber = Math.Abs(firstNumber);
            secondNumber = Math.Abs(secondNumber);

            if (firstNumber == 0 && secondNumber == 0)
            {
                return -1;
            }

            if (firstNumber < secondNumber)
            {
                Swap(ref firstNumber, ref secondNumber);
            }

            int remainder;
            while (secondNumber > 0)
            {
                remainder = firstNumber % secondNumber;
                firstNumber = secondNumber;
                secondNumber = remainder;
            }

            return firstNumber;
        }

        /// <summary>
        /// Calculates the greatest common divisor of two numbers by the Euclidean method.
        /// </summary>
        /// <param name="ticksSpentOnCalculations">Ticks spent on calculations.</param>
        /// <param name="firstNumber">First number.</param>
        /// <param name="secondNumber">Second number.</param>
        /// <returns>The greatest common divisor of two numbers.</returns>
        public static int EuclideanAlgorithm(out long ticksSpentOnCalculations, int firstNumber, int secondNumber)
        {
            return GreatestCommonDivisorAlgorithm(out ticksSpentOnCalculations, EuclideanAlgorithm, firstNumber,
                secondNumber);
        }

        /// <summary>
        /// Calculates the greatest common divisor of three numbers by the Euclidean method.
        /// </summary>
        /// <param name="firstNumber">First number.</param>
        /// <param name="secondNumber">Second number.</param>
        /// <param name="thirdNumber">Third number.</param>
        /// <returns>The greatest common divisor of three numbers.</returns>
        public static int EuclideanAlgorithm(int firstNumber, int secondNumber, int thirdNumber)
        {
            return GreatestCommonDivisorAlgorithm(EuclideanAlgorithm, firstNumber, secondNumber, thirdNumber);
        }


        /// <summary>
        /// Calculates the greatest common divisor of three numbers by the Euclidean method.
        /// </summary>
        /// <param name="ticksSpentOnCalculations">Ticks spent on calculations.</param>
        /// <param name="firstNumber">First number.</param>
        /// <param name="secondNumber">Second number.</param>
        /// <param name="thirdNumber">Third number.</param>
        /// <returns>The greatest common divisor of three numbers.</returns>
        public static int EuclideanAlgorithm(
            out long ticksSpentOnCalculations,
            int firstNumber,
            int secondNumber,
            int thirdNumber)
        {
            return GreatestCommonDivisorAlgorithm(out ticksSpentOnCalculations,
                EuclideanAlgorithm, firstNumber, secondNumber, thirdNumber);
        }

        /// <summary>
        /// Calculates the greatest common divisor of numbers by the Euclidean method.
        /// </summary>
        /// <param name="firstNumber">First number.</param>
        /// <param name="secondNumber">Second number.</param>
        /// <param name="numbers">Accepts any number of input parameters.</param>
        /// <returns>The greatest common divisor of numbers.</returns>
        public static int EuclideanAlgorithm(int firstNumber, int secondNumber, params int[] numbers)
        {
            return GreatestCommonDivisorAlgorithm(EuclideanAlgorithm, firstNumber, secondNumber, numbers);
        }

        /// <summary>
        /// Calculates the greatest common divisor of numbers by the Euclidean method.
        /// </summary>
        /// <param name="ticksSpentOnCalculations">Ticks spent on calculations.</param>
        /// <param name="firstNumber">First number.</param>
        /// <param name="secondNumber">Second number.</param>
        /// <param name="numbers">Accepts any number of input parameters.</param>
        /// <returns>The greatest common divisor of numbers.</returns>
        public static int EuclideanAlgorithm(out long ticksSpentOnCalculations, int firstNumber, int secondNumber,
            params int[] numbers)
        {
            return GreatestCommonDivisorAlgorithm(out ticksSpentOnCalculations, EuclideanAlgorithm, firstNumber,
                secondNumber, numbers);
        }

        /// <summary>
        /// Calculates the greatest common divisor of two numbers by the binary algorithm.
        /// </summary>
        /// <param name="firstNumber">First number.</param>
        /// <param name="secondNumber">Second number.</param>
        /// <returns>The greatest common divisor of two numbers.</returns>
        public static int BinaryAlgorithm(int firstNumber, int secondNumber)
        {
            firstNumber = Math.Abs(firstNumber);
            secondNumber = Math.Abs(secondNumber);

            if (firstNumber == 0 && secondNumber == 0)
            {
                return -1;
            }

            if (firstNumber == 0 || secondNumber == 0)
            {
                return Math.Max(firstNumber, secondNumber);
            }

            int shift;
            for (shift = 0; ((firstNumber | secondNumber) & 1) == 0; ++shift)
            {
                firstNumber >>= 1;
                secondNumber >>= 1;
            }

            while ((firstNumber & 1) == 0)
            {
                firstNumber >>= 1;
            }

            do
            {
                while ((secondNumber & 1) == 0)
                {
                    secondNumber >>= 1;
                }

                if (firstNumber > secondNumber)
                {
                    Swap(ref firstNumber, ref secondNumber);
                }

                secondNumber = secondNumber - firstNumber;
            } while (secondNumber != 0);

            return firstNumber << shift;
        }

        /// <summary>
        /// Calculates the greatest common divisor of two numbers by the binary algorithm.
        /// </summary>
        /// <param name="ticksSpentOnCalculations">Ticks spent on calculations.</param>
        /// <param name="firstNumber">First number.</param>
        /// <param name="secondNumber">Second number.</param>
        /// <returns>The greatest common divisor of two numbers.</returns>
        public static int BinaryAlgorithm(out long ticksSpentOnCalculations, int firstNumber, int secondNumber)
        {
            return GreatestCommonDivisorAlgorithm(out ticksSpentOnCalculations, BinaryAlgorithm, firstNumber,
                secondNumber);
        }

        /// <summary>
        /// Calculates the greatest common divisor of two numbers by the binary algorithm.
        /// </summary>
        /// <param name="firstNumber">First number.</param>
        /// <param name="secondNumber">Second number.</param>
        /// <param name="thirdNumber">Third number.</param>
        /// <returns>The greatest common divisor of three numbers.</returns>
        public static int BinaryAlgorithm(int firstNumber, int secondNumber, int thirdNumber)
        {
            return GreatestCommonDivisorAlgorithm(BinaryAlgorithm, firstNumber, secondNumber, thirdNumber);
        }

        /// <summary>
        /// Calculates the greatest common divisor of two numbers by the binary algorithm.
        /// </summary>
        /// <param name="ticksSpentOnCalculations">Ticks spent on calculations.</param>
        /// <param name="firstNumber">First number.</param>
        /// <param name="secondNumber">Second number.</param>
        /// <param name="thirdNumber">Third number.</param>
        /// <returns>The greatest common divisor of three numbers.</returns>
        public static int BinaryAlgorithm(
            out long ticksSpentOnCalculations,
            int firstNumber,
            int secondNumber,
            int thirdNumber)
        {
            return GreatestCommonDivisorAlgorithm(out ticksSpentOnCalculations, BinaryAlgorithm, firstNumber,
                secondNumber, thirdNumber);
        }

        /// <summary>
        /// Calculates the greatest common divisor of two numbers by the binary algorithm.
        /// </summary>
        /// <param name="firstNumber">First number.</param>
        /// <param name="secondNumber">Second number.</param>
        /// <param name="numbers">Accepts any number of input parameters.</param>
        /// <returns>The greatest common divisor of numbers.</returns>
        public static int BinaryAlgorithm(int firstNumber, int secondNumber, params int[] numbers)
        {
            return GreatestCommonDivisorAlgorithm(BinaryAlgorithm, firstNumber, secondNumber, numbers);
        }

        /// <summary>
        /// Calculates the greatest common divisor of two numbers by the binary algorithm.
        /// </summary>
        /// <param name="ticksSpentOnCalculations">Ticks spent on calculations.</param>
        /// <param name="firstNumber">First number.</param>
        /// <param name="secondNumber">Second number.</param>
        /// <param name="numbers">Accepts any number of input parameters.</param>
        /// <returns>The greatest common divisor of numbers.</returns>
        public static int BinaryAlgorithm(out long ticksSpentOnCalculations, int firstNumber, int secondNumber,
            params int[] numbers)
        {
            return GreatestCommonDivisorAlgorithm(out ticksSpentOnCalculations, BinaryAlgorithm, firstNumber,
                secondNumber, numbers);
        }

        private static int GreatestCommonDivisorAlgorithm(GreatestCommonDivisorOfTwoNumbers gcd, int firstNumber,
            int secondNumber, params int[] numbers)
        {
            var firstSecondDivisor = gcd.Invoke(firstNumber, secondNumber);

            if (numbers.Length == 0)
            {
                return firstSecondDivisor;
            }

            numbers[0] = gcd.Invoke(firstSecondDivisor, numbers[0]);

            for (int i = 1; i < numbers.Length; ++i)
            {
                if (numbers[i - 1] == -1)
                {
                    numbers[i - 1] = 0;
                }

                numbers[i] = gcd.Invoke(numbers[i - 1], numbers[i]);
            }

            return numbers[numbers.Length - 1];
        }

        private static int GreatestCommonDivisorAlgorithm(out long ticksSpentOnCalculations,
            GreatestCommonDivisorOfTwoNumbers gcd, int firstNumber, int secondNumber, params int[] numbers)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            var greatestCommonDivisor = GreatestCommonDivisorAlgorithm(gcd, firstNumber, secondNumber, numbers);

            stopWatch.Stop();
            ticksSpentOnCalculations = stopWatch.Elapsed.Ticks;

            return greatestCommonDivisor;
        }

        private static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
    }
}