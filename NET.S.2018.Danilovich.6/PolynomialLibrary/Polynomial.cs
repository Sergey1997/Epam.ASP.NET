using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolynomialLibrary
{
    /// <summary>   
    /// A polynomial class. 
    /// </summary>
    public class Polynomial
    {
        #region Fields

        /// <summary>   
        /// The coefficients of polinomial. 
        /// </summary>
        private readonly double[] coefficients;

        #endregion

        #region Constructors
        /// <summary>   Constructor  of polinomial. </summary>
        /// <param name="accuracy"> The accuracy for right equal. </param>
        /// <param name="array">    A variable-length parameters list containing coeffitients of polynomial. </param>
        public Polynomial(double accuracy, params double[] array)
        {
            this.coefficients = array;
            Accuracy = accuracy;
        }

        #endregion

        /// <summary>   Gets the accuracy. </summary>
        /// <value> The accuracy. </value>
        public double Accuracy { get; } = 0.0001;

        #region Overloadings

        /// <summary>   Subtraction operator. </summary>
        /// <param name="lhs">  The left hand side. </param>
        /// <param name="rhs">  The right hand side. </param>
        /// <returns>   The result of the operation. </returns>
        public static Polynomial operator -(Polynomial lhs, Polynomial rhs)
        {
            return Substract(lhs, rhs);
        }

        public static Polynomial operator +(Polynomial lhs, Polynomial rhs)
        {
            return Add(lhs, rhs);
        }

        public static Polynomial operator +(Polynomial lhs, double number)
        {
            return Add(lhs, number);
        }

        public static Polynomial operator *(Polynomial lhs, Polynomial rhs)
        {
            return Multiply(lhs, rhs);
        }

        public static Polynomial operator *(Polynomial lhs, double number)
        {
            return Multiply(lhs, number);
        }

        /// <summary>   Inequality operator. </summary>
        /// <param name="lhs">  The left hand side. </param>
        /// <param name="rhs">  The right hand side. </param>
        /// <returns>   The result of the operation. </returns>
        public static bool operator !=(Polynomial lhs, Polynomial rhs)
        {
            return lhs == rhs ? false : true;
        }

        public static bool operator ==(Polynomial lhs, Polynomial rhs)
        {
            return IsEquals(lhs, rhs);
        }

        #endregion
        #region Public Methods
        /// <summary>   Adds polynomials. </summary>
        /// <exception cref="ArgumentNullException">    Thrown when one or more required arguments are
        ///                                             null. </exception>
        /// <param name="lhs">  The left hand side. </param>
        /// <param name="rhs">  The right hand side. </param>
        /// <returns>   A computed polynomial. </returns>
        public static Polynomial Add(Polynomial lhs, Polynomial rhs)
        {
            if (lhs.coefficients == null || rhs.coefficients == null)
            {
                throw new ArgumentNullException("Arguments cant be a null");
            }

            int maxLength = Math.Max(lhs.coefficients.Length, rhs.coefficients.Length);
            int minLength = Math.Min(lhs.coefficients.Length, rhs.coefficients.Length);
            double[] result = new double[maxLength];

            if (lhs.coefficients.Length == maxLength)
            {
                Array.Copy(lhs.coefficients, result, maxLength);
                for (int i = 0; i < minLength; i++)
                {
                    result[i] += rhs.coefficients[i];
                }
            }
            else
            {
                Array.Copy(rhs.coefficients, result, maxLength);
                for (int i = 0; i < minLength; i++)
                {
                    result[i] += lhs.coefficients[i];
                }
            }

            return new Polynomial(Math.Abs(lhs.Accuracy - rhs.Accuracy), result);
        }
        
        /// <summary>   Adds polynomials. </summary>
        /// <exception cref="ArgumentNullException">    Thrown when one or more required arguments are
        ///                                             null. </exception>
        /// <param name="lhs">      The left hand side. </param>
        /// <param name="number">   Number of. </param>
        /// <returns>   A computed polynomial with number. </returns>
        public static Polynomial Add(Polynomial lhs, double number)
        {
            if (lhs.coefficients == null)
            {
                throw new ArgumentNullException(nameof(lhs));
            }

            double[] array = new double[lhs.coefficients.Length + 1];
            lhs.coefficients.CopyTo(array, 0);

            array[0] += number;

            return new Polynomial(lhs.Accuracy, array);
        }

        /// <summary>   Multiplies of polynomials. </summary>
        /// <exception cref="ArgumentNullException">    Thrown when one or more required arguments are
        ///                                             null. </exception>
        /// <param name="lhs">  The left hand side. </param>
        /// <param name="rhs">  The right hand side. </param>
        /// <returns>   A computed result of multiplying a polynomial. </returns>
        public static Polynomial Multiply(Polynomial lhs, Polynomial rhs)
        {
            if (lhs.coefficients == null || rhs.coefficients == null)
            {
                throw new ArgumentNullException("Arguments cant be a null");
            }

            double[] result = new double[lhs.coefficients.Length + rhs.coefficients.Length];
            for (int i = 0; i < lhs.coefficients.Length; i++)
            {
                for (int j = 0; j < rhs.coefficients.Length; j++)
                {
                    result[i + j] += rhs.coefficients[i] * lhs.coefficients[j];
                }
            }

            return new Polynomial(Math.Abs(lhs.Accuracy - rhs.Accuracy), result);
        }
        
        /// <summary>   Multiplies of polynomials. </summary>
        /// <exception cref="ArgumentNullException">    Thrown when one or more required arguments are
        ///                                             null. </exception>
        /// <param name="lhs">      The left hand side. </param>
        /// <param name="number">   Number of. </param>
        /// <returns>   A computed result of multiplying a polynomial with number. </returns>
        public static Polynomial Multiply(Polynomial lhs, double number)
        {
            if (lhs.coefficients == null)
            {
                throw new ArgumentNullException(nameof(lhs));
            }

            double[] array = new double[lhs.coefficients.Length];
            for (int i = 0; i < lhs.coefficients.Length; i++)
            {
                array[i] = lhs.coefficients[i] * number;
            }

            return new Polynomial(lhs.Accuracy, array);
        }

        /// <summary>   Substracts. </summary>
        /// <exception cref="ArgumentNullException">    Thrown when one or more required arguments are
        ///                                             null. </exception>
        /// <param name="lhs">  The left hand side. </param>
        /// <param name="rhs">  The right hand side. </param>
        /// <returns>   A Polynomial. </returns>
        public static Polynomial Substract(Polynomial lhs, Polynomial rhs)
        {
            if (lhs.coefficients == null || rhs.coefficients == null)
            {
                throw new ArgumentNullException("Arguments cant be a null");
            }

            int maxLength = Math.Max(lhs.coefficients.Length, rhs.coefficients.Length);
            int minLength = Math.Min(lhs.coefficients.Length, rhs.coefficients.Length);
            double[] result = new double[maxLength];

            if (lhs.coefficients.Length == maxLength)
            {
                Array.Copy(lhs.coefficients, result, maxLength);
                for (int i = 0; i < minLength; i++)
                {
                    result[i] -= rhs.coefficients[i];
                }
            }
            else
            {
                Array.Copy(rhs.coefficients, result, maxLength);
                for (int i = 0; i < minLength; i++)
                {
                    result[i] -= lhs.coefficients[i];
                }
            }

            return new Polynomial(Math.Abs(lhs.Accuracy - rhs.Accuracy), result);
        }

        /// <summary>   Query if 'lhs' is equals. </summary>
        /// <param name="lhs">  The left hand side. </param>
        /// <param name="rhs">  The right hand side. </param>
        /// <returns>   True if equals, false if not. </returns>
        public static bool IsEquals(Polynomial lhs, Polynomial rhs)
        {
            if (lhs.coefficients.Length != rhs.coefficients.Length)
            {
                return false;
            }

            for (int i = 0; i < lhs.coefficients.Length; i++)
            {
                if (lhs.coefficients[i] != rhs.coefficients[i])
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>   Determines whether the specified object is equal to the current object. </summary>
        /// <param name="rhs">  The right hand side. </param>
        /// <returns>
        /// <see langword="true" /> if the specified object  is equal to the current object; otherwise,
        /// <see langword="false" />.
        /// </returns>
        public override bool Equals(object rhs)
        {
            Polynomial polinomial = rhs as Polynomial;

            if (polinomial.coefficients.Length != coefficients.Length)
            {
                return false;
            }

            for (int i = 0; i < polinomial.coefficients.Length; i++)
            {
                if (polinomial.coefficients[i] != coefficients[i])
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>   Returns a string that represents the current object. </summary>
        /// <returns>   A string that represents the current object. </returns>
        public override string ToString()
        {
            return string.Concat(coefficients);
        }

        /// <summary>   Serves as the default hash function. </summary>
        /// <returns>   A hash code for the current object. </returns>
        public override int GetHashCode()
        {
            int hashCode = 0;
            for (int i = 0; i < this.coefficients.Length; i++)
            {
                hashCode += (int)Math.Pow(coefficients[i], i);
            }

            return hashCode;
        }
        #endregion
    }
}
