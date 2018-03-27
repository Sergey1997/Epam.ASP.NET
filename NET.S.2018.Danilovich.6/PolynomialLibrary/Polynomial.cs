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
    public sealed class Polynomial
    {
        #region Fields

        /// <summary>   
        /// The coefficients of polinomial. 
        /// </summary>
        private double[] coeffitients = { };

        #endregion

        #region Constructors
        /// <summary>   Constructor  of polinomial. </summary>
        /// <param name="accuracy"> The accuracy for right equal. </param>
        /// <param name="array">    A variable-length parameters list containing coeffitients of polynomial. </param>
        public Polynomial(params double[] array)
        {
            coeffitients = new double[array.Length];
            Array.Copy(array, coeffitients, coeffitients.Length);
        }
        
        #endregion

        /// <summary>   Gets the accuracy. </summary>
        /// <value> The accuracy. </value>
        public double Accuracy { get; } = 0.0001;
        
        /// <summary>
        /// Indexer to get or set items within this collection using array index syntax.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">  Thrown when one or more arguments are outside
        ///                                                 the required range. </exception>
        /// <param name="degree">   The degree. </param>
        /// <returns>   The indexed item. </returns>
        public double this[int degree]
        {
            get
            {
                if (degree > coeffitients.Length)
                {
                    throw new ArgumentOutOfRangeException($"{nameof(degree)} cant be more then max length of polinom");
                }

                return coeffitients[degree];
            }

            private set
            {
                if (degree >= 0 || degree < coeffitients.Length)
                {
                    coeffitients[degree] = value;
                }

                throw new ArgumentOutOfRangeException($"{nameof(degree)} cant be more then max length of polinom and less then zero");
            }
        }

        #region Overloadings

        /// <summary>   Subtraction operator. </summary>
        /// <param name="lhs">  The left hand side. </param>
        /// <param name="rhs">  The right hand side. </param>
        /// <returns>   The result of the operation. </returns>
        public static Polynomial operator -(Polynomial lhs, Polynomial rhs)
        {
            return Add(lhs, rhs);
        }

        public static Polynomial operator -(Polynomial lhs, double number)
        {
            return Add(lhs, -number);
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
        
        /// <summary>   Equality operator. </summary>
        /// <param name="lhs">  The left hand side. </param>
        /// <param name="rhs">  The right hand side. </param>
        /// <returns>   The result of the operation. </returns>
        public static bool operator ==(Polynomial lhs, Polynomial rhs)
        {
            if (ReferenceEquals(lhs, rhs))
            {
                return true;
            }

            if (lhs is null)
            {
                return false;
            }

            return lhs.Equals(rhs);
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
            if (lhs.coeffitients == null || rhs.coeffitients == null)
            {
                throw new ArgumentNullException("Arguments cant be a null");
            }

            int maxLength = Math.Max(lhs.coeffitients.Length, rhs.coeffitients.Length);
            int minLength = Math.Min(lhs.coeffitients.Length, rhs.coeffitients.Length);
            double[] result = new double[maxLength];

            if (lhs.coeffitients.Length == maxLength)
            {
                Array.Copy(lhs.coeffitients, result, maxLength);
                for (int i = 0; i < minLength; i++)
                {
                    result[i] += rhs.coeffitients[i];
                }
            }
            else
            {
                Array.Copy(rhs.coeffitients, result, maxLength);
                for (int i = 0; i < minLength; i++)
                {
                    result[i] += lhs.coeffitients[i];
                }
            }

            return new Polynomial(result);
        }

        /// <summary>   Adds polynomials. </summary>
        /// <exception cref="ArgumentNullException">    Thrown when one or more required arguments are
        ///                                             null. </exception>
        /// <param name="lhs">      The left hand side. </param>
        /// <param name="number">   Number of. </param>
        /// <returns>   A computed polynomial with number. </returns>
        public static Polynomial Add(Polynomial lhs, double number)
        {
            if (lhs.coeffitients == null)
            {
                throw new ArgumentNullException(nameof(lhs));
            }

            double[] array = new double[lhs.coeffitients.Length + 1];
            lhs.coeffitients.CopyTo(array, 0);

            array[0] += number;

            return new Polynomial(array);
        }

        /// <summary>   Multiplies of polynomials. </summary>
        /// <exception cref="ArgumentNullException">    Thrown when one or more required arguments are
        ///                                             null. </exception>
        /// <param name="lhs">  The left hand side. </param>
        /// <param name="rhs">  The right hand side. </param>
        /// <returns>   A computed result of multiplying a polynomial. </returns>
        public static Polynomial Multiply(Polynomial lhs, Polynomial rhs)
        {
            if (lhs.coeffitients == null || rhs.coeffitients == null)
            {
                throw new ArgumentNullException("Arguments cant be a null");
            }

            double[] result = new double[lhs.coeffitients.Length + rhs.coeffitients.Length - 1];
            for (int i = 0; i < lhs.coeffitients.Length; i++)
            {
                for (int j = 0; j < rhs.coeffitients.Length; j++)
                {
                    result[i + j] += rhs.coeffitients[i] * lhs.coeffitients[j];
                }
            }

            return new Polynomial(result);
        }
        
        /// <summary>   Multiplies of polynomials. </summary>
        /// <exception cref="ArgumentNullException">    Thrown when one or more required arguments are
        ///                                             null. </exception>
        /// <param name="lhs">      The left hand side. </param>
        /// <param name="number">   Number of. </param>
        /// <returns>   A computed result of multiplying a polynomial with number. </returns>
        public static Polynomial Multiply(Polynomial lhs, double number)
        {
            if (lhs.coeffitients == null)
            {
                throw new ArgumentNullException(nameof(lhs));
            }

            double[] array = new double[lhs.coeffitients.Length];
            for (int i = 0; i < lhs.coeffitients.Length; i++)
            {
                array[i] = lhs.coeffitients[i] * number;
            }

            return new Polynomial(array);
        }

        /// <summary>   Substracts. </summary>
        /// <exception cref="ArgumentNullException">    Thrown when one or more required arguments are
        ///                                             null. </exception>
        /// <param name="lhs">  The left hand side. </param>
        /// <param name="rhs">  The right hand side. </param>
        /// <returns>   A Polynomial. </returns>
        public static Polynomial Substract(Polynomial lhs, Polynomial rhs)
        {
            if (lhs.coeffitients == null || rhs.coeffitients == null)
            {
                throw new ArgumentNullException("Arguments cant be a null");
            }

            int maxLength = Math.Max(lhs.coeffitients.Length, rhs.coeffitients.Length);
            int minLength = Math.Min(lhs.coeffitients.Length, rhs.coeffitients.Length);
            double[] result = new double[maxLength];

            if (lhs.coeffitients.Length == maxLength)
            {
                Array.Copy(lhs.coeffitients, result, maxLength);
                for (int i = 0; i < minLength; i++)
                {
                    result[i] -= rhs.coeffitients[i];
                }
            }
            else
            {
                Array.Copy(rhs.coeffitients, result, maxLength);
                for (int i = 0; i < minLength; i++)
                {
                    result[i] -= lhs.coeffitients[i];
                }
            }

            return new Polynomial(result);
        }

        /// <summary>   Query if 'lhs' is equals. </summary>
        /// <param name="lhs">  The left hand side. </param>
        /// <param name="rhs">  The right hand side. </param>
        /// <returns>   True if equals, false if not. </returns>
        public static bool IsEquals(Polynomial lhs, Polynomial rhs)
        {
            if (lhs.coeffitients.Length != rhs.coeffitients.Length)
            {
                return false;
            }

            for (int i = 0; i < lhs.coeffitients.Length; i++)
            {
                if (lhs.coeffitients[i] != rhs.coeffitients[i])
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
        public bool Equals(Polynomial other)
        {
            if (other is null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }
            
            if (this.coeffitients.Length != other.coeffitients.Length)
            {
                return false;
            }

            for (int i = 0; i < this.coeffitients.Length; i++)
            {
                if (other.coeffitients[i] != coeffitients[i])
                {
                    return false;
                }
            }

            return true;
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            return this.Equals((Polynomial)obj);
        }

        /// <summary>   Returns a string that represents the current object. </summary>
        /// <returns>   A string that represents the current object. </returns>
        public override string ToString()
        {
            return string.Concat(coeffitients);
        }

        /// <summary>   Serves as the default hash function. </summary>
        /// <returns>   A hash code for the current object. </returns>
        public override int GetHashCode()
        {
            int hashCode = 0;
            for (int i = 0; i < this.coeffitients.Length; i++)
            {
                hashCode += (int)Math.Pow(coeffitients[i], i);
            }

            return hashCode;
        }
        #endregion
    }
}
