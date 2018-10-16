using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Task2.Sort;

namespace Task2.Tests
{
    [TestClass]
    public class SortTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MergeSort_EmptyArray_ArgumentException()
            => MergeSort(new int[] { });

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MergeSort_ArrayIsNull_ArgumentNullException()
           => MergeSort(null);

        [DataTestMethod]
        [DataRow(new int[] { 4, 3, 2, 1 })]
        [DataRow(new int[] { 3, 2, 1 })]
        [DataRow(new int[] { 2, 1 })]
        [DataRow(new int[] { 1 })]
        public void MergeSort_ReverseSortedArray_ExpectSortedInDirectOrderArray(int[] arrayToSort)
        {
            MergeSort(arrayToSort);

            Assert.IsTrue(IsArraySorted(arrayToSort));
        }

        [DataTestMethod]
        [DataRow(new int[] { 1, 2, 3, 4 })]
        [DataRow(new int[] { 1, 2, 3 })]
        [DataRow(new int[] { 1, 2 })]
        [DataRow(new int[] { 1 })]
        public void MergeSort_SortedArray_ExpectNotChangedArray(int[] arrayToSort)
        {
            MergeSort(arrayToSort);

            Assert.IsTrue(IsArraySorted(arrayToSort));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void QuickSort_EmptyArray_ArgumentException()
            => QuickSort(new int[] { });

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void QuickSort_ArrayIsNull_ArgumentNullException()
           => QuickSort(null);

        [DataTestMethod]
        [DataRow(new int[] { 4, 3, 2, 1 })]
        [DataRow(new int[] { 3, 2, 1 })]
        [DataRow(new int[] { 2, 1 })]
        [DataRow(new int[] { 1 })]
        public void QuickSort_ReverseSortedArray_ExpectSortedInDirectOrderArray(int[] arrayToSort)
        {
            QuickSort(arrayToSort);

            Assert.IsTrue(IsArraySorted(arrayToSort));
        }

        [DataTestMethod]
        [DataRow(new int[] { 1, 2, 3, 4 })]
        [DataRow(new int[] { 1, 2, 3 })]
        [DataRow(new int[] { 1, 2 })]
        [DataRow(new int[] { 1 })]
        public void QuickSort_SortedArray_ExpectNotChangedArray(int[] arrayToSort)
        {
            QuickSort(arrayToSort);

            Assert.IsTrue(IsArraySorted(arrayToSort));
        }

        [DataTestMethod]
        [DataRow(1000000)]
        [DataRow(10000000)]
        public void QuickSort_LargeRandomNumberArray_ExpectSortedArray(int size)
        {
            int[] arrayToSort = GenerateRandomNumberArray(size);

            QuickSort(arrayToSort);

            Assert.IsTrue(IsArraySorted(arrayToSort));
        }

        [DataTestMethod]
        [DataRow(1000000)]
        [DataRow(10000000)]
        public void MergeSort_LargeRandomNumberArray_ExpectSortedArray(int size)
        {
            int[] arrayToSort = GenerateRandomNumberArray(size);

            MergeSort(arrayToSort);

            Assert.IsTrue(IsArraySorted(arrayToSort));
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
}