﻿using NUnit.Framework;

namespace JaggedSort.Tests
{
    [TestFixture]
    public class SortingBySumOfElementsInDescendingOrderTests
    {
        [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7 }, ExpectedResult = 28)]
        [TestCase(new[] { -1, -2, -3, -4, -5, -6, -7 }, ExpectedResult = -28)]
        [TestCase(new[] { 0, 0, 0 }, ExpectedResult = 0)]
        public int RowPriority_NotEmptyRow_SumOfElementsOfTheRow(int[] row)
        {
            return new SortingBySumOfElementsInDescendingOrder().RowPriority(row);
        }

        [Test]
        public void RowPriority_EmptyRow_IntMinValue()
        {
            var result = new SortingBySumOfElementsInDescendingOrder().RowPriority(new int[0]);

            var expectedResult = int.MinValue;

            Assert.AreEqual(result, expectedResult);
        }

        [Test]
        public void RowPriority_RowIsNull_IntMinValue()
        {
            var result = new SortingBySumOfElementsInDescendingOrder().RowPriority(null);

            var expectedResult = int.MinValue;

            Assert.AreEqual(result, expectedResult);
        }
    }
}
