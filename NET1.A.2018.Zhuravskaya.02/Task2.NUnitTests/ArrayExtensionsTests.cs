using System;
using System.Collections;
using NUnit.Framework;
using Task2;

namespace Task2.NUnitTests
{
    [TestFixture]
    public class ArrayExtensionsTests
    {
        [Test]
        public void MergeSort_EmptyArray_ArgumentException()
            => Assert.Throws<ArgumentException>(() => new int[] { }.MergeSort());

        [Test]
        public void MergeSort_ArrayIsNull_ArgumentNullException()
            => Assert.Throws<ArgumentNullException>(code: () => ArrayExtensions.MergeSort<int>(null));

        [TestCaseSource(typeof(DataForTests), nameof(DataForTests.SortedArray_SortedArray))]
        public void MergeSort_SortedArray_ExpectNotChangedArray(int[] arrayToSort)
        {
            arrayToSort.MergeSort();

            Assert.True(IsArraySorted(arrayToSort));
        }

        [TestCaseSource(typeof(DataForTests), nameof(DataForTests.ReversedSortedArray_SortedInDirectOrderArray))]
        public void MergeSort_ReverseSortedArray_ExpectSortedInDirectOrderArray(int[] arrayToSort)
        {
            arrayToSort.MergeSort();

            Assert.True(IsArraySorted(arrayToSort));
        }

        [Test]
        public void QuickSort_EmptyArray_ArgumentException()
            => Assert.Throws<ArgumentException>(() => new int[] { }.QuickSort());

        [Test]
        public void QuickSort_ArrayIsNull_ArgumentNullException()
            => Assert.Throws<ArgumentNullException>(() => ArrayExtensions.QuickSort<int>(null));

        [TestCaseSource(typeof(DataForTests), nameof(DataForTests.SortedArray_SortedArray))]
        public void QuickSort_SortedArray_ExpectNotChangedArray(int[] arrayToSort)
        {
            arrayToSort.QuickSort();

            Assert.True(IsArraySorted(arrayToSort));
        }

        [TestCaseSource(typeof(DataForTests), nameof(DataForTests.ReversedSortedArray_SortedInDirectOrderArray))]
        public void QuickSort_ReverseSortedArray_ExpectSortedInDirectOrderArray(int[] arrayToSort)
        {
            arrayToSort.QuickSort();

            Assert.True(IsArraySorted(arrayToSort));
        }

        [TestCase(1000000)]
        [TestCase(10000000)]
        public void QuickSort_LargeRandomNumberArray_ExpectSortedArray(int size)
        {
            int[] arrayToSort = GenerateRandomNumberArray(size);

            arrayToSort.QuickSort();

            Assert.True(IsArraySorted(arrayToSort));
        }

        [TestCase(1000000)]
        [TestCase(10000000)]
        public void MergeSort_LargeRandomNumberArray_ExpectSortedArray(int size)
        {
            int[] arrayToSort = GenerateRandomNumberArray(size);

            arrayToSort.MergeSort();

            Assert.True(IsArraySorted(arrayToSort));
        }

        [Test]
        public void BinarySearch_EmptyArray_ArgumentException()
            => Assert.Throws<ArgumentException>(() => new int[] { }.BinarySearch(0));

        [Test]
        public void BinarySearch_ArrayIsNull_ArgumentNullException()
            => Assert.Throws<ArgumentNullException>(() => ArrayExtensions.BinarySearch(null, 0));

        [TestCase(new[] {1, 2, 3, 4, 5, 6, 7, 8}, 3, ExpectedResult = 2)]
        [TestCase(new[] {1, 2, 3, 4, 5, 6, 7, 8}, 1, ExpectedResult = 0)]
        public int BinarySearch_ElementToFindThatInTheArray_PositionOfElementInTheArray(int[] array, int elementToFind)
        {
            return array.BinarySearch(elementToFind);
        }


        [TestCase(new[] {1, 2, 3, 4, 5, 6, 7, 8}, 9, ExpectedResult = -1)]
        [TestCase(new[] {1, 2, 3, 4, 5, 6, 7, 8}, 0, ExpectedResult = -1)]
        [TestCase(new[] {1, 2, 3, 5, 6, 7, 8}, 4, ExpectedResult = -1)]
        public int BinarySearch_ElementToFindThatNotInTheArray_ExpectedMinusOne(int[] array, int elementToFind)
        {
            return array.BinarySearch(elementToFind);
        }

        [TestCaseSource(typeof(DataForTests), nameof(DataForTests.StringArray))]
        public void MergeSort_StringArray_ExpectedSortedArray(StringArray arrayToSort)
        {
            arrayToSort.Array.MergeSort();

            Assert.True(IsArraySorted(arrayToSort.Array));
        }

        [TestCaseSource(typeof(DataForTests), nameof(DataForTests.StringArray))]
        public void QuickSort_StringArray_ExpectedSortedArray(StringArray arrayToSort)
        {
            arrayToSort.Array.QuickSort();

            Assert.True(IsArraySorted(arrayToSort.Array));
        }


        [TestCaseSource(typeof(DataForTests), nameof(DataForTests.StringArray_ElementToFind_IndexOfElement))]
        public int BinarySearch_ElementToFindInTheStringArray_PositionOfElementInTheArray(StringArray array, string elementToFind)
        {
            return array.Array.BinarySearch(elementToFind);
        }

        private static bool IsArraySorted<T>(T[] array) where T : IComparable<T>
        {
            bool isArraySorted = true;
            for (int i = 1; i < array.Length; ++i)
            {
                if (array[i].CompareTo(array[i - 1]) < 0)
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
                yield return new TestCaseData(new[] {4, 3, 2, 1});
                yield return new TestCaseData(new[] {3, 2, 1});
                yield return new TestCaseData(new[] {2, 1});
                yield return new TestCaseData(new[] {1});
            }
        }

        public static IEnumerable SortedArray_SortedArray
        {
            get
            {
                yield return new TestCaseData(new[] {1, 2, 3, 4});
                yield return new TestCaseData(new[] {1, 2, 3});
                yield return new TestCaseData(new[] {1, 2});
                yield return new TestCaseData(new[] {1});
            }
        }

        public static IEnumerable StringArray
        {
            get
            {
                yield return new TestCaseData(new StringArray("asd", "fdghjs", "asd"));
                yield return new TestCaseData(new StringArray("a", "b", "c", "b"));
                yield return new TestCaseData(new StringArray("fff", "ggg", "aaa", ""));
                yield return new TestCaseData(new StringArray("a", "z", "m"));
            }
        }

        public static IEnumerable StringArray_ElementToFind_IndexOfElement
        {
            get
            {
                yield return new TestCaseData(new StringArray("a", "b", "c"), "b").Returns(1);
                yield return new TestCaseData(new StringArray("a", "b", "c", "d"), "d").Returns(3);
                yield return new TestCaseData(new StringArray("b", "d"), "a").Returns(-1);
                yield return new TestCaseData(new StringArray("b", "d"), "e").Returns(-1);
                yield return new TestCaseData(new StringArray("b", "d"), "c").Returns(-1);
            }
        }
    }

    public class StringArray
    {
        public string[] Array;

        public StringArray(params string[] array)
        {
            Array = array;
        }
    }
}