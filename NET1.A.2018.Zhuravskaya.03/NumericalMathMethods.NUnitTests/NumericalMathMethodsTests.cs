using NUnit.Framework;

namespace NumericalMathMethods.NUnitTests
{
    using System;

    [TestFixture]
    public class NumericalMathMethodsTests
    {
        [TestCase(12, ExpectedResult = 21)]
        [TestCase(513, ExpectedResult = 531)]
        [TestCase(2017, ExpectedResult = 2071)]
        [TestCase(414, ExpectedResult = 441)]
        [TestCase(144, ExpectedResult = 414)]
        [TestCase(1234321, ExpectedResult = 1241233)]
        [TestCase(1234126, ExpectedResult = 1234162)]
        [TestCase(3456432, ExpectedResult = 3462345)]
        public int FindNextBiggerNumber_NumberHavingTheNearestLargerInteger_ExpectedTheNearestLargerInteger(int number)
        {
            return NumericalMathMethods.FindNextBiggerNumber(number);
        }

        [TestCase(21)]
        [TestCase(10)]
        [TestCase(20)]
        public void FindNextBiggerNumber_NumberNotHavingTheNearestLargerInteger_ExpectedMinusOne(int number)
        {
            Assert.AreEqual(-1, NumericalMathMethods.FindNextBiggerNumber(number));
        }

        [TestCase(-1)]
        [TestCase(-10)]
        [TestCase(-1000)]
        public void FindNextBiggerNumber_NegativeNumber_ExpectedArgumentOutOfRangeException(int number) =>
            Assert.Throws<ArgumentOutOfRangeException>(() => NumericalMathMethods.FindNextBiggerNumber(number));


        [TestCase(1, 5, 0.0001, 1)]
        [TestCase(8, 3, 0.0001, 2)]
        [TestCase(0.001, 3, 0.0001, 0.1)]
        [TestCase(0.04100625, 4, 0.0001, 0.45)]
        [TestCase(8, 3, 0.0001, 2)]
        [TestCase(0.0279936, 7, 0.0001, 0.6)]
        [TestCase(0.0081, 4, 0.1, 0.3)]
        [TestCase(-0.008, 3, 0.1, -0.2)]
        [TestCase(0.004241979, 9, 0.00000001, 0.545)]
        public void FindNthRoot_CorrectNumber_TheNthRootOfASourceNumber(
            double number,
            int degree,
            double accuracy,
            double expectedResult)
        {
            Assert.True(
                Math.Abs(NumericalMathMethods.FindNthRoot(number, degree, accuracy) - expectedResult) < accuracy);
        }

        [TestCase(0.001, -2, 0.0001)]
        public void FindNthRoot_NegativeDegree_ExpectedArgumentOutOfRangeException(
            double number,
            int degree,
            double accuracy) =>
            Assert.Throws<ArgumentOutOfRangeException>(
                () => NumericalMathMethods.FindNthRoot(number, degree, accuracy));

        [TestCase(0.001, 2, -0.0001)]
        public void FindNthRoot_NotPositiveAccuracy_ExpectedArgumentOutOfRangeException(
            double number,
            int degree,
            double accuracy) =>
            Assert.Throws<ArgumentOutOfRangeException>(
                () => NumericalMathMethods.FindNthRoot(number, degree, accuracy));

        [TestCase(-0.01, 2, 0.0001)]
        public void FindNthRoot_EvenDegreeAndNegativeNumber_ExpectedArgumentException(
            double number,
            int degree,
            double accuracy) =>
            Assert.Throws<ArgumentException>(() => NumericalMathMethods.FindNthRoot(number, degree, accuracy));
    }
}
