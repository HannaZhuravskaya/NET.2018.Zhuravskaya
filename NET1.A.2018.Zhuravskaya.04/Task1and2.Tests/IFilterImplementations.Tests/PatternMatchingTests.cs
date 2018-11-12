using System;
using NUnit.Framework;
using Task1and2.IFilterImplementations;

namespace Task1and2.Tests.IFilterImplementations.Tests
{
    [TestFixture]
    public class PatternMatchingTests
    {
        [Test]
        public void IsFitThePattern_PatternStringIsNull_ExpectedArgumentNullException()
            => Assert.Throws<ArgumentNullException>(()=>new PatternMatching(null).Filter("asdfg"));

        [Test]
        public void IsFitThePattern_SourceStringIsNull_ExpectedArgumentNullException()
            => Assert.Throws<ArgumentNullException>(() => new PatternMatching("asdfg").Filter(null));

        [Test]
        public void IsFitThePattern_PatternStringLengthIsZero_ExpectedArgumentException()
            => Assert.Throws<ArgumentException>(() => new PatternMatching("").Filter("asdfg"));

        [Test]
        public void IsFitThePattern_PatternStringElvis_ArrayContainsWordElvis()
        {
            var source = new string[]
            {
                "Some people believe that Elvis is alive today.",
                "It takes all kinds, I suppose.Elvis was sometimes",
                "known as \"Elvis the Pelvis\".Here is ELviS with",
                "weird capitalization."
            };

            var expectedResult = new string[]
            {
                "Some people believe that Elvis is alive today.",
                "It takes all kinds, I suppose.Elvis was sometimes",
                "known as \"Elvis the Pelvis\".Here is ELviS with",
            };

            var result = source.Filter(new PatternMatching("elvis"));

            CollectionAssert.AreEqual(result, expectedResult);
        }
    }
}
