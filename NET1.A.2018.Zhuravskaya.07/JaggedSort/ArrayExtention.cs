using System;

namespace JaggedSort
{
    /// <summary>
    /// Contains extension methods for arrays.
    /// </summary>
    public static class ArrayExtension
    {
        /// <summary>
        /// The method sorts a two-dimensional array by rows.
        /// </summary>
        /// <param name="array">
        /// Array to sort.
        /// </param>
        /// <param name="rowSortingType">
        /// Sorting type.
        /// </param>
        /// <param name="sortOrder">
        /// Sort order.
        /// </param>
        /// <exception cref="ArgumentException">
        /// Array to sort is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Array to sort length is zero.
        /// </exception>
        public static void SortByRows(this int[][] array, IRowSortingType rowSortingType, bool sortOrder)
        {
            SortByRowsInputValidation(array);
            
            var rowsPriority = new int[array.Length];

            for (int i = 0; i < array.Length; ++i)
            {
                rowsPriority[i] = rowSortingType.RowPriority(array[i]);
            }

            array.SortArrayByPriorityArray(rowsPriority, sortOrder);
        }

        /// <summary>
        /// The method sorts an two-dimensional array by rows by priority array.
        /// </summary>
        /// <param name="arrayToSort">
        /// Array to sort.
        /// </param>
        /// <param name="priorityArray">
        /// Array of row priorities.
        /// </param>
        /// <param name="sortOrder">
        /// true - ascending order, false - descending order.
        /// </param>
        private static void SortArrayByPriorityArray(this int[][] arrayToSort, int[] priorityArray, bool sortOrder = true)
        {
            for (int i = 0; i < priorityArray.Length - 1; ++i)
            {
                for (int j = i + 1; j < priorityArray.Length; ++j)
                {
                    if (priorityArray[i] >= priorityArray[j] == sortOrder)
                    {
                        Swap(ref priorityArray[i], ref priorityArray[j]);
                        Swap(ref arrayToSort[i], ref arrayToSort[j]);
                    }
                }
            }
        }

        private static void Swap(ref int a, ref int b)
        {
            var temp = a;
            a = b;
            b = temp;
        }

        private static void Swap(ref int[] a, ref int[] b)
        {
            var temp = a;
            a = b;
            b = temp;
        }

        private static void SortByRowsInputValidation(int[][] array)
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