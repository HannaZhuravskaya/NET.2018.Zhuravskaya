using NUnit.Framework;

namespace Task1.Tests
{
    using System;

    [TestFixture]
    public class TransformTests
    {
        [TestCase(
            new[] { -23.809, 0.295, 15.17 },
            new[] { "minus two three point eight zero nine", "zero point two nine five", "one five point one seven" })]
        [TestCase(
            new[] { -0.00001, 1234.1234 },
            new[] { "minus zero point zero zero zero zero one", "one two three four point one two three four" })]

        public void TransformToWords_ArrayOfNumbers_ExpectedArrayOfNumbersNames(double[] numbers, string[] numbersNames)
        {
            Assert.True(CheckResult(numbersNames, Transform.TransformToWords(numbers)));
        }

        public void TransformToWords_Null_ExpectedArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => Transform.TransformToWords(null));

        [TestCase(
            new[] { -255.255, 255.255, 4294967295.0 },
            new[]
            {
                "1100000001101111111010000010100011110101110000101000111101011100",
                "0100000001101111111010000010100011110101110000101000111101011100",
                "0100000111101111111111111111111111111111111000000000000000000000"
            })]
        [TestCase(
            new[] { -0.00001, 1234.1234 },
            new[]
            {
                "1011111011100100111110001011010110001000111000110110100011110001",
                "0100000010010011010010000111111001011100100100011101000101001110"
            })]
        public void TransformToIEEE754Strings_ArrayOfNumbers_ExpectedArrayOfIEEE754Strings(
            double[] numbers,
            string[] numbersNames)
        {
            Assert.True(CheckResult(numbersNames, Transform.TransformToIEEE754Strings(numbers)));
        }

        public void TransformToIEEE754Strings_ExpectedArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => Transform.TransformToWords(null));

        private static bool CheckResult(string[] expectedResult, string[] result)
        {
            for (int i = 0; i < result.Length; ++i)
            {
                if (!result[i].Equals(expectedResult[i]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
