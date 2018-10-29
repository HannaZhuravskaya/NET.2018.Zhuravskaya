namespace Task1and2
{
    /// <summary>
    /// Provides an interface for setting the format.
    /// </summary>
    public interface ITransformer
    {
        /// <summary>
        /// The method transforms a real number into a string format.
        /// </summary>
        /// <param name="number">
        /// Real number.
        /// </param>
        /// <returns>
        /// Real number in string format.
        /// </returns>
        string Transform(double number);
    }
}