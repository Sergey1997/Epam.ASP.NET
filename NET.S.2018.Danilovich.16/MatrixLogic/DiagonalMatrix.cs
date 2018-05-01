using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLogic
{
    public class DiagonalMatrix<T> : SquareMatrix<T>
    {
        public T[] DiagonalArray;
        public DiagonalMatrix(int size)
        {
            if (size < 1)
            {
                throw new ArgumentOutOfRangeException($"{(nameof(size))} must not be less than one");
            }

            this.Size = size;
            this.DiagonalArray = new T[size];
        }

        public DiagonalMatrix(T[] array)
        {
            if (array is null)
            {
                throw new ArgumentNullException();
            }
            
            this.DiagonalArray = new T[array.GetLength(0)];
            this.Size = array.GetLength(0);
            Array.Copy(array, this.DiagonalArray, array.Length);
        }

        public override T this[int i, int j]
        {
            get => this.DiagonalArray[i];
            set
            {
                if (i > this.Size || i < 0)
                {
                    throw new ArgumentOutOfRangeException("Indexes doesnt correct");
                }
                this.DiagonalArray[i] = value;
            }
        }
    }
}
