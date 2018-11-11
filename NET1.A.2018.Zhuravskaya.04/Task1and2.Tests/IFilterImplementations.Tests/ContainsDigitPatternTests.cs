using System;
using NUnit.Framework;
using Task1and2.IFilterImplementations;

namespace Task1and2.Tests.IFilterImplementations.Tests
{
    [TestFixture]
    class ContainsDigitPatternTests
    {
        [TestCase(new int[] { 2, 3, 13, 1, 4, 15, -8, 0 }, new int[] { 3, 13 }, 3)]
        public void IsFitThePattern_ArrayOfNumbers_ArrayOfNumbersContainsDigitPattern(int[] sourceArray, int[] filteredArray, int digitPattern)
        {
            CollectionAssert.AreEqual(sourceArray.Filter(new ContainsDigitPattern(digitPattern)), filteredArray);
        }

        [TestCase(new int[] {2, 3, 13, 1, 4, 15, -8, 0}, new int[] {2, 4, -8, 0}, 10)]
        [TestCase(new int[] { 2, 3, 13, 1, 4, 15, -8, 0 }, new int[] { 2, 4, -8, 0 }, -1)]
        public void IsFitThePattern_ArrayOfNumbers_ExpectedArgumentException(int[] sourceArray, int[] filteredArray,
            int digitPattern)
            => Assert.Throws<ArgumentException>(() => sourceArray.Filter(new ContainsDigitPattern(digitPattern)));
    }
}
