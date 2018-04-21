using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLogic
{
    public class SymmetricMatrix<T> : SquareMatrix<T>
    {
        public SymmetricMatrix(int size) : base(size)
        {
        }

        public SymmetricMatrix(T[,] array)
        {
            if (array is null)
            {
                throw new ArgumentNullException($"{(nameof(array))} is null");
            }

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(0); j++)
                {
                    if (array[i, j] != (dynamic)array[j, i])
                    {
                        throw new ArgumentException($"{(nameof(array))} doesnt a symmetric matrix");
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

                this.matrix[i, j] = value;
                this.matrix[j, i] = value;
            }
        }
    }
}
