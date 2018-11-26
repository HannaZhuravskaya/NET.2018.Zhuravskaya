﻿using No4.Solution.RandomFileGeneratorImplementations;

namespace No4.Solution.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var bytes = new RandomBytesFileGenerator();
            bytes.GenerateFiles(2, 10);
            var chars = new RandomCharsFileGenerator();
            chars.GenerateFiles(2, 10);
        }
    }
}