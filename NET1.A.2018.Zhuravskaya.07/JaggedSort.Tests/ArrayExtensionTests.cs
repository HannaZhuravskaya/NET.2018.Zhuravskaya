using System;
using System.Collections;
using NUnit.Framework;

namespace JaggedSort.Tests
{
    [TestFixture]
    public class ArrayExtensionTests
    {
        [TestCaseSource(typeof(DataSource), nameof(DataSource.ArrayIsNull))]
        public void SortByRows_ArrayIsNull_ExpectedArgumentNullException(int[][] array, IRowSortingType rowSortingType, bool sortingOrder)
            => Assert.Throws<ArgumentNullException>(() => array.SortByRows(rowSortingType, sortingOrder));

        [TestCaseSource(typeof(DataSource), nameof(DataSource.ArrayLengthIsZero))]
        public void SortByRows_ArrayLengthIsZero_ExpectedArgumentException(int[][] array, IRowSortingType rowSortingType, bool sortingOrder)
            => Assert.Throws<ArgumentException>(() => array.SortByRows(rowSortingType, sortingOrder));

        [TestCaseSource(typeof(DataSource), nameof(DataSource.ArraysToSort))]
        public void SortByRows_NotEmptyArray_SortedByRowsArray(int[] arrayDimensions, int[] arrayElements, IRowSortingType rowSortingType, bool sortingOrder)
        {
            var array = CreateArrayFromData(arrayDimensions, arrayElements);
            array.SortByRows(rowSortingType, sortingOrder);

            Assert.IsTrue(CheckSortingResult(array, rowSortingType, sortingOrder));
        }

        private int[][] CreateArrayFromData(int[] arrayDimensions, int[] arrayElements)
        {
            int[][] array = new int[arrayDimensions.Length][];

            int arrayElementIndex = 0;
            for (int i = 0; i < arrayDimensions.Length; ++i)
            {
                if (arrayDimensions[i] == -1)
                {
                    continue;
                }

                array[i] = new int[arrayDimensions[i]];

                for (int j = 0; j < arrayDimensions[i]; ++j)
                {
                    array[i][j] = arrayElements[arrayElementIndex];
                    arrayElementIndex++;
                }
            }

            return array;
        }

