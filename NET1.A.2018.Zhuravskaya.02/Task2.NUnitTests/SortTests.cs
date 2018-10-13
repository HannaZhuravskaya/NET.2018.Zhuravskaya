using System;
using System.Collections;
using NUnit.Framework;
using static Task2.Sort;

namespace Task2.NUnitTests
{
    [TestFixture]
    public class SortTests
    {
        [TestCase(new int[] { }, new int[] { })]
        public void MergeSort_EmptyArray_ExpectEmptyArray(int[] arrayToSort, int[] expectedArray)
        {
            MergeSort(arrayToSort);

            CollectionAssert.AreEqual(arrayToSort, expectedArray);
        }

        [TestCaseSource(typeof(DataForTests), nameof(DataForTests.SortedArray_SortedArray))]
        public void MergeSort_SortedArray_ExpectNotChangedArray(int[] arrayToSort, int[] expectedArray)
        {
            MergeSort(arrayToSort);

            CollectionAssert.AreEqual(arrayToSort, expectedArray);
        }

        [TestCaseSource(typeof(DataForTests), nameof(DataForTests.ReversedSortedArray_SortedInDirectOrderArray))]
        public void MergeSort_ReverseSortedArray_ExpectSortedInDirectOrderArray(int[] arrayToSort, int[] expectedArray)
        {
            MergeSort(arrayToSort);

            CollectionAssert.AreEqual(arrayToSort, expectedArray);
        }

        [TestCase(new int[] { }, new int[] { })]
        public void QuickSort_EmptyArray_ExpectEmptyArray(int[] arrayToSort, int[] expectedArray)
        {
            QuickSort(arrayToSort);

            CollectionAssert.AreEqual(arrayToSort, expectedArray);
        }

        [TestCaseSource(typeof(DataForTests), nameof(DataForTests.SortedArray_SortedArray))]
        public void QuickSort_SortedArray_ExpectNotChangedArray(int[] arrayToSort, int[] expectedArray)
        {
            QuickSort(arrayToSort);

            CollectionAssert.AreEqual(arrayToSort, expectedArray);
        }

        [TestCaseSource(typeof(DataForTests), nameof(DataForTests.ReversedSortedArray_SortedInDirectOrderArray))]
        public void QuickSort_ReverseSortedArray_ExpectSortedInDirectOrderArray(int[] arrayToSort, int[] expectedArray)
        {
            QuickSort(arrayToSort);

            CollectionAssert.AreEqual(arrayToSort, expectedArray);
        }

        [Test, TestCaseSource(typeof(DataForTests), nameof(DataForTests.LargeRandomNumberArray_SortedArray))]
        public void QuickSort_LargeRandomNumberArray_ExpectSortedArray(int[] arrayToSort, int[] expectedArray)
        {
            QuickSort(arrayToSort);

            CollectionAssert.AreEqual(arrayToSort, expectedArray);
        }

        [Test, TestCaseSource(typeof(DataForTests), nameof(DataForTests.LargeRandomNumberArray_SortedArray))]
        public void MergeSort_LargeRandomNumberArray_ExpectSortedArray(int[] arrayToSort, int[] expectedArray)
        {
            MergeSort(arrayToSort);

            CollectionAssert.AreEqual(arrayToSort, expectedArray);
        }
    }

    public class DataForTests
    {
        public static IEnumerable ReversedSortedArray_SortedInDirectOrderArray
        {
            get
            {
                yield return new TestCaseData(new int[] { 4, 3, 2, 1 }, new int[] { 1, 2, 3, 4 });
                yield return new TestCaseData(new int[] { 3, 2, 1 }, new int[] { 1, 2, 3 });
                yield return new TestCaseData(new int[] { 2, 1 }, new int[] { 1, 2 });
                yield return new TestCaseData(new int[] { 1 }, new int[] { 1 });
            }
        }

        public static IEnumerable SortedArray_SortedArray
        {
            get
            {
                yield return new TestCaseData(new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3, 4 });
                yield return new TestCaseData(new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 });
                yield return new TestCaseData(new int[] { 1, 2 }, new int[] { 1, 2 });
                yield return new TestCaseData(new int[] { 1 }, new int[] { 1 });
            }
        }

        public static IEnumerable LargeRandomNumberArray_SortedArray
        {
            get
            {
                Random rand = new Random(DateTime.Now.Millisecond);
                int size = 1000000;
                int[] arrayToSort = new int[size];
                int[] expectedArray = new int[size];
                for (int i = 0; i < size; i++)
                {
                    arrayToSort[i] = rand.Next(1000000);
                    expectedArray[i] = arrayToSort[i];
                }

                Array.Sort(expectedArray);

                yield return new TestCaseData(arrayToSort, expectedArray);
            }
        }
    }
}