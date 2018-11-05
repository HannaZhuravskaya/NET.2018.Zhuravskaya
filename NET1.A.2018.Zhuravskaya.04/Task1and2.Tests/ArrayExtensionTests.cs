using System;
using System.Collections;
using NUnit.Framework;

namespace Task1and2.Tests
{
    [TestFixture]
    public class ArrayExtensionTests
    {
        [TestCaseSource(typeof(DataSourse), nameof(DataSourse.ArrayIsNull))]
        public void TransformTo_ArrayIsNull_ExpectedArgumentNullException(double[] array, ITransformer transformer)
            => Assert.Throws<ArgumentNullException>(() =>
                array.TransformTo(transformer));

        [TestCaseSource(typeof(DataSourse), nameof(DataSourse.ArrayIsNullWithDelegates))]
        public void TransformDelegate_ArrayIsNull_ExpectedArgumentNullException(
            double[] array,
            Func<double, string> transformer)
            => Assert.Throws<ArgumentNullException>(() =>
                array.TransformTo(transformer));

        [TestCaseSource(typeof(DataSourse), nameof(DataSourse.ArrayLengthIsZero))]
        public void TransformTo_ArrayLengthIsNull_ExpectedArgumentException(double[] array, ITransformer transformer)
            => Assert.Throws<ArgumentException>(() =>
                array.TransformTo(transformer));

        [TestCaseSource(typeof(DataSourse), nameof(DataSourse.ArrayLengthIsZeroWithDelegates))]
        public void TransformDelegate_ArrayLengthIsNull_ExpectedArgumentException(double[] array, Func<double, string> transformer)
            => Assert.Throws<ArgumentException>(() =>
                array.TransformTo(transformer));

        [TestCaseSource(typeof(DataSourse), nameof(DataSourse.NotEmptyArray))]
        public void TransformTo_NotEmptyArray_StringArray(
            double[] array,
            ITransformer transformer,
            string[] expectedResult)
        {
            Assert.IsTrue(IsTheSameArrays(array.TransformTo(transformer), expectedResult));
        }

        [TestCaseSource(typeof(DataSourse), nameof(DataSourse.NotEmptyArrayWithDelegates))]
        public void TransformDelegate_NotEmptyArray_StringArray(
            double[] array,
            Func<double, string> transformer,
            string[] expectedResult)
        {
            Assert.IsTrue(IsTheSameArrays(array.TransformTo(transformer), expectedResult));
        }

        private bool IsTheSameArrays(string[] array, string[] expectedArray)
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