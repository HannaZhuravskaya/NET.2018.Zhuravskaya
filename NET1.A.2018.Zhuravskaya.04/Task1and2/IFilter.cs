namespace Task1and2
{
    /// <summary>
    /// Provides an interface to filter by pattern. 
    /// </summary>
    /// <typeparam name="TSource">
    /// Type of filtering.
    /// </typeparam>
    public interface IFilter<in TSource>
    {
        /// <summary>
        /// The method checks if the resource is suitable for the pattern.
        /// </summary>
        /// <param name="source">
        /// Source to filtering.
        /// </param>
        /// <returns>
        /// Is source fit the pattern.
        /// </returns>
        bool IsFitThePattern(TSource source);
    }
}
