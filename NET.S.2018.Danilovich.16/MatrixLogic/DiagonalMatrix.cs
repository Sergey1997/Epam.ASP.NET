using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLogic
{
    public class DiagonalMatrix<T> : SquareMatrix<T>
    {
        public DiagonalMatrix(int size) : base(size)
        {
        }

        public DiagonalMatrix(T[,] array)
        {
            if (array is null)
            {
                throw new ArgumentNullException();
            }

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(0); j++)
                {
                    if (i != j && !array[i, j].Equals(default(T)))
                    {
                        throw new ArgumentException($"{(nameof(array))} doesnt a diagonal matrix");
                    }
                }
            }

            this.matrix = new T[array.GetLength(0), array.GetLength(0)];
            this.Size = array.GetLength(0);
            Array.Copy(array, this.matrix, array.Length);
        }

        public override T this[int i, int j]
        {
            get => this.matrix[i, j];
            set
            {
                if (i > this.Size || j > this.Size || i < 0 || j < 0)
                {
                    throw new ArgumentOutOfRangeException("Indexes doesnt correct");
                }

                if (i == j)
                {
                    this.matrix[i, j] = value;
                }
                else
                {
                    this.matrix[i, j] = default(T);
                }
            }
        }
    }
}