        private bool CheckSortingResult(int[][] sortedArray, IRowSortingType rowSortingType, bool sortOrder)
        {
            if (sortedArray.Length == 1)
            {
                return true;
            }

            var rowsPriority = new int[sortedArray.Length];

            for (int i = 0; i < sortedArray.Length; ++i)
            {
                rowsPriority[i] = rowSortingType.RowPriority(sortedArray[i]);
            }

            for (int i = 1; i < rowsPriority.Length; ++i)
            {
                if (sortOrder)
                {
                    if (rowsPriority[i - 1] > rowsPriority[i])
                    {
                        return false;
                    }
                }
                else
                {
                    if (rowsPriority[i - 1] < rowsPriority[i])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }

    public class DataSource
    {
        public static IEnumerable ArraysToSort
        {
            get
            {
                yield return new TestCaseData(
                    new[] {3, 1, 1},
                    new[] {3, 8, 1, 200, 1},
                    new SortingBySumOfElementsInAscendingOrder(),
                    SortingBySumOfElementsInAscendingOrder.SortOrder);
                yield return new TestCaseData(
                    new[] {3, 1, 1},
                    new[] {3, 8, 1, 200, 1},
                    new SortingBySumOfElementsInDescendingOrder(),
                    SortingBySumOfElementsInDescendingOrder.SortOrder);
                yield return new TestCaseData(
                    new[] {3, 1, 1}, 
                    new[] {3, 8, 1, 200, 1},
                    new SortingByMaxElementsInAscendingOrder(),
                    SortingByMaxElementsInAscendingOrder.SortOrder);
                yield return new TestCaseData(
                    new[] {3, 1, 1},
                    new[] {3, 8, 1, 200, 1},
                    new SortingByMaxElementsInDescendingOrder(),
                    SortingByMaxElementsInDescendingOrder.SortOrder);
                yield return new TestCaseData(
                    new[] {3, 1, 1}, 
                    new[] {3, 8, 1, 200, 1},
                    new SortingByMinElementsInAscendingOrder(), 
                    SortingByMinElementsInAscendingOrder.SortOrder);
                yield return new TestCaseData(
                    new[] {3, 1, 1}, 
                    new[] {3, 8, 1, 200, 1},
                    new SortingByMinElementsInDescendingOrder(), 
                    SortingByMinElementsInDescendingOrder.SortOrder);
                yield return new TestCaseData(
                    new[] { -1, 3, 1, 1 },
                    new[] { 3, 8, 1, 200, 1 },
                    new SortingBySumOfElementsInAscendingOrder(),
                    SortingBySumOfElementsInAscendingOrder.SortOrder);
                yield return new TestCaseData(
                    new[] { -1, 3, 1, 1 },
                    new[] { 3, 8, 1, 200, 1 },
                    new SortingBySumOfElementsInDescendingOrder(),
                    SortingBySumOfElementsInDescendingOrder.SortOrder);
                yield return new TestCaseData(
                    new[] { -1, 3, 1, 1 },
                    new[] { 3, 8, 1, 200, 1 },
                    new SortingByMaxElementsInAscendingOrder(),
                    SortingByMaxElementsInAscendingOrder.SortOrder);
                yield return new TestCaseData(
                    new[] { -1, 3, 1, 1 },
                    new[] { 3, 8, 1, 200, 1 },
                    new SortingByMaxElementsInDescendingOrder(),
                    SortingByMaxElementsInDescendingOrder.SortOrder);
                yield return new TestCaseData(
                    new[] { -1, 3, 1, 1 },
                    new[] { 3, 8, 1, 200, 1 },
                    new SortingByMinElementsInAscendingOrder(),
                    SortingByMinElementsInAscendingOrder.SortOrder);
                yield return new TestCaseData(
                    new[] { -1, 3, 1, 1 },
                    new[] { 3, 8, 1, 200, 1 },
                    new SortingByMinElementsInDescendingOrder(),
                    SortingByMinElementsInDescendingOrder.SortOrder);
            }
        }

        public static IEnumerable ArrayIsNull
        {
            get
            {
                yield return new TestCaseData(
                    null, 
                    new SortingBySumOfElementsInAscendingOrder(),
                    SortingBySumOfElementsInAscendingOrder.SortOrder);
                yield return new TestCaseData(
                    null, 
                    new SortingBySumOfElementsInDescendingOrder(),
                    SortingBySumOfElementsInDescendingOrder.SortOrder);
                yield return new TestCaseData(
                    null, 
                    new SortingByMaxElementsInAscendingOrder(),
                    SortingByMaxElementsInAscendingOrder.SortOrder);
                yield return new TestCaseData(
                    null, 
                    new SortingByMaxElementsInDescendingOrder(),
                    SortingByMaxElementsInDescendingOrder.SortOrder);
                yield return new TestCaseData(
                    null, 
                    new SortingByMinElementsInAscendingOrder(),
                    SortingByMinElementsInAscendingOrder.SortOrder);
                yield return new TestCaseData(
                    null, 
                    new SortingByMinElementsInDescendingOrder(),
                    SortingByMinElementsInDescendingOrder.SortOrder);
            }
        }

        public static IEnumerable ArrayLengthIsZero
        {
            get
            {
                yield return new TestCaseData(
                    new int[0][],
                    new SortingBySumOfElementsInAscendingOrder(),
                    SortingBySumOfElementsInAscendingOrder.SortOrder);
                yield return new TestCaseData(
                    new int[0][], 
                    new SortingBySumOfElementsInDescendingOrder(),
                    SortingBySumOfElementsInDescendingOrder.SortOrder);
                yield return new TestCaseData(
                    new int[0][], 
                    new SortingByMaxElementsInAscendingOrder(),
                    SortingByMaxElementsInAscendingOrder.SortOrder);
                yield return new TestCaseData(
                    new int[0][], 
                    new SortingByMaxElementsInDescendingOrder(),
                    SortingByMaxElementsInDescendingOrder.SortOrder);
                yield return new TestCaseData(
                    new int[0][], 
                    new SortingByMinElementsInAscendingOrder(),
                    SortingByMinElementsInAscendingOrder.SortOrder);
                yield return new TestCaseData(
                    new int[0][], 
                    new SortingByMinElementsInDescendingOrder(),
                    SortingByMinElementsInDescendingOrder.SortOrder);
            }
        }
    }
}