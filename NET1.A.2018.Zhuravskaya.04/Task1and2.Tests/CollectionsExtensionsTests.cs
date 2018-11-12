using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using Task1and2.Interfaces;
using Task1and2.ITransformerImplementations;

namespace Task1and2.Tests
{
    [TestFixture]
    public class CollectionsExtensionsTests
    {
        [TestCaseSource(typeof(DataSourse), nameof(DataSourse.ArrayIsNull))]
        public void TransformTo_ArrayIsNull_ExpectedArgumentNullException(double[] array, ITransformer<double, string> transformer)
            => Assert.Throws<ArgumentNullException>(() =>
                array.Transform(transformer));

        [TestCaseSource(typeof(DataSourse), nameof(DataSourse.ArrayIsNullWithDelegates))]
        public void TransformDelegate_ArrayIsNull_ExpectedArgumentNullException(
            IEnumerable<double> array,
            Func<double, string> transformer)
            => Assert.Throws<ArgumentNullException>(() =>
                array.Transform(transformer));

        [TestCaseSource(typeof(DataSourse), nameof(DataSourse.NotEmptyArray))]
        public void TransformTo_NotEmptyArray_StringArray(
            IEnumerable<double> array,
            ITransformer<double, string> transformer,
            string[] expectedResult)
        {
            var resultList = new List<string>();
            foreach (var element in array.Transform(transformer))
            {
                resultList.Add(element);
            }

            Assert.IsTrue(IsTheSameArrays(resultList.ToArray(), expectedResult));
        }

        [TestCaseSource(typeof(DataSourse), nameof(DataSourse.NotEmptyArrayWithDelegates))]
        public void TransformDelegate_NotEmptyArray_StringArray(
            IEnumerable<double> array,
            Func<double, string> transformer,
            string[] expectedResult)
        {
            var resultList = new List<string>();
            foreach (var element in array.Transform(transformer))
            {
                resultList.Add(element);
            }

            Assert.IsTrue(IsTheSameArrays(resultList.ToArray(), expectedResult));
        }

        [TestCase(8, new int[]{0, 1, 1, 2, 3, 5, 8, 13})]
        [TestCase(3, new int[] { 0, 1, 1 })]
        [TestCase(5, new int[] { 0, 1, 1, 2, 3 })]
        public void Fibonacci_ValidInput_SequenceOfFibonacciNumbers(int count, int[] expectedArray)
        {
            var resultArray = new int[count];
            int cnt = 0;

            foreach (var element in CollectionsExtensions.Fibonacci(count))
            {
                resultArray[cnt++] = (int)element;
            }

            Assert.IsTrue(IsTheSameArrays(resultArray, expectedArray));
        }

        [TestCase(-1)]
        [TestCase(-1000)]
        public void Fibonacci_InvalidInput_ExpectedArgumentOutOfRangeException(int count)
            => Assert.Throws<ArgumentOutOfRangeException>(() => CollectionsExtensions.Fibonacci(count));

        private bool IsTheSameArrays<T>(T[] array, T[] expectedArray) where T : IEquatable<T>
        {
            if (array.Length != expectedArray.Length)
            {
                return false;
            }

            for (int i = 0; i < array.Length; ++i)
            {
                if (!array[i].Equals(expectedArray[i]))
                {
                    return false;
                }
            }

            return true;
        }
    }

    internal class DataSourse
    {
        public static IEnumerable ArrayIsNull
        {
            get
            {
                yield return new TestCaseData(null, new DoubleToIEEE754Transformer());
                yield return new TestCaseData(null, new DoubleToWordsTransformer());
            }
        }

        public static IEnumerable ArrayLengthIsZero
        {
            get
            {
                yield return new TestCaseData(new double[0], new DoubleToIEEE754Transformer());
                yield return new TestCaseData(new double[0], new DoubleToWordsTransformer());
            }
        }

