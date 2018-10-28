namespace JaggedSort
{
    /// <summary>
    /// Provides an interface to set type of array sorting by rows.
    /// </summary>
    public interface IRowSortingType
    {
        /// <summary>
        /// The method calculates the priority of the source row.
        /// </summary>
        /// <param name="row">
        /// Source row.
        /// </param>
        /// <returns>
        /// The priority of the source row.
        /// </returns>
        int RowPriority(int[] row);
    }
}