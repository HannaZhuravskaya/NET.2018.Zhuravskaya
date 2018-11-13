using System;
using System.Collections.Generic;
using System.Numerics;
using Task1and2.Interfaces;

namespace Task1and2
{
    /// <summary>
    /// Class contains extensions method for array.
    /// </summary>
    public static class CollectionsExtensions
    {
        /// <summary>
        /// Method transforms TSource type collection to TResult type collection.
        /// </summary>
        /// <typeparam name="TSource">
        /// Type of collection.
        /// </typeparam>
        /// <typeparam name="TResult">
        /// Type of transformed collection.
        /// </typeparam>
        /// <param name="collection">
        /// Collection to transform.
        /// </param>
        /// <param name="transformer">
        /// Format to transform.
        /// </param>
        /// <returns>
        /// Returns an IEnumerator for the transformed collection.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Collection must not be null. Collection elements must not be null.
        /// </exception>
        public static IEnumerable<TResult> Transform<TSource, TResult>(this IEnumerable<TSource> collection, ITransformer<TSource, TResult> transformer)
        {
            return collection.Transform(transformer.Transform);
        }

        /// <summary>
        /// Method transforms TSource type collection to TResult type collection.
        /// </summary>
        /// <typeparam name="TSource">
        /// Type of collection.
        /// </typeparam>
        /// <typeparam name="TResult">
        /// Type of transformed collection.
        /// </typeparam>
        /// <param name="collection">
        /// Collection to transform.
        /// </param>
        /// <param name="transformer">
        /// Format to transform.
        /// </param>
        /// <returns>
        /// Returns an IEnumerator for the transformed collection.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Collection must not be null. Collection elements must not be null.
        /// </exception>
        public static IEnumerable<TResult> Transform<TSource, TResult>(this IEnumerable<TSource> collection, Func<TSource, TResult> transformer)
        {
            InputValidation(collection);

            return HiddenTransformTo();

            IEnumerable<TResult> HiddenTransformTo()
            {
                foreach (var element in collection)
                {
                    yield return transformer.Invoke(element);
                }
            }
        }

        /// <summary>
        /// The method returns an IEnumerable for the filtered collection.
        /// </summary>
        /// <typeparam name="TSource">
        /// Type of collection.
        /// </typeparam>
        /// <param name="collection">
        /// Collection to transform.
        /// </param>
        /// <param name="filter">
        /// Filtering rule.
        /// </param>
        /// <returns>
        /// Returns an IEnumerator for the filtered collection.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Collection must not be null. Collection elements must not be null.
        /// </exception>
        public static IEnumerable<TSource> Filter<TSource>(this IEnumerable<TSource> collection, IFilter<TSource> filter)
        {
            return collection.Filter(filter.Filter);
        }

        /// <summary>
        /// The method returns an IEnumerable for the filtered collection.
        /// </summary>
        /// <typeparam name="TSource">
        /// Type of collection.
        /// </typeparam>
        /// <param name="collection">
        /// Collection to transform.
        /// </param>
        /// <param name="filter">
        /// Filtering rule.
        /// </param>
        /// <returns>
        /// Returns an IEnumerator for the filtered collection.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Collection must not be null. Collection elements must not be null.
        /// </exception>
        public static IEnumerable<TSource> Filter<TSource>(this IEnumerable<TSource> collection, Func<TSource, bool> filter)
        {
            InputValidation(collection);

            return HiddenFilter();

            IEnumerable<TSource> HiddenFilter()
            {
                foreach (var element in collection)
                {
                    if (filter.Invoke(element))
                    {
                        yield return element;
                    }
                }
            }
        }

        /// <summary>
        /// The method generates the Fibonacci sequence.
        /// </summary>
        /// <param name="count">
        /// Number of elements in the Fibonacci sequence.
        /// </param>
        /// <returns>
        /// Returns an IEnumerator for the Fibonacci numbers.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="count"/> must be greater than zero.
        /// </exception>
        public static IEnumerable<BigInteger> Fibonacci(int count)
        {
            if (count < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            return FibonacciCore();

            IEnumerable<BigInteger> FibonacciCore()
            {
                BigInteger current = 0;
                BigInteger next = 1;

                for (int i = 0; i < count; ++i)
                {
                    yield return current;
                    Swap(ref current, ref next);
                    next += current;
                }
            }
        }

        private static void InputValidation<TSource>(IEnumerable<TSource> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException();
            }
            
            foreach (var element in collection)
            {
                if (Equals(element, null))
                {
                    throw new ArgumentNullException();
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