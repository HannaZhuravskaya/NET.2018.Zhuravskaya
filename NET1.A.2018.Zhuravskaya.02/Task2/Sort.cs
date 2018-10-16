using System;

namespace Task2
{
    /// <summary>
    /// This is Sort class.
    /// </summary>
    public static class Sort
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
        public static void MergeSort(int[] array)
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
        public static void QuickSort(int[] array)
        {
            CheckSortingConditions(array);

            QuickSortRecursive(array, 0, array.Length - 1);
        }

        private static int[] MergeSortRecursive(int[] input)
        {
            if (input.Length == 1)
            {
                return input;
            }

            int middle = input.Length / 2;

            var left = new int[middle];
            var right = new int[input.Length - middle];
            var result = new int[input.Length];

            Array.Copy(input, 0, left, 0, middle);
            Array.Copy(input, middle, right, 0, input.Length - middle);

            left = MergeSortRecursive(left);
            right = MergeSortRecursive(right);
            result = Merge(left, right);

            return result;
        }

        private static int[] Merge(int[] left, int[] right)
        {
            var result = new int[left.Length + right.Length];

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

        private static int QuickSortPartition(int[] array, int start, int end)
        {
            int marker = start;
            for (int i = start; i <= end; i++)
            {
                if (array[i] <= array[end])
                {
                    Swap(ref array[marker], ref array[i]);
                    marker += 1;
                }
            }

            return marker - 1;
        }

        private static void QuickSortRecursive(int[] array, int start, int end)
        {
            if (start >= end)
            {
                return;
            }

            int pivot = QuickSortPartition(array, start, end);
            QuickSortRecursive(array, start, pivot - 1);
            QuickSortRecursive(array, pivot + 1, end);
        }

        private static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        private static void CheckSortingConditions(int[] array)
        {
            if (array == null)
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