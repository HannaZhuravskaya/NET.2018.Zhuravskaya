using System;
using System.Collections.Generic;

namespace No6
{
    /// <summary>
    /// Sequence generator.
    /// </summary>
    public static class SequenceGenerator
    {
        /// <summary>
        /// Generate the sequence.
        /// </summary>
        /// <typeparam name="T">
        /// Sequence element type.
        /// </typeparam>
        /// <param name="count">
        /// Number of elements in the sequence.
        /// </param>
        /// <param name="firstElement">
        /// first element of the sequence.
        /// </param>
        /// <param name="secondElement">
        /// second element of the sequence.
        /// </param>
        /// <param name="nextElement">
        /// formula for calculating the next element of the sequence.
        /// </param>
        /// <returns>
        /// IEnumerable'1 T type sequence.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// count must not be less than 0.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// nextElement must not be null.
        /// </exception>
        public static IEnumerable<T> Generate<T>(int count, T firstElement, T secondElement, Func<T, T, T> nextElement)
        {
            if (count < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            if (nextElement == null)
            {
                throw new ArgumentNullException(nameof(nextElement));
            }

            return GenerateCore();

            IEnumerable<T> GenerateCore()
            {
                T current = firstElement;
                T next = secondElement;

                for (int i = 0; i < count; ++i)
                {
                    yield return current;
                    Swap(ref current, ref next);
                    next = nextElement.Invoke(next, current);
                }
            }
        }

        private static void Swap<T>(ref T x, ref T y)
        {
            var temp = x;
            x = y;
            y = temp;
        }
    }
}