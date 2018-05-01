using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLogic
{
    public static class MatrixExtension
    {
        public static SquareMatrix<T> Sum<T>(this SquareMatrix<T> matrix, SquareMatrix<T> other)
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
