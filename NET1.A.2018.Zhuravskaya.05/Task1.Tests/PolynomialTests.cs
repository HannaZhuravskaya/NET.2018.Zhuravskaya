using System;
using NUnit.Framework;

namespace Task1.Tests
{
    [TestFixture]
    public class PolynomialTests
    {
        [Test]
        public void Polynomial_NullArgument_ExpectedArgumentNullException()
            => Assert.Throws<ArgumentNullException>(() => new Polynomial(null));

        [Test]
        public void Polynomial_EmptyArrayOfPolynomialCoefficients_ExpectedArgumentException()
            => Assert.Throws<ArgumentException>(() => new Polynomial(new double[] { }));

        [TestCase(new[] { 2.3, 1, -5, 0, 1.1 }, ExpectedResult = 4)]
        [TestCase(new[] { 0.0, 0, 0, 0, 0, 0 }, ExpectedResult = 0)]
        [TestCase(new[] { 1.0, -1 }, ExpectedResult = 1)]
        public int Degree_PolynomialCoefficients_ExpectedPolynomialDegree(double[] polynomialCoefficients)
        {
            return new Polynomial(polynomialCoefficients).Degree;
        }

        [TestCase(new[] { 2.3, 1, -5, 0, 1.1 })]
        [TestCase(new[] { 0.0, 0, 0, 0, 0, 0 })]
        [TestCase(new[] { 1.0, -1 })]
        public void Coefficients_PolynomialCoefficients_ExpectedPolynomialCoefficientsOfPolynomialObject(
            double[] polynomialCoefficients)
        {
            var pol = new Polynomial(polynomialCoefficients);
            Assert.True(CheckArrayEquals(pol.Coefficients, polynomialCoefficients));
        }

        [TestCase(new[] { 2.3, 1, -5, 0, 1.1 }, 0, 2.3)]
        [TestCase(new[] { 1.0, -1 }, 1, -1)]
        public void Indexator_PolynomialCoefficients_ExpectedPolynomialCoefficientAtDegree(
            double[] polynomialCoefficients, int degree, double expectedCoefficient)
        {
            var pol = new Polynomial(polynomialCoefficients);
            Assert.True(Math.Abs(pol[degree] - expectedCoefficient) < double.Epsilon);
        }

        [TestCase(new[] { 2.3, 1, -5, 0, 1.1 }, 10)]
        [TestCase(new[] { 0.0, 0, 0, 0, 0, 0 }, -1)]
        public void Indexator_PolynomialCoefficients_ExpectedArgumentOutOfRangeException(
            double[] polynomialCoefficients, int degree)
        {
            var pol = new Polynomial(polynomialCoefficients);

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var polynomialCoefficient = pol[degree];
            });
        }

        /*[TestCase(new double[] { 1, 1 }, new double[] { 1, 1 }, new double[] { 2, 2 })]
        public void AddOperator_TwoPolynomials_ExpectedSumOfPolynomials(double[] polynomialCoefficients1, double[] polynomialCoefficients2, double[] expectedPolynomial)
        {
            var pol1 = new Polynomial(polynomialCoefficients1);
            var pol2 = new Polynomial(polynomialCoefficients2);
            var pol3 = pol1 + pol2;

            Assert.True(CheckArrayEquals(pol3.Coefficients, expectedPolynomial));
        }

        [TestCase(new double[] { 1, 1 }, new double[] { 1, 1 }, new double[] { 0, 0 })]
        public void SubtractionOperator_TwoPolynomials_ExpectedDifferenceBetweenPolynomials(double[] pol1, double[] pol2, double[] expectedPolynomial)
        {
            var pol3 = new Polynomial(pol1) - new Polynomial(pol2);

            Assert.True(CheckArrayEquals(pol3.Coefficients, expectedPolynomial));
        }

        [TestCase(new double[] { 1, 1 }, new double[] { 1, 1 }, new double[]{1, 2, 1})]
        public void MultiplicationOperator_TwoPolynomials_ExpectedProductOfPolynomials(double[] pol1, double[] pol2, double[] expectedPolynomial)
        {
           var pol3 = new Polynomial(pol1) * new Polynomial(pol2);

           Assert.True(CheckArrayEquals(pol3.Coefficients, expectedPolynomial));
        }*/

        private bool CheckArrayEquals(double[] firstArray, double[] secondArray)
        {
            if (firstArray.Length != secondArray.Length)
            {
                return false;
            }

            for (int i = 0; i < firstArray.Length; ++i)
            {
                if (Math.Abs(firstArray[i] - secondArray[i]) > double.Epsilon)
                {
                    return false;
                }
            }

            return true;
        }
    }
}