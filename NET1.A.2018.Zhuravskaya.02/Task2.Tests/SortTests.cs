using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Task2.Sort;

namespace Task2.Tests
{
    [TestClass]
    public class SortTests
    {
        [TestMethod]
        public void MergeSort_EmptyArray_ExpectEmptyArray()
        {
            int[] arrayToSort = new int[] { };
            int[] expectedArray = new int[] { };

            MergeSort(arrayToSort);

            CollectionAssert.AreEqual(arrayToSort, expectedArray);
        }

        [DataTestMethod]
        [DataRow(new int[] { 4, 3, 2, 1 }, new int[] { 1, 2, 3, 4 })]
        [DataRow(new int[] { 3, 2, 1 }, new int[] { 1, 2, 3 })]
        [DataRow(new int[] { 2, 1 }, new int[] { 1, 2 })]
        [DataRow(new int[] { 1 }, new int[] { 1 })]
        public void MergeSort_ReverseSortedArray_ExpectSortedInDirectOrderArray(int[] arrayToSort, int[] expectedArray)
        {
            MergeSort(arrayToSort);

            CollectionAssert.AreEqual(arrayToSort, expectedArray);
        }

        [DataTestMethod]
        [DataRow(new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3, 4 })]
        [DataRow(new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 })]
        [DataRow(new int[] { 1, 2 }, new int[] { 1, 2 })]
        [DataRow(new int[] { 1 }, new int[] { 1 })]
        public void MergeSort_SortedArray_ExpectNotChangedArray(int[] arrayToSort, int[] expectedArray)
        {
            MergeSort(arrayToSort);

            CollectionAssert.AreEqual(arrayToSort, expectedArray);
        }

        [TestMethod]
        public void QuickSort_EmptyArray_ExpectEmptyArray()
        {
            int[] arrayToSort = new int[] { };
            int[] expectedArray = new int[] { };

            QuickSort(arrayToSort);

            CollectionAssert.AreEqual(arrayToSort, expectedArray);
        }

        [DataTestMethod]
        [DataRow(new int[] { 4, 3, 2, 1 }, new int[] { 1, 2, 3, 4 })]
        [DataRow(new int[] { 3, 2, 1 }, new int[] { 1, 2, 3 })]
        [DataRow(new int[] { 2, 1 }, new int[] { 1, 2 })]
        [DataRow(new int[] { 1 }, new int[] { 1 })]
        public void QuickSort_ReverseSortedArray_ExpectSortedInDirectOrderArray(int[] arrayToSort, int[] expectedArray)
        {
            QuickSort(arrayToSort);

            CollectionAssert.AreEqual(arrayToSort, expectedArray);
        }

        [DataTestMethod]
        [DataRow(new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3, 4 })]
        [DataRow(new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 })]
        [DataRow(new int[] { 1, 2 }, new int[] { 1, 2 })]
        [DataRow(new int[] { 1 }, new int[] { 1 })]
        public void QuickSort_SortedArray_ExpectNotChangedArray(int[] arrayToSort, int[] expectedArray)
        {
            QuickSort(arrayToSort);

            CollectionAssert.AreEqual(arrayToSort, expectedArray);
        }

        [TestMethod]
        public void QuickSort_LargeRandomNumberArray_ExpectSortedArray()
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

            QuickSort(arrayToSort);

            CollectionAssert.AreEqual(arrayToSort, expectedArray);
        }

        [TestMethod]
        public void MergeSort_LargeRandomNumberArray_ExpectSortedArray()
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

            MergeSort(arrayToSort);

            CollectionAssert.AreEqual(arrayToSort, expectedArray);
        }
    }
}