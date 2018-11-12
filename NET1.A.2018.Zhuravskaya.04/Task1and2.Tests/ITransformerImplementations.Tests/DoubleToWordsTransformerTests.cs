using NUnit.Framework;
using Task1and2.ITransformerImplementations;

namespace Task1and2.Tests.ITransformerImplementations.Tests
{
    [TestFixture]
    public class DoubleToWordsTransformerTests
    {
        [TestCase(-23.809, ExpectedResult = "minus two three point eight zero nine")]
        [TestCase(0.295, ExpectedResult = "zero point two nine five")]
        [TestCase(15.17, ExpectedResult = "one five point one seven")]
        [TestCase(-0.00001, ExpectedResult = "minus zero point zero zero zero zero one")]
        [TestCase(1234.1234, ExpectedResult = "one two three four point one two three four")]
        [TestCase(double.NaN, ExpectedResult = "NaN")]
        public string Transform_RealNumber_WordsFormatString(double number)
        {
            System.Diagnostics.Debug.WriteLine(new DoubleToWordsTransformer().Transform(number));
            return new DoubleToWordsTransformer().Transform(number);
        }
    }
}