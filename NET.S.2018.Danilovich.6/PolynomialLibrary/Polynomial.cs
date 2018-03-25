using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolynomialLibrary
{
    public class Polynomial 
    {
        private readonly double[] coefficients;

        public Polynomial(double[] coefficients)
        {
            this.coefficients = coefficients;
        }

        public double[] Coefficients
        {
            get
            {
                return coefficients;
            }
        }
        public static bool operator ==(Polynomial lhs, Polynomial rhs)
        {
            double lhsResult = lhs.Coefficients[0];
            double rhsResult = rhs.Coefficients[0];

            for(int i = 1; i < lhs.Coefficients.Length; i++)
            {
                lhsResult += Math.Pow(lhs.Coefficients[i], i);
            }
            for (int i = 1; i < rhs.Coefficients.Length; i++)
            {
                rhsResult += Math.Pow(rhs.Coefficients[i], i);
            }
            if (lhsResult == rhsResult)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator !=(Polynomial lhs, Polynomial rhs)
        {
            if(lhs == rhs)
            {
                return true;
            }
            else
            {
                return false;
            }
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
