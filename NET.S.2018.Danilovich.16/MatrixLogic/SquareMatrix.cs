using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLogic
{
    public class SquareMatrix<T> : IEnumerable<T>
    {
        private T[,] Matrix { get; set; }

        public SquareMatrix()
        {
            this.Size = 1;
            this.Matrix = new T[this.Size, this.Size];
        }

        public SquareMatrix(int size)
        {
            if (size < 1)
            {
                throw new ArgumentOutOfRangeException($"{(nameof(size))} must not be less than one");
            }

            this.Size = size;
            this.Matrix = new T[size, size];
        }

        public SquareMatrix(T[,] array)
        {
            if (array is null)
            {
                throw new ArgumentNullException($"{(nameof(array))} is null");
            }

            this.Matrix = new T[array.GetLength(0), array.GetLength(0)];
            this.Size = array.GetLength(0);
            Array.Copy(array, this.Matrix, array.Length);
        }

        public int Size { get; set; }

        public virtual T this[int i, int j]
        {
            get => this.Matrix[i, j];
            set
            {
                if (i > this.Size || j > this.Size || i < 0 || j < 0)
                {
                    throw new ArgumentOutOfRangeException("Indexes doesnt correct");
                }

                this.Matrix[i, j] = value;
            }
        }

        public void Accept(IMatrixVisitor<T> visitor)
        {
            visitor.Visit((dynamic)this);
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in Matrix)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}