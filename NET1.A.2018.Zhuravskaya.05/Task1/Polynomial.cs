using System;
using System.Text;

namespace Task1
{
    /// <summary>
    /// Сlass contains a polynomial of one variable.
    /// </summary>
    public class Polynomial
    {
        private double[] _coefficients;

        /// <summary>
        /// Initializes a new instance of the Polynomial class for the value indicated by an array of polynomial coefficients.
        /// </summary>
        /// <param name="polynomialCoefficients">
        /// An array of polynomial coefficients.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// polynomialCoefficients is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// polynomialCoefficients length is zero.
        /// </exception>
        public Polynomial(double[] polynomialCoefficients)
        {
            Coefficients = polynomialCoefficients;
            Degree = Coefficients.Length;
        }

        /// <summary>
        /// Gets the degree of polynomial in the current Polynomial object.
        /// </summary>
        /// <returns>
        /// The degree of polynomial in the current Polynomial object.
        /// </returns>
        public int Degree { get; }

        /// <summary>
        /// Gets the array of polynomial coefficients in the current Polynomial object.
        /// </summary>
        /// <returns>
        /// The array of polynomial coefficients in the current Polynomial object.
        /// </returns>
        public double[] Coefficients
        {
            get
            {
                var returnedArray = new double[_coefficients.Length];
                _coefficients.CopyTo(returnedArray, 0);
                return returnedArray;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }

                if (value.Length == 0)
                {
                    throw new ArgumentException();
                }

                _coefficients = new double[value.Length];
                Array.Copy(value, _coefficients, value.Length);
            }
        }

        /// <summary>
        /// Gets the polynomial coefficient at a specified degree in the current Polynomial object.
        /// </summary>
        /// <param name="degree">
        /// Degree in the current polynomial.
        /// </param>
        /// <returns>
        /// The polynomial coefficient at degree.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// degree should not be less than zero and greater than the current Polynomial object degree.
        /// </exception>
        public double this[int degree]
        {
            get
            {
                if (degree >= Degree || degree < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }

                return Coefficients[degree];
            }
        }

        /// <summary>
        /// The method calculates the sum of polynomials. 
        /// </summary>
        /// <param name="pol1">
        /// First Polynomial object.
        /// </param>
        /// <param name="pol2">
        /// Second Polynomial object.
        /// </param>
        /// <returns>
        /// Sum of Polynomials.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// pol1 or pol2 is null.
        /// </exception>
        public static Polynomial operator +(Polynomial pol1, Polynomial pol2)
        {
            CheckConditions(pol1, pol2);

            var result = new double[Math.Max(pol1.Degree, pol2.Degree)];
            for (var i = 0; i < pol1.Degree; ++i)
            {
                result[i] += pol1.Coefficients[i];
            }

            for (var i = 0; i < pol2.Degree; ++i)
            {
                result[i] += pol2.Coefficients[i];
            }

            return new Polynomial(result);
        }

        /// <summary>
        /// The method calculates the difference between first and second polynomials. 
        /// </summary>
        /// <param name="pol1">
        /// First Polynomial object.
        /// </param>
        /// <param name="pol2">
        /// Second Polynomial object.
        /// </param>
        /// <returns>
        /// The difference of polynomials.
        /// </returns>
        /// /// <exception cref="ArgumentNullException">
        /// pol1 or pol2 is null.
        /// </exception>
        public static Polynomial operator -(Polynomial pol1, Polynomial pol2)
        {
            CheckConditions(pol1, pol2);

            var result = new double[Math.Max(pol1.Degree, pol2.Degree)];
            for (var i = 0; i < pol1.Degree; ++i)
            {
                result[i] += pol1.Coefficients[i];
            }

            for (var i = 0; i < pol2.Degree; ++i)
            {
                result[i] -= pol2.Coefficients[i];
            }

            return new Polynomial(result);
        }

