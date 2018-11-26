using System;
using System.IO;

namespace No4.Solution
{
    /// <summary>
    /// Random file generator.
    /// </summary>
    public abstract class RandomFileGenerator
    {
        /// <summary>
        /// Working directory of file.
        /// </summary>
        public readonly string WorkingDirectory;

        /// <summary>
        /// File extension.
        /// </summary>
        public readonly string FileExtension;

        /// <summary>
        /// Abstract class constructor fills the fields WorkingDirectory and FileExtension.
        /// </summary>
        /// <param name="workingDirectory">
        /// working directory of file.
        /// </param>
        /// <param name="fileExtension">
        /// file extension.
        /// </param>
        /// <exception cref="ArgumentException">
        /// workingDirectory must not be null, empty or whitespace.
        /// fileExtension must not be null, empty or whitespace.
        /// </exception>
        protected RandomFileGenerator(string workingDirectory, string fileExtension)
        {
            if (string.IsNullOrWhiteSpace(workingDirectory))
            {
                throw new ArgumentException(nameof(workingDirectory) + "must not be null, empty or whitespace.");
            }

            if (string.IsNullOrWhiteSpace(workingDirectory))
            {
                throw new ArgumentException(nameof(fileExtension) + "must not be null, empty or whitespace.");
            }

            WorkingDirectory = workingDirectory;
            FileExtension = fileExtension;
        }

        /// <summary>
        /// Generate random files.
        /// </summary>
        /// <param name="filesCount">
        /// files count.
        /// </param>
        /// <param name="contentLength">
        /// length of each file content.
        /// </param>
        /// <exception cref="ArgumentException">
        /// contentLength must not be less than 0.
        /// filesCount must not be less than 0.
        /// </exception>
        public void GenerateFiles(int filesCount, int contentLength)
        {
            if (filesCount < 0)
            {
                throw new ArgumentException(nameof(filesCount) + "must not be less than 0.");
            }

            if (contentLength < 0)
            {
                throw new ArgumentException(nameof(contentLength) + "must not be less than 0.");
            }

            for (var i = 0; i < filesCount; ++i)
            {
                var generatedFileContent = this.GenerateFileContent(contentLength);

                var generatedFileName = $"{Guid.NewGuid()}{this.FileExtension}";

                this.WriteBytesToFile(generatedFileName, generatedFileContent);
            }
        }

        /// <summary>
        /// Generate content.
        /// </summary>
        /// <param name="contentLength">
        /// length of file content.
        /// </param>
        /// <returns>
        /// An array of bytes with generated content.
        /// </returns>
        protected abstract byte[] GenerateFileContent(int contentLength);

        private void WriteBytesToFile(string fileName, byte[] content)
        {
            if (!Directory.Exists(WorkingDirectory))
            {
                Directory.CreateDirectory(WorkingDirectory);
            }

            File.WriteAllBytes($"{WorkingDirectory}//{fileName}", content);
        }
    }
}
