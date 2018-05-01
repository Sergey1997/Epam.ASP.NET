using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLogic
{
    public class Calculater<T> : IMatrixVisitor<T>
    {
        private SquareMatrix<T> temp;

        public Calculater(SquareMatrix<T> other)
        {
            temp = other;
        }

        public SquareMatrix<T> Visit(SquareMatrix<T> Matrix)
        {
            for (int i = 0; i < Matrix.Size; i++)
            {
                for (int j = 0; j < Matrix.Size; j++)
                {
                    Matrix[i, j] += (dynamic)temp[i, j];
                }
            }

            return Matrix;
        }

        public SymmetricMatrix<T> Visit(SymmetricMatrix<T> Matrix)
        {
            for (int i = 0; i < Matrix.Size; i++)
            {
                for (int j = 0; j < i + 1; j++)
                {
                    Matrix[i, j] +=  (dynamic)temp[i, j];
                }
            }

            return Matrix;
        }

        public DiagonalMatrix<T> Visit(DiagonalMatrix<T> Matrix)
        {
            for (int i = 0; i < Matrix.Size; i++)
            {
                Matrix[i, 0] += (dynamic)temp[i, 0];
            }

            return Matrix;
        }
    }
}
