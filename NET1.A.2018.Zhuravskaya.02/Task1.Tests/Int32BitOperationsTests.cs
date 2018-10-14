using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task1;

namespace Task1.Tests
{
    [TestClass]
    public class Int32BitOperationsTests
    {
        [TestMethod]
        public void InsertNumber_15InsertTo15From0To0_Return15()
        {
            int num1 = 15;
            int num2 = 15;
            int startIndex = 0;
            int endIndex = 0;
            int expected = 15;

            int result = Int32BitOperations.InsertNumber(num1, num2, startIndex, endIndex);

            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void InsertNumber_15InsertTo8From0To0_Return9()
        {
            int num1 = 8;
            int num2 = 15;
            int startIndex = 0;
            int endIndex = 0;
            int expected = 9;

            int result = Int32BitOperations.InsertNumber(num1, num2, startIndex, endIndex);

            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void InsertNumber_15InsertTo8From3To8_Return120()
        {
            int num1 = 8;
            int num2 = 15;
            int startIndex = 3;
            int endIndex = 8;
            int expected = 120;

            int result = Int32BitOperations.InsertNumber(num1, num2, startIndex, endIndex);

            Assert.AreEqual(result, expected);
        }

        [DataTestMethod]
        [DataRow(8, 15, 3, 33)]
        [DataRow(2, 3, 32, 5)]
        [DataRow(2, 3, -3, 0)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void InsertNumber_StartIndexToInsertingOrEndIndexToInsertingGreaterThan31OrLessThan0_ThrowArgumentOutOfRangeException(int num1, int num2, int startIndex, int endIndex)
            => Int32BitOperations.InsertNumber(num1, num2, startIndex, endIndex);

        [DataTestMethod]
        [DataRow(2, 3, 7, 1)]
        [DataRow(2, 3, 10, 0)]
        [DataRow(2, 3, 3, 1)]
        [ExpectedException(typeof(ArgumentException))]
        public void InsertNumber_StartIndexToInsertingGreaterThanEndIndexToInserting_ThrowArgumentException(int num1, int num2, int startIndex, int endIndex)
            => Int32BitOperations.InsertNumber(num1, num2, startIndex, endIndex);
    }
}
