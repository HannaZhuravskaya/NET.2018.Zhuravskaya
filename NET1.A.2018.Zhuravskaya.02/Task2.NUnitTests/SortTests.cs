using System;
using System.Collections;
using NUnit.Framework;
using static Task2.Sort;

namespace Task2.NUnitTests
{
    [TestFixture]
    public class SortTests
    {
        [Test]
        public void MergeSort_EmptyArray_ArgumentException()
           => Assert.Throws<ArgumentException>(() => MergeSort(new int[] { }));

        [Test]
        public void MergeSort_ArrayIsNull_ArgumentNullException()
           => Assert.Throws<ArgumentNullException>(() => MergeSort(null));

        [TestCaseSource(typeof(DataForTests), nameof(DataForTests.SortedArray_SortedArray))]
        public void MergeSort_SortedArray_ExpectNotChangedArray(int[] arrayToSort)
        {
            MergeSort(arrayToSort);

            Assert.True(IsArraySorted(arrayToSort));
        }

        [TestCaseSource(typeof(DataForTests), nameof(DataForTests.ReversedSortedArray_SortedInDirectOrderArray))]
        public void MergeSort_ReverseSortedArray_ExpectSortedInDirectOrderArray(int[] arrayToSort)
        {
            MergeSort(arrayToSort);

            Assert.True(IsArraySorted(arrayToSort));
        }

        [Test]
        public void QuickSort_EmptyArray_ArgumentException()
            => Assert.Throws<ArgumentException>(() => QuickSort(new int[] { }));

        [Test]
        public void QuickSort_ArrayIsNull_ArgumentNullException()
           => Assert.Throws<ArgumentNullException>(() => QuickSort(null));

        [TestCaseSource(typeof(DataForTests), nameof(DataForTests.SortedArray_SortedArray))]
        public void QuickSort_SortedArray_ExpectNotChangedArray(int[] arrayToSort)
        {
            QuickSort(arrayToSort);

            Assert.True(IsArraySorted(arrayToSort));
        }

        [TestCaseSource(typeof(DataForTests), nameof(DataForTests.ReversedSortedArray_SortedInDirectOrderArray))]
        public void QuickSort_ReverseSortedArray_ExpectSortedInDirectOrderArray(int[] arrayToSort)
        {
            QuickSort(arrayToSort);

            Assert.True(IsArraySorted(arrayToSort));
        }

        [TestCase(1000000)]
        [TestCase(10000000)]
        public void QuickSort_LargeRandomNumberArray_ExpectSortedArray(int size)
        {
            int[] arrayToSort = GenerateRandomNumberArray(size);

            QuickSort(arrayToSort);

            Assert.True(IsArraySorted(arrayToSort));
        }

        [TestCase(1000000)]
        [TestCase(10000000)]
        public void MergeSort_LargeRandomNumberArray_ExpectSortedArray(int size)
        {
            int[] arrayToSort = GenerateRandomNumberArray(size);

            MergeSort(arrayToSort);

            Assert.True(IsArraySorted(arrayToSort));
        }

        private static bool IsArraySorted(int[] array)
        {
            bool isArraySorted = true;
            for (int i = 1; i < array.Length; ++i)
            {
                if (array[i] < array[i - 1])
                {
                    isArraySorted = false;
                    break;
                }
            }

            return isArraySorted;
        }

        private static int[] GenerateRandomNumberArray(int size)
        {
            Random rand = new Random(DateTime.Now.Millisecond);
            int[] arrayToSort = new int[size];
            for (int i = 0; i < size; i++)
            {
                arrayToSort[i] = rand.Next(1000000);
            }

            return arrayToSort;
        }
    }

    public class DataForTests
    {
        public static IEnumerable ReversedSortedArray_SortedInDirectOrderArray
        {
            get
            {
                yield return new TestCaseData(new int[] { 4, 3, 2, 1 });
                yield return new TestCaseData(new int[] { 3, 2, 1 });
                yield return new TestCaseData(new int[] { 2, 1 });
                yield return new TestCaseData(new int[] { 1 });
            }
        }

        public static IEnumerable SortedArray_SortedArray
        {
            get
            {
                yield return new TestCaseData(new int[] { 1, 2, 3, 4 });
                yield return new TestCaseData(new int[] { 1, 2, 3 });
                yield return new TestCaseData(new int[] { 1, 2 });
                yield return new TestCaseData(new int[] { 1 });
            }
        }
    }
}