using System.Runtime.InteropServices;

namespace Task1and2
{
    /// <summary>
    /// The implementation of ITransformer interface. Transform double to IEEE 754 format string.
    /// </summary>
    public class DoubleToIEEE754Transformer : ITransformer<double, string>
    {
        /// <summary>
        /// Method converts a double to IEEE 754 format.
        /// </summary>
        /// <param name="number">
        /// Source number.
        /// </param>
        /// <returns>
        /// Source number in IEEE 754 format.
        /// </returns>
        public string Transform(double number)
        {
            var numberOfBytes = 64;
            var doubleToLong = new DoubleToLong() { PlaceForDouble = number };
            var numberToLong = doubleToLong.PlaceForLong;

            var doubleToIEEE754Format = new char[numberOfBytes];

            for (int i = numberOfBytes - 1; i >= 0; --i)
            {
                if ((numberToLong & 1) == 1)
                {
                    doubleToIEEE754Format[i] = '1';
                }
                else
                {
                    doubleToIEEE754Format[i] = '0';
                }

                numberToLong >>= 1;
            }

            return string.Join(string.Empty, doubleToIEEE754Format);
        }

        [StructLayout(LayoutKind.Explicit)]
        private struct DoubleToLong
        {
            [FieldOffset(0)]
            public readonly long PlaceForLong;

            [FieldOffset(0)]
            public double PlaceForDouble;
        }
    }
}