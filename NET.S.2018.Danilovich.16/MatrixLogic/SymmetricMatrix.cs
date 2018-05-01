using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLogic
{
    public class SymmetricMatrix<T> : SquareMatrix<T>
    {

        public T[][] Matrix { get; set; }
        public SymmetricMatrix(int size)
        {
            if (size < 1)
            {
                throw new ArgumentOutOfRangeException($"{(nameof(size))} must not be less than one");
            }

            this.Size = size;
            this.Matrix = new T[size][];

            for (int i = 0; i < size; i++)
            {
                Matrix[i] = new T[i + 1];
            }
        }

        public SymmetricMatrix(T[][] array)
        {
            if (array is null)
            {
                throw new ArgumentNullException($"{(nameof(array))} is null");
            }

            this.Matrix = new T[array.GetLength(0)][];
            this.Size = array.GetLength(0);

            for(int i = 0; i < this.Size; i++)
            {
                Matrix[i] = new T[i + 1];
            }

            for(int i = 0; i < Matrix.Length; i++)
            {
                for(int j = 0; j < this.Matrix[i].Length; j++)
                {
                    Matrix[i][j] = array[i][j];
                }
            }
        }

        public override T this[int i,int j]
        {
            get => this.Matrix[i][j];
            set
            {
                if (i > this.Size || j > this.Size || i < 0 || j < 0)
                {
                    throw new ArgumentOutOfRangeException("Indexes doesnt correct");
                }

                this.Matrix[i][j] = value;
            }
        }
    }
}
