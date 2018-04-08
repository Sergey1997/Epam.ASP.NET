using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingLibrary
{
    public class MaxOfArray : IComparer<int[]>
    {
        /// <summary>
        /// Implemented Compare of IComparer<int[]>
        /// </summary>
        /// <param name="lhs">left array</param>
        /// <param name="rhs">right array</param>
        /// <returns> A positive, negative or zero int</returns>
        public int Compare(int[] lhs, int[] rhs)
        {
            if (lhs == null)
            {
                return 1;
            }

            if (rhs == null)
            {
                return -1;
            }

            return lhs.Max() - rhs.Max();
        }
    }
}
