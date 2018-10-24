using System.Runtime.InteropServices;
using static System.String;

namespace Task2
{
    /// <summary>
    /// DoubleExtension class contains extension methods for double.
    /// </summary>
    public static class DoubleExtension
    {
        /// <summary>
        /// Extension method converts a double to IEEE 754 format.
        /// </summary>
        /// <param name="number">
        /// Source number.
        /// </param>
        /// <returns>
        /// Source number in IEEE 754 format.
        /// </returns>
        public static string ConvertToIEEE754String(this double number)
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
            return Join("", doubleToIEEE754Format);
        }

        [StructLayout(LayoutKind.Explicit)]
        private struct DoubleToLong
        {
            [FieldOffset(0)]
            public double PlaceForDouble;

            [FieldOffset(0)]
            public readonly long PlaceForLong;
        }
    }
}