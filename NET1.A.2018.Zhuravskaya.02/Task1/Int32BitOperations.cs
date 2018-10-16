using System;

namespace Task1
{
    /// <summary>
    /// The class contains the operations with bits in the signed four-byte numbers.
    /// </summary>
    public static class Int32BitOperations
    {
        /// <summary>
        /// Inserts bits of one number into another.
        /// </summary>
        /// <param name="num1">The number in which the bits are inserted.</param>
        /// <param name="num2">The number to insert bits.</param>
        /// <param name="startIndex">The zero-based position to begin inserting bits.</param>
        /// <param name="endIndex">The end position to inserting bits.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if startIndex or endIndex greater than 31 or less than 0.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown if startIndex greater than endIndex.
        /// </exception>
        /// <returns>
        /// Returns the first number with the inserted bits of the second number.
        /// </returns>
        public static int InsertNumber(int num1, int num2, int startIndex, int endIndex)
        {
            if (startIndex > 31 || endIndex > 31 || startIndex < 0 || endIndex < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (startIndex > endIndex)
            {
                throw new ArgumentException();
            }

            int mask = ~1 << (endIndex - startIndex);

            int firstNumberWithZeroesInPositionToInsert = (~(~mask << startIndex)) & num1;
            int secondNumberWithZeroesInPositionNotToInsert = (num2 & ~mask) << startIndex;

            return firstNumberWithZeroesInPositionToInsert | secondNumberWithZeroesInPositionNotToInsert;
        }
    }
}