        /// <summary>
        /// The method calculates the product of two polynomials.
        /// </summary>
        /// <param name="pol1">
        /// First Polynomial object.
        /// </param>
        /// <param name="pol2">
        /// Second Polynomial object.
        /// </param>
        /// <returns>
        /// The product of two polynomials.
        /// </returns>
        /// /// <exception cref="ArgumentNullException">
        /// pol1 or pol2 is null.
        /// </exception>
        public static Polynomial operator *(Polynomial pol1, Polynomial pol2)
        {
            CheckConditions(pol1, pol2);

            var result = new double[pol1.Degree + pol2.Degree - 1];
            for (var i = 0; i < pol1.Degree; ++i)
            {
                for (var j = 0; j < pol2.Degree; ++j)
                {
                    result[i + j] += pol1.Coefficients[i] * pol2.Coefficients[j];
                }
            }

            return new Polynomial(result);
        }

        /// <summary>
        /// Determines whether two polynomials have the same structure.
        /// </summary>
        /// <param name="pol1">
        /// The first Polinomial object to compare, or null.
        /// </param>
        /// <param name="pol2">
        /// The second Polinomial object to compare, or null.
        /// </param>
        /// <returns>
        /// true if the structure of pol1 is the same as the structure of pol2; otherwise, false.
        /// </returns>
        public static bool operator ==(Polynomial pol1, Polynomial pol2)
        {
            if (pol1 != null)
            {
                return pol1.Equals(pol2);
            }

            if (pol2 != null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Determines whether two polynomials have different structure.
        /// </summary>
        /// <param name="pol1">
        /// The first Polinomial object to compare, or null.
        /// </param>
        /// <param name="pol2">
        /// The second Polinomial object to compare, or null.
        /// </param>
        /// <returns>
        /// true if the structure of pol1 is different as the structure of pol2; otherwise, false.
        /// </returns>
        public static bool operator !=(Polynomial pol1, Polynomial pol2)
        {
            return !(pol1 == pol2);
        }
        
        /// <summary>
        /// Returns the hash code for this polynomial.
        /// </summary>
        /// <returns>
        /// A 32-bit signed integer hash code.
        /// </returns>
        public override int GetHashCode()
        {
            int result = 0;

            for (int i = 0; i < Degree; ++i)
            {
                result = result * 23 + Coefficients[i].GetHashCode();
            }

            return result;
        }

        /// <summary>
        /// Determines whether this instance and another specified Polynomial object have the same structure.
        /// </summary>
        /// <param name="o">
        /// The polynomial to compare to this instance.
        /// </param>
        /// <returns>
        /// true if the structure of the parameter is the same as the structure of this instance; otherwise, false.
        /// </returns>
        public override bool Equals(object o)
        {
            Polynomial pol = o as Polynomial;

            if (pol == null)
            {
                return false;
            }

            if (pol.Degree != Degree)
            {
                return false;
            }

            for (var i = 0; i < pol.Degree; ++i)
            {
                if (Math.Abs(pol.Coefficients[i] - Coefficients[i]) > double.Epsilon)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Returns this instance of Polynomial; no actual conversion is performed.
        /// </summary>
        /// <returns>
        /// The current polynomial.
        /// </returns>
        public override string ToString()
        {
            var resultString = new StringBuilder();
            for (var i = Degree - 1; i >= 0; --i)
            {
                if (Math.Abs(Coefficients[i]) > double.Epsilon)
                {
                    if (Coefficients[i] < 0)
                    {
                        resultString.Append(" - ");
                    }
                    else
                    {
                        if (i != Degree - 1)
                        {
                            resultString.Append(" + ");
                        }
                    }

                    if (Math.Abs(Coefficients[i] - 1) > double.Epsilon &&
                        Math.Abs(Coefficients[i] + 1) > double.Epsilon && i > 0)
                    {
                        resultString.Append(Math.Abs(Coefficients[i]));

                        resultString.Append(" * ");
                    }
                    else if (i == 0)
                    {
                        resultString.Append(Math.Abs(Coefficients[i]));
                    }

                    if (i > 0)
                    {
                        resultString.Append("x");
                    }

                    if (i > 1)
                    {
                        resultString.Append("^" + i);
                    }
                }
            }

            return resultString.ToString();
        }

        private static void CheckConditions(Polynomial pol1, Polynomial pol2)
        {
            if (pol1 == null || pol2 == null)
            {
                throw new ArgumentNullException();
            }
        }
    }
}