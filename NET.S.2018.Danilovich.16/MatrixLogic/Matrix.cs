using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLogic
{
    public abstract class Matrix<T> : IEnumerable<T>, IEnumerable
    {
        protected T[,] matrix { get; set; }
        
        public abstract T this[int i, int j] { get; set; }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in matrix)
            {
                yield return item;
            }
        }

        public void Accept(IMatrixVisitor<T> visitor)
        {
            visitor.Visit((dynamic)this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
