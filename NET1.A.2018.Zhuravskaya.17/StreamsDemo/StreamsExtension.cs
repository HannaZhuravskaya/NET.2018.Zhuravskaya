using System;
using System.IO;

namespace StreamsDemo
{
    public static class StreamsExtension
    {
        #region Public members

        /// <summary>
        /// By byte file copy.
        /// </summary>
        /// <param name="sourcePath">
        /// copy file path.
        /// </param>
        /// <param name="destinationPath">
        /// copied file path.
        /// </param>
        /// <returns>
        /// number of copied bytes.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// destinationPath must not be null, empty or whitespace.
        /// sourcePath must not be null, empty or whitespace."
        /// sourcePath file not found."
        /// </exception>
        public static int ByByteCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);

            if (sourcePath.Equals(destinationPath))
            {
                return 0;
            }

            long numberOfBytes = 0;
            using (FileStream sourceFileStream = new FileStream(sourcePath, FileMode.Open),
                destinationFileStream = new FileStream(destinationPath, FileMode.Create))
            {
                while (numberOfBytes < sourceFileStream.Length)
                {
                    destinationFileStream.WriteByte((byte)sourceFileStream.ReadByte());
                    numberOfBytes++;
                }
            }

            return (int)numberOfBytes;
        }

        /// <summary>
        /// By byte file copy in memory.
        /// </summary>
        /// <param name="sourcePath">
        /// copy file path.
        /// </param>
        /// <param name="destinationPath">
        /// copied file path.
        /// </param>
        /// <returns>
        /// number of copied bytes.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// destinationPath must not be null, empty or whitespace.
        /// sourcePath must not be null, empty or whitespace."
        /// sourcePath file not found."
        /// </exception>
        public static int InMemoryByByteCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);

            if (sourcePath.Equals(destinationPath))
            {
                return 0;
            }

            using (var streamReader = new StreamReader(sourcePath))
            {
                var sourceInfo = streamReader.ReadToEnd();
                var encoding = streamReader.CurrentEncoding;
                using (var streamWriter = new StreamWriter(destinationPath, false, encoding))
                {
                    var sourceByteInfo = encoding.GetBytes(sourceInfo);

                    byte[] newBytesArray;
                    using (var memoryStream = new MemoryStream(sourceByteInfo))
                    {
                        newBytesArray = memoryStream.ToArray();
                    }

                    var newCharArray = encoding.GetChars(newBytesArray, 0, newBytesArray.Length);
                  
                    streamWriter.Write(newCharArray);

                    return newBytesArray.Length + streamWriter.Encoding.GetPreamble().Length;
                }
            }
        }

        /// <summary>
        /// By bytes block file copy.
        /// </summary>
        /// <param name="sourcePath">
        /// copy file path.
        /// </param>
        /// <param name="destinationPath">
        /// copied file path.
        /// </param>
        /// <returns>
        /// number of copied bytes.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// destinationPath must not be null, empty or whitespace.
        /// sourcePath must not be null, empty or whitespace."
        /// sourcePath file not found."
        /// </exception>
        public static int ByBlockCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);

            if (sourcePath.Equals(destinationPath))
            {
                return 0;
            }

            int sizeOfBlock = 512;
            long numberOfBytes = 0;
            using (FileStream sourceFileStream = new FileStream(sourcePath, FileMode.Open),
                destinationFileStream = new FileStream(destinationPath, FileMode.Create))
            {
                while (numberOfBytes < sourceFileStream.Length)
                {
                    byte[] buffer = new byte[sizeOfBlock];
                    var numberOfBytesToAdd = sourceFileStream.Read(buffer, 0, sizeOfBlock);
                    numberOfBytes += numberOfBytesToAdd;
                    destinationFileStream.Write(buffer, 0, numberOfBytesToAdd);
                }
            }

            return (int)numberOfBytes;
        }

        /// <summary>
        /// By bytes block file copy in memory.
        /// </summary>
        /// <param name="sourcePath">
        /// copy file path.
        /// </param>
        /// <param name="destinationPath">
        /// copied file path.
        /// </param>
        /// <returns>
        /// number of copied bytes.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// destinationPath must not be null, empty or whitespace.
        /// sourcePath must not be null, empty or whitespace."
        /// sourcePath file not found."
        /// </exception>
        public static int InMemoryByBlockCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);

            if (sourcePath.Equals(destinationPath))
            {
                return 0;
            }

            using (var streamReader = new StreamReader(sourcePath))
            {
                var sourceInfo = streamReader.ReadToEnd();
                var encoding = streamReader.CurrentEncoding;

                var sourceByteInfo = encoding.GetBytes(sourceInfo);

                int sizeOfBlock = 512;
                int numberOfBytes = 0;
                using (var memoryStream = new MemoryStream(sourceByteInfo))
                {
                    using (var streamWriter = new StreamWriter(destinationPath, false, encoding))
                    {
                        while (numberOfBytes < sourceByteInfo.Length)
                        {
                            var buffer = new byte[sizeOfBlock];
                            var numberOfBytesToAdd = memoryStream.Read(buffer, 0, sizeOfBlock);
                            numberOfBytes += numberOfBytesToAdd;
                            var newCharArray = encoding.GetChars(buffer, 0, numberOfBytesToAdd);
                            streamWriter.Write(newCharArray);
                        }
                    }
                }

                return numberOfBytes + encoding.GetPreamble().Length;
            }
        }

        /// <summary>
        /// Buffered file copy.
        /// </summary>
        /// <param name="sourcePath">
        /// copy file path.
        /// </param>
        /// <param name="destinationPath">
        /// copied file path.
        /// </param>
        /// <returns>
        /// number of copied bytes.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// destinationPath must not be null, empty or whitespace.
        /// sourcePath must not be null, empty or whitespace."
        /// sourcePath file not found."
        /// </exception>
        public static int BufferedCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);

            if (sourcePath.Equals(destinationPath))
            {
                return 0;
            }

            int numberOfBytes = 0;
            using (var sourceFileStream = new FileStream(sourcePath, FileMode.Open))
            using (var destinationFileStream = new FileStream(destinationPath, FileMode.Create))
            using (var sourceBufferedStream = new BufferedStream(sourceFileStream))
            {
                while (numberOfBytes < sourceBufferedStream.Length)
                {
                    int currentByte = sourceBufferedStream.ReadByte();
                    destinationFileStream.WriteByte((byte)currentByte);
                    numberOfBytes++;
                }
            }
            
            return numberOfBytes;
        }

        /// <summary>
        /// By line file copy.
        /// </summary>
        /// <param name="sourcePath">
        /// copy file path.
        /// </param>
        /// <param name="destinationPath">
        /// copied file path.
        /// </param>
        /// <returns>
        /// number of copied lines.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// destinationPath must not be null, empty or whitespace.
        /// sourcePath must not be null, empty or whitespace."
        /// sourcePath file not found."
        /// </exception>
        public static int ByLineCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);

            int numberOfLines = 0;
            using (var sourceFileStream = new FileStream(sourcePath, FileMode.Open))
            using (var sourceStreamReader = new StreamReader(sourceFileStream))
            using (var destinationStreamWriter = new StreamWriter(destinationPath, false, sourceStreamReader.CurrentEncoding))
            {
                while (sourceStreamReader.Peek() !=  -1)
                {
                    string line = sourceStreamReader.ReadLine();
                    destinationStreamWriter.WriteLine(line);

                    numberOfLines++;
                }
            }
    
            return numberOfLines;
        }

        /// <summary>
        /// Are files equal by the each byte
        /// </summary>
        /// <param name="firstPath">
        /// first file path.
        /// </param>
        /// <param name="secondPath">
        /// second file path.
        /// </param>
        /// <returns>
        /// true if files equal by the each byte; otherwise, false.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// firstPath must not be null, empty or whitespace.
        /// secondPath must not be null, empty or whitespace."
        /// firstPath file not found."
        /// secondPath file not found."
        /// </exception>
        public static bool IsContentEquals(string firstPath, string secondPath)
        {
            using (var sourceFileStream = new FileStream(firstPath, FileMode.Open))
            using (var destinationFileStream = new FileStream(secondPath, FileMode.Open))
            {
                InputValidation(firstPath, secondPath);

                if (!File.Exists(secondPath))
                {
                    throw new ArgumentException($"{nameof(secondPath)} file not found.");
                }

                if (destinationFileStream.Length != sourceFileStream.Length)
                {
                    return false;
                }

                for (int i = 0; i < sourceFileStream.Length; ++i)
                {
                    if (sourceFileStream.ReadByte() != destinationFileStream.ReadByte())
                    {
                        return false;
                    }
                }

                return true;
            }
        }

        #endregion

        #region Private members

        private static void InputValidation(string sourcePath, string destinationPath)
        {
            if (string.IsNullOrEmpty(sourcePath))
            {
                throw new ArgumentException($"{nameof(sourcePath)} must not be null, empty or whitespace.");
            }

            if (string.IsNullOrEmpty(destinationPath))
            {
                throw new ArgumentException($"{nameof(destinationPath)} must not be null, empty or whitespace.");
            }

            if (!File.Exists(sourcePath))
            {
                throw new ArgumentException($"{nameof(sourcePath)} file not found.");
            }
        }

        #endregion
    }
}
