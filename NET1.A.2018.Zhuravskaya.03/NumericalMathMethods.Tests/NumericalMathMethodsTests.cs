using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NumericalMathMethods.Tests
{
    [TestClass]
    public class NumericalMathMethodsTests
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        [DataSource(
            "Microsoft.VisualStudio.TestTools.DataSource.XML",
            "D:\\Visual Studio 2017\\DataSources\\03.FindNextBiggerNumber.DataSource.xml",
            "TestCase",
            DataAccessMethod.Sequential)]
        public void FindNextBiggerNumber_NumberHavingTheNearestLargerInteger_ExpectedTheNearestLargerInteger()
        {
            var sourceNumber = Convert.ToInt32(TestContext.DataRow["sourceNumber"]);
            var expectedResult = Convert.ToInt32(TestContext.DataRow["expectedResult"]);

            var result = NumericalMathMethods.FindNextBiggerNumber(sourceNumber);
            Assert.AreEqual(result, expectedResult);
        }

        [DataTestMethod]
        [DataRow(21)]
        [DataRow(10)]
        [DataRow(20)]
        public void FindNextBiggerNumber_NumberNotHavingTheNearestLargerInteger_ExpectedMinusOne(int number) =>
            Assert.AreEqual(-1, NumericalMathMethods.FindNextBiggerNumber(number));

        [DataTestMethod]
        [DataRow(-1)]
        [DataRow(-10)]
        [DataRow(-1000)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FindNextBiggerNumber_NegativeNumber_ExpectedArgumentOutOfRangeException(int number) =>
            NumericalMathMethods.FindNextBiggerNumber(number);

        [TestMethod]
        [DataSource(
            "Microsoft.VisualStudio.TestTools.DataSource.XML",
            "D:\\Visual Studio 2017\\DataSources\\03.FindNthRoot.DataSource.xml",
            "TestCase",
            DataAccessMethod.Sequential)]
        public void FindNthRoot_CorrectNumber_TheNthRootOfASourceNumber()
        {
            double sourceNumber = Convert.ToDouble(TestContext.DataRow["sourceNumber"]);
            int degree = Convert.ToInt32(TestContext.DataRow["degree"]);
            double accuracy = Convert.ToDouble(TestContext.DataRow["accuracy"]);

            double expectedResult = Convert.ToDouble(TestContext.DataRow["expectedResult"]);

            Assert.IsTrue(
                Math.Abs(NumericalMathMethods.FindNthRoot(sourceNumber, degree, accuracy) - expectedResult) < accuracy);
        }

        [DataTestMethod]
        [DataRow(0.001, -2, 0.0001)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FindNthRoot_NegativeDegree_ExpectedArgumentOutOfRangeException(
            double number,
            int degree,
            double accuracy) =>
            NumericalMathMethods.FindNthRoot(number, degree, accuracy);

        [DataTestMethod]
        [DataRow(0.001, 2, -0.0001)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FindNthRoot_NotPositiveAccuracy_ExpectedArgumentOutOfRangeException(
            double number,
            int degree,
            double accuracy) =>
            NumericalMathMethods.FindNthRoot(number, degree, accuracy);

        [DataTestMethod]
        [DataRow(-0.01, 2, 0.0001)]
        [ExpectedException(typeof(ArgumentException))]
        public void FindNthRoot_EvenDegreeAndNegativeNumber_ExpectedArgumentException(
            double number,
            int degree,
            double accuracy) =>
            NumericalMathMethods.FindNthRoot(number, degree, accuracy);
    }
}