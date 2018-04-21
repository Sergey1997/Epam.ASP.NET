using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLogic
{
    public class Calculater<T> : IMatrixVisitor<T>
    {
        private Matrix<T> temp;

        public Calculater(Matrix<T> other)
        {
            temp = other;
        }

        public SquareMatrix<T> Visit(SquareMatrix<T> matrix)
        {
            return Add(matrix);
        }

        public SquareMatrix<T> Visit(SymmetricMatrix<T> matrix)
        {
            return Add(matrix);
        }

        public SquareMatrix<T> Visit(DiagonalMatrix<T> matrix)
        {
            return Add(matrix);
        }

        private SquareMatrix<T> Add(SquareMatrix<T> matrix)
        {
            for (int i = 0; i < matrix.Size; i++)
            {
                for (int j = 0; j < matrix.Size; j++)
                {
                    matrix[i, j] += (dynamic)temp[i, j];
                }
            }

            return matrix;
        }
    }
}
