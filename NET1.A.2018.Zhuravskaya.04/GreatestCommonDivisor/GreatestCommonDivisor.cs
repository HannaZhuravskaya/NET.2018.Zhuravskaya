using System;
using System.Diagnostics;

namespace GreatestCommonDivisor
{
    /// <summary>
    /// Сlass contains methods for calculating the greatest common divisor.
    /// </summary>
    public static class GreatestCommonDivisor
    {
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
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            var greatestCommonDivisor = EuclideanAlgorithm(firstNumber, secondNumber);

            stopWatch.Stop();
            ticksSpentOnCalculations = stopWatch.Elapsed.Ticks;

            return greatestCommonDivisor;
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
            int firstSecondGreatestCommonDivisor = EuclideanAlgorithm(firstNumber, secondNumber);
            if (firstSecondGreatestCommonDivisor == -1)
            {
                firstSecondGreatestCommonDivisor = 0;
            }

            return EuclideanAlgorithm(firstSecondGreatestCommonDivisor, thirdNumber);
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
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            var greatestCommonDivisor = EuclideanAlgorithm(firstNumber, secondNumber, thirdNumber);

            stopWatch.Stop();
            ticksSpentOnCalculations = stopWatch.Elapsed.Ticks;

            return greatestCommonDivisor;
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
            int firstSecondGreatestCommonDivisor = EuclideanAlgorithm(firstNumber, secondNumber);

            if (firstSecondGreatestCommonDivisor == -1)
            {
                firstSecondGreatestCommonDivisor = 0;
            }

            numbers[0] = EuclideanAlgorithm(firstSecondGreatestCommonDivisor, numbers[0]);
            
            for (int i = 1; i < numbers.Length; ++i)
            {
                if (numbers[i - 1] == -1)
                {
                    numbers[i - 1] = 0;
                }

                numbers[i] = EuclideanAlgorithm(numbers[i - 1], numbers[i]);
            }

            return numbers[numbers.Length - 1];
        }

        /// <summary>
        /// Calculates the greatest common divisor of numbers by the Euclidean method.
        /// </summary>
        /// <param name="ticksSpentOnCalculations">Ticks spent on calculations.</param>
        /// <param name="firstNumber">First number.</param>
        /// <param name="secondNumber">Second number.</param>
        /// <param name="numbers">Accepts any number of input parameters.</param>
        /// <returns>The greatest common divisor of numbers.</returns>
        public static int EuclideanAlgorithm(out long ticksSpentOnCalculations, int firstNumber, int secondNumber, params int[] numbers)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            var greatestCommonDivisor = EuclideanAlgorithm(firstNumber, secondNumber, numbers);

            stopWatch.Stop();
            ticksSpentOnCalculations = stopWatch.Elapsed.Ticks;

            return greatestCommonDivisor;
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

            if (firstNumber == 0)
            {
                return secondNumber;
            }

            if (secondNumber == 0)
            {
                return firstNumber;
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
            }
            while (secondNumber != 0);

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
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            var greatestCommonDivisor = BinaryAlgorithm(firstNumber, secondNumber);

            stopWatch.Stop();
            ticksSpentOnCalculations = stopWatch.Elapsed.Ticks;

            return greatestCommonDivisor;
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
            var firstSecondGreatestCommonDivisor = BinaryAlgorithm(firstNumber, secondNumber);
            if (firstSecondGreatestCommonDivisor == -1)
            {
                firstSecondGreatestCommonDivisor = 0;
            }

            return BinaryAlgorithm(firstSecondGreatestCommonDivisor, thirdNumber);
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
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            var greatestCommonDivisor = BinaryAlgorithm(firstNumber, secondNumber, thirdNumber);

            stopWatch.Stop();
            ticksSpentOnCalculations = stopWatch.Elapsed.Ticks;

            return greatestCommonDivisor;
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
            int firstSecondGreatestCommonDivisor = BinaryAlgorithm(firstNumber, secondNumber);

            if (firstSecondGreatestCommonDivisor == -1)
            {
                firstSecondGreatestCommonDivisor = 0;
            }

            numbers[0] = BinaryAlgorithm(firstSecondGreatestCommonDivisor, numbers[0]);

            for (int i = 1; i < numbers.Length; ++i)
            {
                if (numbers[i - 1] == -1)
                {
                    numbers[i - 1] = 0;
                }

                numbers[i] = BinaryAlgorithm(numbers[i - 1], numbers[i]);
            }

            return numbers[numbers.Length - 1];
        }

        /// <summary>
        /// Calculates the greatest common divisor of two numbers by the binary algorithm.
        /// </summary>
        /// <param name="ticksSpentOnCalculations">Ticks spent on calculations.</param>
        /// <param name="firstNumber">First number.</param>
        /// <param name="secondNumber">Second number.</param>
        /// <param name="numbers">Accepts any number of input parameters.</param>
        /// <returns>The greatest common divisor of numbers.</returns>
        public static int BinaryAlgorithm(out long ticksSpentOnCalculations, int firstNumber, int secondNumber, params int[] numbers)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            var greatestCommonDivisor = BinaryAlgorithm(firstNumber, secondNumber, numbers);

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