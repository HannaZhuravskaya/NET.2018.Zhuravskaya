using System;
using NUnit.Framework;
using System.Collections;

namespace Task1.NUnitTests
{
    [TestFixture]
    public class Int32BitOperationTests
    {
        [TestCase(15, 15, 0, 0, ExpectedResult = 15)]
        [TestCase(8, 15, 0, 0, ExpectedResult = 9)]
        [TestCase(8, 15, 3, 8, ExpectedResult = 120)]
        public int InsertNumber_CorrectData_ExpectedCorrectAnswer(int num1, int num2, int startIndex, int endIndex)
        {
            return Int32BitOperations.InsertNumber(num1, num2, startIndex, endIndex);
        }

        [Test, TestCaseSource(typeof(DataForTests), nameof(DataForTests.StartIndexToInsertingOrEndIndexToInsertingGreaterThan31OrLessThan0))]
        public void InsertNumber_StartIndexToInsertingOrEndIndexToInsertingGreaterThan31OrLessThan0_ThrowArgumentOutOfRangeException(int num1, int num2, int startIndex, int endIndex)
            => Assert.Throws<ArgumentOutOfRangeException>(() => Int32BitOperations.InsertNumber(num1, num2, startIndex, endIndex));

        [Test, TestCaseSource(typeof(DataForTests), nameof(DataForTests.StartIndexToInsertingGreaterThanEndIndexToInserting))]
        public void InsertNumber_StartIndexToInsertingGreaterThanEndIndexToInserting_ArgumentException(int num1, int num2, int startIndex, int endIndex)
            => Assert.Throws<ArgumentException>(() => Int32BitOperations.InsertNumber(num1, num2, startIndex, endIndex));
    }

    public class DataForTests
    {
        public static IEnumerable StartIndexToInsertingOrEndIndexToInsertingGreaterThan31OrLessThan0
        {
            get
            {
                yield return new TestCaseData(8, 15, 3, 33);
                yield return new TestCaseData(2, 3, 32, 5);
                yield return new TestCaseData(2, 3, -3, 0);
            }
        }

        public static IEnumerable StartIndexToInsertingGreaterThanEndIndexToInserting
        {
            get
            {
                yield return new TestCaseData(2, 3, 7, 1);
                yield return new TestCaseData(2, 3, 10, 0);
                yield return new TestCaseData(2, 3, 3, 1);
            }
        }
    }
}