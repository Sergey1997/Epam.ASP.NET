using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLogic
{
    public class SquareMatrix<T> : Matrix<T>
    {
        public SquareMatrix()
        {
            this.Size = 1;
            this.matrix = new T[this.Size, this.Size];
        }

        public SquareMatrix(int size)
        {
            if (size < 1)
            {
                throw new ArgumentOutOfRangeException($"{(nameof(size))} must not be less than one");
            }

            this.Size = size;
            this.matrix = new T[size, size];
        }

        public SquareMatrix(T[,] array)
        {
            if (array is null)
            {
                throw new ArgumentNullException($"{(nameof(array))} is null");
            }

            this.matrix = new T[array.GetLength(0), array.GetLength(0)];
            this.Size = array.GetLength(0);
            Array.Copy(array, this.matrix, array.Length);
        }

        public int Size { get; set; }

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
            }
        }
    }
}