using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolynomialLibrary
{
    public class Polynomial 
    {
        /// <summary>   The coefficients. </summary>
        private double[] coefficients;
        
        /// <summary>   Constructor. </summary>
        /// <exception cref="ArgumentNullException">        Thrown when one or more required arguments
        ///                                                 are null. </exception>
        /// <exception cref="ArgumentOutOfRangeException">  Thrown when one or more arguments are outside
        ///                                                 the required range. </exception>
        /// <param name="coefficients"> The coefficients of polinomial. </param>
        public Polynomial(double[] coefficients)
        {
            if (coefficients == null)
            {
                throw new ArgumentNullException(nameof(coefficients));
            }

            if (coefficients.Length <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(coefficients));
            }

            this.coefficients = coefficients;
        }
        
        /// <summary>   Gets the coefficients of polynomial. </summary>
        /// <value> The coefficients. </value>
        public double[] Coefficients
        {
            get
            {
                return this.coefficients;
            }
        }

        /// <summary>   Gets the degree of current polynomial. </summary>
        /// <value> The degree. </value>
        public int Degree
        {
            get
            {
                for (int i = Coefficients.Length - 1 ; i >= 0; i--)
                {
                    return i;
                }
                return -1;
            }
        }

        /// <summary>   Equality operator for polynomials. </summary>
        /// <param name="lhs">  The left hand side. </param>
        /// <param name="rhs">  The right hand side. </param>
        /// <returns>   The result of the operation - bool. </returns>
        public static bool operator ==(Polynomial lhs, Polynomial rhs)
        {
            if (lhs.Coefficients.Length != rhs.Coefficients.Length)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < lhs.Coefficients.Length; i++)
                {
                    if (lhs.Coefficients[i] != rhs.Coefficients[i])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
        
        /// <summary>   Inequality operator. </summary>
        /// <param name="lhs">  The left hand side. </param>
        /// <param name="rhs">  The right hand side. </param>
        /// <returns>   The result of the operation. </returns>
        public static bool operator !=(Polynomial lhs, Polynomial rhs)
        {
            return lhs == rhs ? false : true;
        }

        /// <summary>   Addition operator for two polynomials. </summary>
        /// <param name="lhs">  The left hand side. </param>
        /// <param name="rhs">  The right hand side. </param>
        /// <returns>   The result of the operation (New polynomial). </returns>
        public static Polynomial operator +(Polynomial lhs, Polynomial rhs)
        {
            double[] coeff = new double[lhs.Coefficients.Length >= rhs.Coefficients.Length ? lhs.Coefficients.Length : rhs.Coefficients.Length];

            for (int i = 0; i < coeff.Length; i++)
            {
                coeff[i] = lhs.Coefficients[i] + rhs.Coefficients[i];
            }

            return new Polynomial(coeff);
        }

        /// <summary>   Subtraction operator for two polynomials. </summary>
        /// <param name="lhs">  The left hand side. </param>
        /// <param name="rhs">  The right hand side. </param>
        /// <returns>   The result of the operation (New polynomial). </returns>
        public static Polynomial operator -(Polynomial lhs, Polynomial rhs)
        {
            double[] coeff = new double[lhs.Coefficients.Length >= rhs.Coefficients.Length ? lhs.Coefficients.Length : rhs.Coefficients.Length];

            for (int i = 0; i < coeff.Length; i++)
            {
                coeff[i] = lhs.Coefficients[i] - rhs.Coefficients[i];
            }

            return new Polynomial(coeff);
        }
        
        /// <summary>   Multiplication operator. </summary>
        /// <param name="lhs">  The left hand side. </param>
        /// <param name="rhs">  The right hand side. </param>
        ///
        /// <returns>   The result of the operation. </returns>
        public static Polynomial operator *(Polynomial lhs, Polynomial rhs)
        {
            double[] coeff = new double[lhs.Coefficients.Length >= rhs.Coefficients.Length ? lhs.Coefficients.Length : rhs.Coefficients.Length];

            for (int i = 0; i <= lhs.Coefficients.Length; i++)
            {
                for (int j = 0; j < rhs.Coefficients.Length; j++)
                {
                    coeff[i + j] = lhs.Coefficients[i] * rhs.Coefficients[i];
                }
            }

            return new Polynomial(coeff);
        }

        public static Polynomial operator /(Polynomial lhs, double dev)
        {
            if (dev == 0)
            {
                throw new ArgumentException(nameof(dev));
            }

            double[] coeff = new double[lhs.Coefficients.Length];
            
            for (int i = 0; i < coeff.Length; i++)
            {
                coeff[i] = lhs.Coefficients[i] / dev;
            }

            return new Polynomial(coeff);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Polynomial coeff = obj as Polynomial;
            if (coeff as Polynomial == null)
            {
                return false;
            }

            if (coeff.Coefficients.Length != this.Coefficients.Length)
            {
                return false;
            }
            
            for (int i = 0; i < coeff.Coefficients.Length; i++)
            {
                if (coeff.Coefficients[i] != this.Coefficients[i])
                {
                    return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            int hash = 0;
            for (int i = 0; i < Coefficients.Length; i++)
            {
                hash += (int)Math.Pow(Coefficients[i], i);
            }

            return hash;
        }

        public override string ToString()
        {
            string str = null;
            for (int i = 0; i < Coefficients.Length; i++)
            {
                str += Coefficients[i];
            }

            return str;
        }
    }
}
