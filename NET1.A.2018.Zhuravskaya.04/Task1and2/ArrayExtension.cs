﻿using System;

namespace Task1and2
{
    /// <summary>
    /// Delegate performing methods for converting from a real number to a string.
    /// </summary>
    /// <param name="number">
    /// Real number.
    /// </param>
    /// <returns>
    /// Real number in string format.
    /// </returns>
    public delegate string TransformerDelegate(double number);

    /// <summary>
    /// Class contains extensions method for array.
    /// </summary>
    public static class ArrayExtension
    {
        /// <summary>
        /// Method transforms double array to string array.
        /// </summary>
        /// <param name="array">
        /// Array to transform.
        /// </param>
        /// <param name="transformer">
        /// Format to transform.
        /// </param>
        /// <returns></returns>
        public static string[] TransformTo(this double[] array, ITransformer transformer)
        {
            TransformToInputValidation(array);

            var stringArray = new string[array.Length];
            for (int i = 0; i < array.Length; ++i)
            {
                stringArray[i] = transformer.Transform(array[i]);
            }

            return stringArray;
        }

        public static string[] TransformTo(this double[] array, TransformerDelegate transformer)
        {
            TransformToInputValidation(array);

            var stringArray = new string[array.Length];
            for (int i = 0; i < array.Length; ++i)
            {
                stringArray[i] = transformer.Invoke(array[i]);
            }

            return stringArray;
        }

        private static void TransformToInputValidation(double[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException();
            }

            if (array.Length == 0)
            {
                throw new ArgumentException();
            }
        }
    }
}