        public static IEnumerable NotEmptyArray
        {
            get
            {
                yield return new TestCaseData(
                    new[]
                    {
                        -23.809,
                        0.295,
                        15.17,
                        -0.00001,
                        1234.1234,
                        double.NaN
                    },
                    new DoubleToWordsTransformer(),
                    new[]
                    {
                        "minus two three point eight zero nine",
                        "zero point two nine five", "one five point one seven",
                        "minus zero point zero zero zero zero one",
                        "one two three four point one two three four",
                        "NaN"
                    });
                yield return new TestCaseData(
                    new[]
                    {
                        -255.255,
                        255.255,
                        4294967295.0
                    },
                    new DoubleToIEEE754Transformer(),
                    new[]
                    {
                        "1100000001101111111010000010100011110101110000101000111101011100",
                        "0100000001101111111010000010100011110101110000101000111101011100",
                        "0100000111101111111111111111111111111111111000000000000000000000"
                    });
                yield return new TestCaseData(
                    new[]
                    {
                        double.MinValue, double.MaxValue, double.Epsilon, double.NaN, double.NegativeInfinity,
                        double.PositiveInfinity, -0.0, 0.0
                    },
                    new DoubleToIEEE754Transformer(),
                    new[]
                    {
                        "1111111111101111111111111111111111111111111111111111111111111111",
                        "0111111111101111111111111111111111111111111111111111111111111111",
                        "0000000000000000000000000000000000000000000000000000000000000001",
                        "1111111111111000000000000000000000000000000000000000000000000000",
                        "1111111111110000000000000000000000000000000000000000000000000000",
                        "0111111111110000000000000000000000000000000000000000000000000000",
                        "1000000000000000000000000000000000000000000000000000000000000000",
                        "0000000000000000000000000000000000000000000000000000000000000000"
                    });
            }
        }

        public static IEnumerable ArrayIsNullWithDelegates
        {
            get
            {
                double[] a = {3, 4};

                yield return new TestCaseData(null,
                    new Func<double, string>(new DoubleToIEEE754Transformer().Transform));
                yield return new TestCaseData(null,
                    new Func<double, string>(new DoubleToWordsTransformer().Transform));
            }
        }

        public static IEnumerable ArrayLengthIsZeroWithDelegates
        {
            get
            {
                yield return new TestCaseData(new double[0],
                    new Func<double, string>(new DoubleToIEEE754Transformer().Transform));
                yield return new TestCaseData(new double[0],
                    new Func<double, string>(new DoubleToWordsTransformer().Transform));
            }
        }

        public static IEnumerable NotEmptyArrayWithDelegates
        {
            get
            {
                Func<double, string> ieee754Transformer = new DoubleToIEEE754Transformer().Transform;
                Func<double, string> wordsTransformer = new DoubleToWordsTransformer().Transform;
                yield return new TestCaseData(
                    new[]
                    {
                        -23.809,
                        0.295,
                        15.17,
                        -0.00001,
                        1234.1234,
                        double.NaN
                    },
                    wordsTransformer,
                    new[]
                    {
                        "minus two three point eight zero nine",
                        "zero point two nine five", "one five point one seven",
                        "minus zero point zero zero zero zero one",
                        "one two three four point one two three four",
                        "NaN"
                    });
                yield return new TestCaseData(
                    new[]
                    {
                        -255.255,
                        255.255,
                        4294967295.0
                    },
                    ieee754Transformer,
                    new[]
                    {
                        "1100000001101111111010000010100011110101110000101000111101011100",
                        "0100000001101111111010000010100011110101110000101000111101011100",
                        "0100000111101111111111111111111111111111111000000000000000000000"
                    });
                yield return new TestCaseData(
                    new[]
                    {
                        double.MinValue, double.MaxValue, double.Epsilon, double.NaN, double.NegativeInfinity,
                        double.PositiveInfinity, -0.0, 0.0
                    },
                    ieee754Transformer,
                    new[]
                    {
                        "1111111111101111111111111111111111111111111111111111111111111111",
                        "0111111111101111111111111111111111111111111111111111111111111111",
                        "0000000000000000000000000000000000000000000000000000000000000001",
                        "1111111111111000000000000000000000000000000000000000000000000000",
                        "1111111111110000000000000000000000000000000000000000000000000000",
                        "0111111111110000000000000000000000000000000000000000000000000000",
                        "1000000000000000000000000000000000000000000000000000000000000000",
                        "0000000000000000000000000000000000000000000000000000000000000000"
                    });
            }
        }
    }
}