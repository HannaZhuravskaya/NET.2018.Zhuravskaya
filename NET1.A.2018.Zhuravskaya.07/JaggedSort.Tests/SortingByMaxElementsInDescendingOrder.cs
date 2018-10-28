namespace JaggedSort.Tests
{
    /// <summary>
    ///  The class implements the IRowSortingType interface and sets the priority of rows in descending order of max elements.
    /// </summary>
    public class SortingByMaxElementsInDescendingOrder : IRowSortingType
    {
        /// <summary>
        /// Readonly field storing sorting order.
        /// </summary>
        public static readonly bool SortOrder = false;

        /// <summary>
        /// The method finds the max element of the row.
        /// </summary>
        /// <param name="row">
        /// Source row.
        /// </param>
        /// <returns>
        /// Source row max element.
        /// </returns>
        public int RowPriority(int[] row)
        {
            if (row == null || row.Length == 0)
            {
                return int.MinValue;
            }

            int maxElement = row[0];
            for (int i = 1; i < row.Length; ++i)
            {
                if (row[i] > maxElement)
                {
                    maxElement = row[i];
                }
            }

            return maxElement;
        }
    }
}