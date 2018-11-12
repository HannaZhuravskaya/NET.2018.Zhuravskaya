namespace Task1and2.Interfaces
{
    /// <summary>
    /// Provides an interface for setting the format.
    /// </summary>
    /// <typeparam name="TSource">
    /// The type from which the transformation occurs.
    /// </typeparam>
    /// <typeparam name="TResult">
    /// The type in which the transformation occurs.
    /// </typeparam>
    public interface ITransformer<in TSource, out TResult>
    {
        /// <summary>
        /// The method transforms a variable of type TSource to type TResult.
        /// </summary>
        /// <param name="source">
        /// Variable of TSource type.
        /// </param>
        /// <returns>
        /// The result of transforming a variable of type TSource to type TResult.
        /// </returns>
        TResult Transform(TSource source);
    }
}