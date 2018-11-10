using System;

namespace Task2
{
    /// <summary>
    /// This class contains array extensions.
    /// </summary>
    public static class ArrayExtensions
    {
        /// <summary>
        /// Method of merge sort.
        /// </summary>
        /// <param name="array">
        /// Array to sort.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if array is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown if array has no elements.
        /// </exception>
        public static void MergeSort<T>(this T[] array) where T : IComparable<T> 
        {
            CheckSortingConditions(array);

            var sortedInput = MergeSortRecursive(array);

            for (int i = 0; i < array.Length; ++i)
            {
                array[i] = sortedInput[i];
            }
        }

        /// <summary>
        /// Method of quick sort.
        /// </summary>
        /// <param name="array">
        /// Array to sort.
        /// </param>
        /// /// <exception cref="ArgumentNullException">
        /// Thrown if array is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown if array has no elements.
        /// </exception>
        public static void QuickSort<T>(this T[] array) where T : IComparable<T> 
        {
            CheckSortingConditions(array);

            QuickSortRecursive(array, 0, array.Length - 1);
        }

        /// <summary>
        /// Searches for an element in an array.
        /// </summary>
        /// <typeparam name="T">
        /// Type of array elements.
        /// </typeparam>
        /// <param name="array">
        /// Sorted array in which to search.
        /// </param>
        /// <param name="elementToFind">
        /// Element to find.
        /// </param>
        /// <returns>
        /// The index of searched element or -1 if it is not in the array.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Array, array elements and element to find should not be null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Array length should not be zero.
        /// </exception>
        public static int BinarySearch<T>(this T[] array, T elementToFind) where T : IComparable<T>
        {
            BinarySearchInputValidation(array, elementToFind);

            if (elementToFind.CompareTo(array[0]) < 0 || elementToFind.CompareTo(array[array.Length - 1]) > 0)
            {
                return -1;
            }

            int first = 0;
            int last = array.Length;

            while (first < last)
            {
                int middle = first + (last - first) / 2;

                if (Equals(array[middle], null))
                {
                    throw new ArgumentNullException();
                }

                if (elementToFind.CompareTo(array[middle]) <= 0)
                {
                    last = middle;
                }
                else
                {
                    first = middle + 1;
                }
            }

            if (Equals(elementToFind, array[last]))
            {
                return last;
            }

            return -1;
        }

        private static T[] MergeSortRecursive<T>(T[] input) where T : IComparable<T> 
        {
            if (input.Length == 1)
            {
                return input;
            }

            int middle = input.Length / 2;

            var left = new T[middle];
            var right = new T[input.Length - middle];
            var result = new T[input.Length];

            Array.Copy(input, 0, left, 0, middle);
            Array.Copy(input, middle, right, 0, input.Length - middle);

            left = MergeSortRecursive(left);
            right = MergeSortRecursive(right);
            result = Merge(left, right);

            return result;
        }

        private static T[] Merge<T>(T[] left, T[] right) where T : IComparable<T> 
        {
            var result = new T[left.Length + right.Length];

            int leftIndex = 0, rightIndex = 0, resultIndex = 0;
            while (leftIndex < left.Length && rightIndex < right.Length)
            {
                if (left[leftIndex].CompareTo(right[rightIndex]) < 0)
                {
                    result[resultIndex] = left[leftIndex];
                    leftIndex++;
                }
                else
                {
                    result[resultIndex] = right[rightIndex];
                    rightIndex++;
                }

                resultIndex++;
            }

            while (leftIndex < left.Length)
            {
                result[resultIndex] = left[leftIndex];
                leftIndex++;
                resultIndex++;
            }

            while (rightIndex < right.Length)
            {
                result[resultIndex] = right[rightIndex];
                rightIndex++;
                resultIndex++;
            }

            return result;
        }

        private static int QuickSortPartition<T>(T[] array, int start, int end) where T : IComparable<T> 
        {
            int marker = start;
            for (int i = start; i <= end; i++)
            {
                if (array[i].CompareTo(array[end]) <= 0)
                {
                    Swap(ref array[marker], ref array[i]);
                    marker += 1;
                }
            }

            return marker - 1;
        }

        private static void QuickSortRecursive<T>(T[] array, int start, int end) where T : IComparable<T> 
        {
            if (start >= end)
            {
                return;
            }

            int pivot = QuickSortPartition(array, start, end);
            QuickSortRecursive(array, start, pivot - 1);
            QuickSortRecursive(array, pivot + 1, end);
        }

        private static void Swap<T>(ref T a, ref T b)
        {
            var temp = a;
            a = b;
            b = temp;
        }

        private static void CheckSortingConditions<T>(T[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException();
            }

            if (array.Length == 0)
            {
                throw new ArgumentException();
            }

            foreach (var element in array)
            {
                if (Equals(element, null))
                {
                    throw new ArgumentNullException();
                }
            }
        }

        private static void BinarySearchInputValidation<T>(T[] array, T elementToFind)
        {
            if (array is null || Equals(elementToFind, null))
            {
                throw new ArgumentNullException();
            }

            if (array.Length == 0)
            {
                throw new ArgumentException();
            }
        }
    }
}