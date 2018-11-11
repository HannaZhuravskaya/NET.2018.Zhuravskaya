using NUnit.Framework;
using Task1and2.IFilterImplementations;

namespace Task1and2.Tests.IFilterImplementations.Tests
{
    [TestFixture]
    class PrimeNumberTests
    {
        [TestCase(new int[]{2, 3, 13, 1, 4, 15, -8, 0},new int[]{ 2, 3, 13})]
        public void IsFitThePattern_ArrayOfNumbers_ArrayOfPrimeNumbers(int[] sourceArray, int[] filteredArray)
        {
            CollectionAssert.AreEqual(sourceArray.Filter(new PrimeNumberPattern()), filteredArray);
        }
    }
}
