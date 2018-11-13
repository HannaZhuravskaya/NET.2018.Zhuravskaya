using System;
using System.Collections.Generic;

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
        /// <typeparam name="T">
        /// Type of array.
        /// </typeparam>
        /// <param name="comparer">
        /// IComparer implementations.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if array is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown if array has no elements.
        /// </exception>
        public static void MergeSort<T>(this T[] array, IComparer<T> comparer)
        {
            MergeSort(array, comparer.Compare);
        }

        /// <summary>
        /// Method of merge sort.
        /// </summary>
        /// <param name="array">
        /// Array to sort.
        /// </param>
        /// <typeparam name="T">
        /// Type of array.
        /// </typeparam>
        /// <param name="comparer">
        /// delegate Comparison.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if array is null.
        /// Comparer must not be null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown if array has no elements.
        /// </exception>
        public static void MergeSort<T>(this T[] array, Comparison<T> comparer)
        {
            CheckSortingConditions(array);
            CompareValidation(comparer);

            var sortedInput = MergeSortRecursive(array, comparer);

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
        /// <typeparam name="T">
        /// Type of array.
        /// </typeparam>
        /// <param name="comparer">
        /// IComparer implementations.
        /// </param>
        /// /// <exception cref="ArgumentNullException">
        /// Thrown if array is null.
        /// Comparer must not be null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown if array has no elements.
        /// </exception>
        public static void QuickSort<T>(this T[] array, IComparer<T> comparer)
        {
            QuickSort(array, comparer.Compare);
        }

        /// <summary>
        /// Method of quick sort.
        /// </summary>
        /// <param name="array">
        /// Array to sort.
        /// </param>
        /// <typeparam name="T">
        /// Type of array.
        /// </typeparam>
        /// <param name="comparer">
        /// delegate Comparison.
        /// </param>
        /// /// <exception cref="ArgumentNullException">
        /// Thrown if array is null.
        /// Comparer must not be null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown if array has no elements.
        /// </exception>
        public static void QuickSort<T>(this T[] array, Comparison<T> comparer)
        {
            CheckSortingConditions(array);
            CompareValidation(comparer);

            QuickSortRecursive(array, 0, array.Length - 1, comparer);
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
        /// <param name="comparer">
        /// IComparer implementations.
        /// </param>
        /// <returns>
        /// The index of searched element or null if it is not in the array.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Array, array elements and element to find should not be null.
        /// Comparer must not be null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Array length should not be zero.
        /// </exception>
        public static int? BinarySearch<T>(this T[] array, T elementToFind, IComparer<T> comparer)
        {
            return BinarySearch(array, elementToFind, comparer.Compare);
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
        /// <param name="comparer">
        /// delegate Comparison.
        /// </param>
        /// <returns>
        /// The index of searched element or null if it is not in the array.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Array, array elements and element to find should not be null.
        /// Comparer must not be null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Array length should not be zero.
        /// </exception>
        public static int? BinarySearch<T>(this T[] array, T elementToFind, Comparison<T> comparer)
        {
            BinarySearchInputValidation(array, elementToFind);
            return BinarySearch(array, elementToFind, comparer, 0, array.Length);
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
        /// <param name="comparer">
        /// IComparer implementation.
        /// </param>
        /// <param name="start">
        /// First index to search.
        /// </param>
        /// <param name="end">
        /// Last index to search.
        /// </param>
        /// <returns>
        /// The index of searched element or null if it is not in the array.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Array, array elements and element to find should not be null.
        /// Comparer must not be null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Array length should not be zero.
        /// </exception>
        public static int? BinarySearch<T>(this T[] array, T elementToFind, IComparer<T> comparer, int start, int end)
        {
            return BinarySearch(array, elementToFind, comparer.Compare, start, end);
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
        /// <param name="comparer">
        /// delegate Comparison.
        /// </param>
        /// <param name="start">
        /// First index to search.
        /// </param>
        /// <param name="end">
        /// Last index to search.
        /// </param>
        /// <returns>
        /// The index of searched element or null if it is not in the array.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Array, array elements and element to find should not be null.
        /// Comparer must not be null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Array length should not be zero.
        /// </exception>
        public static int? BinarySearch<T>(this T[] array, T elementToFind, Comparison<T> comparer, int start, int end)
        {
            BinarySearchInputValidation(array, elementToFind);
            CompareValidation(comparer);

            if (comparer.Invoke(elementToFind, array[start]) < 0 || comparer.Invoke(elementToFind, array[end - 1]) > 0)
            {
                return null;
            }

            int first = start;
            int last = end;

            while (first < last)
            {
                int middle = first + (last - first) / 2;

                if (Equals(array[middle], null))
                {
                    throw new ArgumentNullException();
                }

                if (comparer.Invoke(elementToFind, array[middle]) <= 0)
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

            return null;
        }

        private static T[] MergeSortRecursive<T>(T[] input, Comparison<T> comparer)
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

            left = MergeSortRecursive(left, comparer);
            right = MergeSortRecursive(right, comparer);
            result = Merge(left, right, comparer);

            return result;
        }

        private static T[] Merge<T>(T[] left, T[] right, Comparison<T> comparer) 
        {
            var result = new T[left.Length + right.Length];

            int leftIndex = 0, rightIndex = 0, resultIndex = 0;
            while (leftIndex < left.Length && rightIndex < right.Length)
            {
                if (comparer.Invoke(left[leftIndex], right[rightIndex]) < 0)
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

        private static int QuickSortPartition<T>(T[] array, int start, int end, Comparison<T> comparer)
        {
            int marker = start;
            for (int i = start; i <= end; i++)
            {
                if (comparer.Invoke(array[i], array[end]) <= 0)
                {
                    Swap(ref array[marker], ref array[i]);
                    marker += 1;
                }
            }

            return marker - 1;
        }

        private static void QuickSortRecursive<T>(T[] array, int start, int end, Comparison<T> comparer) 
        {
            if (start >= end)
            {
                return;
            }

            int pivot = QuickSortPartition(array, start, end, comparer);
            QuickSortRecursive(array, start, pivot - 1, comparer);
            QuickSortRecursive(array, pivot + 1, end, comparer);
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

        private static void CompareValidation<T>(Comparison<T> comparer)
        {
            if (comparer is null)
            {
                throw new ArgumentNullException();
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