using System;

namespace Task1and2
{
    /// <summary>
    /// Class contains extensions method for array.
    /// </summary>
    public static class ArrayExtension
    {
        /// <summary>
        /// Method transforms TSource type array to TResult type array.
        /// </summary>
        /// <param name="array">
        /// Array to transform.
        /// </param>
        /// <param name="transformer">
        /// Format to transform.
        /// </param>
        /// <returns>
        /// TResult type array.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Array must not be null. Array elements must not be null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Array length must not be zero.
        /// </exception>
        public static TResult[] TransformTo<TSource, TResult>(this TSource[] array, ITransformer<TSource,TResult> transformer)
        {
            return array.TransformTo(transformer.Transform);
        }

        /// <summary>
        /// Method transforms TSource type array to TResult type array.
        /// </summary>
        /// <param name="array">
        /// Array to transform.
        /// </param>
        /// <param name="transformer">
        /// Format to transform.
        /// </param>
        /// <returns>
        /// TResult type array.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Array must not be null. Array elements must not be null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Array length must not be zero.
        /// </exception>
        public static TResult[] TransformTo<TSource, TResult>(this TSource[] array, Func<TSource, TResult> transformer)
        {
            InputValidation(array);

            var resultArray = new TResult[array.Length];
            for (int i = 0; i < array.Length; ++i)
            {
                resultArray[i] = transformer.Invoke(array[i]);
            }

            return resultArray;
        }

        /// <summary>
        /// The method returns an array of elements that fall under the filtering rule.
        /// </summary>
        /// <typeparam name="TSource">
        /// Type of elements to filter.
        /// </typeparam>
        /// <param name="array">
        /// Array of elements to filter.
        /// </param>
        /// <param name="filter">
        /// Filtering rule.
        /// </param>
        /// <returns>
        /// An array of TSource type elements that fall under the filtering rule.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Array must not be null. Array elements must not be null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Array length must not be zero.
        /// </exception>
        public static TSource[] Filter<TSource>(this TSource[] array, IFilter<TSource> filter)
        {
            return array.Filter(filter.IsFitThePattern);
        }

        /// <summary>
        /// The method returns an array of elements that fall under the filtering rule.
        /// </summary>
        /// <typeparam name="TSource">
        /// Type of elements to filter.
        /// </typeparam>
        /// <param name="array">
        /// Array of elements to filter.
        /// </param>
        /// <param name="filter">
        /// Filtering rule.
        /// </param>
        /// <returns>
        /// An array of TSource type elements that fall under the filtering rule.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Array must not be null. Array elements must not be null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Array length must not be zero.
        /// </exception>
        public static TSource[] Filter<TSource>(this TSource[] array, Func<TSource, bool> filter)
        {
            InputValidation(array);

            var resultArray = new TSource[array.Length];
            int resultArrayIndex = 0;
            foreach (var element in array)
            {
                if (filter.Invoke(element))
                {
                    resultArray[resultArrayIndex] = element;
                    ++resultArrayIndex;
                }
            }

            Array.Resize(ref resultArray, resultArrayIndex);

            return resultArray;
        }

        private static void InputValidation<TSource>(TSource[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException();
            }

            if (array.Length == 0)
            {
                throw new ArgumentException();
            }

            foreach (var element in array)
            {
                if (Equals(element, null))
                {
                    throw new ArgumentNullException();
                }
            }
        }
    }
}