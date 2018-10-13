using System.Collections.Generic;

namespace Task2
{
    /// <summary>
    /// This is Sort class.
    /// </summary>
    public class Sort
    {
        /// <summary>
        /// Method of merge sort.
        /// </summary>
        /// <param name="array">
        /// Array to sort.
        /// </param>
        public static void mergeSort(int[] array)
        {
            var list = new List<int>();
            for (int i = 0; i < array.Length; ++i)
            {
                list.Add(array[i]);
            }

            var sortedInput = MergeSortRecursive(list);

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
        public static void QuickSort(int[] array)
        {
            QuickSortRecursive(array, 0, array.Length - 1);
        }

        private static List<int> MergeSortRecursive(List<int> input)
        {
            if (input.Count <= 1)
            {
                return input;
            }

            List<int> left = new List<int>();
            List<int> right = new List<int>();
            List<int> result = new List<int>();

            int middle = input.Count / 2;

            for (int i = 0; i < input.Count; ++i)
            {
                if (i < middle)
                {
                    left.Add(input[i]);
                }
                else
                {
                    right.Add(input[i]);
                }
            }

            left = MergeSortRecursive(left);
            right = MergeSortRecursive(right);
            result = Merge(left, right);

            return result;
        }

        private static List<int> Merge(List<int> left, List<int> right)
        {
            var result = new List<int>();
            int leftIndex = 0, rightIndex = 0;
            while (leftIndex < left.Count && rightIndex < right.Count)
            {
                if (left[leftIndex].CompareTo(right[rightIndex]) < 0)
                {
                    result.Add(left[leftIndex]);
                    leftIndex++;
                }
                else
                {
                    result.Add(right[rightIndex]);
                    rightIndex++;
                }
            }

            while (leftIndex < left.Count)
            {
                result.Add(left[leftIndex]);
                leftIndex++;
            }

            while (rightIndex < right.Count)
            {
                result.Add(right[rightIndex]);
                rightIndex++;
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
                    int temp = array[marker];
                    array[marker] = array[i];
                    array[i] = temp;
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
    }
}