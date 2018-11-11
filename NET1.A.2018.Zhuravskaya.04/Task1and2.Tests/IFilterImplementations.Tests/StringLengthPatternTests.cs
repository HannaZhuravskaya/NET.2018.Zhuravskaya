using System;
using NUnit.Framework;
using Task1and2.IFilterImplementations;

namespace Task1and2.Tests.IFilterImplementations.Tests
{
    [TestFixture]
    public class StringLengthPatternTests
    {
        [Test]
        public void IsFitThePattern_SourceStringIsNull_ExpectedArgumentNullException()
            => Assert.Throws<ArgumentNullException>(() => new StringLengthPattern(1).IsFitThePattern(null));

        [TestCase(-1, "")]
        [TestCase(-100, "asd")]
        [TestCase(-10000, "asdgg")]
        public void IsFitThePattern_PatternLengthLessThanZero_ExpectedArgumentException(int length, string sourceToFilter)
            => Assert.Throws<ArgumentException>(() => new StringLengthPattern(length).IsFitThePattern(sourceToFilter));

        [Test]
        public void IsFitThePattern_PatternLengthIsNine_ArrayOfStringsWhereLengthIsNine()
        {
            var source = new string[]
            {
                "123456789",
                "12345",
                "123",
                "1"
            };

            var expectedResult = new string[]
            {
               "123456789"
            };

            var result = source.Filter(new StringLengthPattern(9));

            CollectionAssert.AreEqual(result, expectedResult);
        }
    }
}
