using System;

namespace No4.Solution.RandomFileGeneratorImplementations
{
    /// <summary>
    /// Random bytes file generator.
    /// </summary>
    public class RandomBytesFileGenerator : RandomFileGenerator
    {
        /// <summary>
        /// Initializes a new instance of RandomBytesFileGenerator.
        /// </summary>
        public RandomBytesFileGenerator() : base("Files with random bytes", ".bytes")
        {
        }

        /// <summary>
        /// Generate bytes content.
        /// </summary>
        /// <param name="contentLength">
        /// length of file content.
        /// </param>
        /// <returns>
        /// An array of bytes with generated content.
        /// </returns>
        protected override byte[] GenerateFileContent(int contentLength)
        {
            var random = new Random();

            var fileContent = new byte[contentLength];

            random.NextBytes(fileContent);

            return fileContent;
        }
    }
}
