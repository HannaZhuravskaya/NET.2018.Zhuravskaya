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

        public void TransformToWords_ArayOfNumbers_ExpectedArrayOfNumbersNames(double[] numbers, string[] numbersNames)
        {
            Assert.True(CheckResult(numbersNames, Transform.TransformToWords(numbers)));
        }

        public void TransformToWords_Null_ExpectedArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => Transform.TransformToWords(null));

        private static bool CheckResult(string[] result, string[] expectedResult)
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
