using Task1and2.Interfaces;

namespace Task1and2.IFilterImplementations
{
    /// <summary>
    /// The implementation of IFilter interface. Determines whether a resource integer matches a pattern.
    /// </summary>
    public class EvenNumberPattern : IFilter<int>
    {
        /// <summary>
        /// The method determines whether a resource integer matches a pattern.
        /// </summary>
        /// <param name="source">
        /// Source to filtering.
        /// </param>
        /// <returns>
        /// Is source fit the pattern.
        /// </returns>
        public bool Filter(int source)
        {
            return source % 2 == 0;
        }
    }
}
