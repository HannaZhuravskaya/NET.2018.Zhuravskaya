namespace Task1and2.IFilterImplementations
{
    /// <summary>
    /// The implementation of IFilter interface. Determines whether a resource integer matches a pattern.
    /// </summary>
    public class PrimeNumberPattern : IFilter<int>
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
        public bool IsFitThePattern(int source)
        {
            if (source < 2)
            {
                return false;
            }

            for (int i = 2; i <= source / 2; i++)
            {
                if (source % i == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}