using NUnit.Framework;

namespace GreatestCommonDivisor.Tests
{
    [TestFixture]
    public class GreatestCommonDivisorTests
    {
        [TestCase(5, 6, ExpectedResult = 1)]
        [TestCase(12, 144, ExpectedResult = 12)]
        [TestCase(1, 0, ExpectedResult = 1)]
        [TestCase(0, 5, ExpectedResult = 5)]
        [TestCase(6, 6, ExpectedResult = 6)]
        [TestCase(0, 0, ExpectedResult = -1)]
        [TestCase(-5, 10, ExpectedResult = 5)]
        public int EuclideanAlgorithm_TwoIntegers_ExpectedTheGreatestCommonDivisorOfTwoNumbers(
            int firstNumber,
            int secondNumber)
        {
            return GreatestCommonDivisor.EuclideanAlgorithm(firstNumber, secondNumber);
        }

        [TestCase(5, 6, 2, ExpectedResult = 1)]
        [TestCase(12, 144, 6, ExpectedResult = 6)]
        [TestCase(1, 0, 0, ExpectedResult = 1)]
        [TestCase(6, 6, 0, ExpectedResult = 6)]
        public int EuclideanAlgorithm_ThreeIntegers_ExpectedTheGreatestCommonDivisorOfThreeNumbers(
            int firstNumber,
            int secondNumber,
            int thirdNumber)
        {
            return GreatestCommonDivisor.EuclideanAlgorithm(firstNumber, secondNumber, thirdNumber);
        }

        [TestCase(5, 6, 2, 2, ExpectedResult = 1)]
        [TestCase(12, 144, 6, 144, 3, ExpectedResult = 3)]
        [TestCase(1, 0, 0, 1, 100, -98, ExpectedResult = 1)]
        [TestCase(6, 6, 0, 0, -12, -24, -96, ExpectedResult = 6)]
        public int EuclideanAlgorithm_Integers_ExpectedTheGreatestCommonDivisorOfNumbers(int firstNumber, int secondNumber, params int[] numbers)
        {
            return GreatestCommonDivisor.EuclideanAlgorithm(firstNumber, secondNumber, numbers);
        }

        [TestCase(5, 6, ExpectedResult = 1)]
        [TestCase(12, 144, ExpectedResult = 12)]
        [TestCase(1, 0, ExpectedResult = 1)]
        [TestCase(0, 5, ExpectedResult = 5)]
        [TestCase(6, 6, ExpectedResult = 6)]
        [TestCase(0, 0, ExpectedResult = -1)]
        [TestCase(-5, 10, ExpectedResult = 5)]
        public int BinaryAlgorithm_TwoIntegers_ExpectedTheGreatestCommonDivisorOfTwoNumbers(
            int firstNumber,
            int secondNumber)
        {
            return GreatestCommonDivisor.BinaryAlgorithm(firstNumber, secondNumber);
        }

        [TestCase(5, 6, 2, ExpectedResult = 1)]
        [TestCase(12, 144, 6, ExpectedResult = 6)]
        [TestCase(1, 0, 0, ExpectedResult = 1)]
        [TestCase(6, 6, 0, ExpectedResult = 6)]
        public int BinaryAlgorithm_ThreeIntegers_ExpectedTheGreatestCommonDivisorOfThreeNumbers(
            int firstNumber,
            int secondNumber,
            int thirdNumber)
        {
            return GreatestCommonDivisor.BinaryAlgorithm(firstNumber, secondNumber, thirdNumber);
        }

        [TestCase(5, 6, 2, 2, ExpectedResult = 1)]
        [TestCase(12, 144, 6, 144, 3, ExpectedResult = 3)]
        [TestCase(1, 0, 0, 1, 100, -98, ExpectedResult = 1)]
        [TestCase(6, 6, 0, 0, -12, -24, -96, ExpectedResult = 6)]
        public int BinaryAlgorithm_Integers_ExpectedTheGreatestCommonDivisorOfNumbers(int firstNumber, int secondNumber, params int[] numbers)
        {
            return GreatestCommonDivisor.BinaryAlgorithm(firstNumber, secondNumber, numbers);
        }
    }
}