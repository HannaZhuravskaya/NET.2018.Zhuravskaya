namespace Task1and2
{
    /// <summary>
    /// The implementation of ITransformer interface. Transform double to word format.
    /// </summary>
    public class DoubleToWordsTransformer : ITransformer<double, string>
    {
        /// <summary>
        /// Method takes real number and converts it into "word format".
        /// </summary>
        /// <param name="number">Real numbers.</param>
        /// <returns>"Word format" number.</returns>
        public string Transform(double number)
        {
            if (double.IsNaN(number))
            {
                return "NaN";
            }

            var symbols = "0123456789,-+E";
            var words = "zero one two three four five six seven eight nine point minus plus exp".Split(' ');
            var numberInStringFormat = ((decimal)number).ToString();
            var result = new string[numberInStringFormat.Length];
            for (int i = 0; i < numberInStringFormat.Length; ++i)
            {
                result[i] = words[symbols.IndexOf(numberInStringFormat[i])];
            }

            return string.Join(" ", result);
        }
    }
}