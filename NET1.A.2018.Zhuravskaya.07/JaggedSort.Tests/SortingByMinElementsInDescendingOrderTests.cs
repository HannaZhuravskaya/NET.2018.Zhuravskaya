using NUnit.Framework;

namespace JaggedSort.Tests
{
    [TestFixture]
    public class SortingByMinElementsInDescendingOrderTests
    {
        [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7 }, ExpectedResult = 1)]
        [TestCase(new[] { -1, -2, -3, -4, -5, -6, -7 }, ExpectedResult = -7)]
        [TestCase(new[] { 0, 0, 0 }, ExpectedResult = 0)]
        public int RowPriority_NotEmptyRow_MinElementOfTheRow(int[] row)
        {
            return new SortingByMinElementsInDescendingOrder().RowPriority(row);
        }

        [Test]
        public void RowPriority_EmptyRow_IntMinValue()
        {
            var result = new SortingByMinElementsInDescendingOrder().RowPriority(new int[0]);

            var expectedResult = int.MinValue;

            Assert.AreEqual(result, expectedResult);
        }

        [Test]
        public void RowPriority_RowIsNull_IntMinValue()
        {
            var result = new SortingByMinElementsInDescendingOrder().RowPriority(null);

            var expectedResult = int.MinValue;

            Assert.AreEqual(result, expectedResult);
        }
    }
}