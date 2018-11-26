﻿using System;
using System.Linq;
using System.Text;

namespace No4.Solution.RandomFileGeneratorImplementations
{
    public class RandomCharsFileGenerator : RandomFileGenerator
    {
        public RandomCharsFileGenerator() : base("Files with random chars", ".txt")
        {
        }

        protected override byte[] GenerateFileContent(int contentLength)
        {
            var generatedString = this.RandomString(contentLength);

            var bytes = Encoding.Unicode.GetBytes(generatedString);

            return bytes;
        }

        private string RandomString(int size)
        {
            var random = new Random();

            const string Input = "abcdefghijklmnopqrstuvwxyz0123456789";

            var chars = Enumerable.Range(0, size).Select(x => Input[random.Next(0, Input.Length)]);

            return new string(chars.ToArray());
        }
    }
}