using System;

namespace Task1and2
{
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
        /// <returns>
        /// Array of strings.
        /// </returns>
        public static string[] TransformTo(this double[] array, ITransformer transformer)
        {
            return array.TransformTo(transformer.Transform);
        }

        /// <summary>
        /// Method transforms double array to string array.
        /// </summary>
        /// <param name="array">
        /// Array to transform.
        /// </param>
        /// <param name="transformer">
        /// Format to transform.
        /// </param>
        /// <returns>
        /// Array of strings.
        /// </returns>
        public static string[] TransformTo(this double[] array, Func<double, string> transformer)
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