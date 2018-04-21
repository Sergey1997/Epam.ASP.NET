using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLogic
{
    public static class MatrixExtension
    {
        public static Matrix<T> Sum<T>(this Matrix<T> matrix, Matrix<T> other)
        {
            if (other is null)
            {
                throw new ArgumentNullException();
            }

            var visitor = new Calculater<T>(other);
            matrix.Accept(visitor);

            return matrix;
        }
    }
}
