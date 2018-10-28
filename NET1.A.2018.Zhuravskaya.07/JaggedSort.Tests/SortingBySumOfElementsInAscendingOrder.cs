namespace JaggedSort.Tests
{
    /// <summary>
    /// The class implements the IRowSortingType interface and sets the priority of rows in ascending order of element sums.
    /// </summary>
    public class SortingBySumOfElementsInAscendingOrder : IRowSortingType
    {
        /// <summary>
        /// Readonly field storing sorting order.
        /// </summary>
        public static readonly bool SortOrder = true;

        /// <summary>
        /// The method calculates row element sums.
        /// </summary>
        /// <param name="row">
        /// Source row.
        /// </param>
        /// <returns>
        /// Source row element sums.
        /// </returns>
        public int RowPriority(int[] row)
        {
            if (row == null || row.Length == 0)
            {
                return int.MinValue;
            }

            int sumOfRow = 0;
            for (int i = 0; i < row.Length; ++i)
            {
                sumOfRow += row[i];
            }

            return sumOfRow;
        }
    }
}