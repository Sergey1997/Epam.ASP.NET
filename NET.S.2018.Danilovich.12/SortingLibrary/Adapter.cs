using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingLibrary
{

    public class Adapter : IComparer<int[]>
    {
        private Func<int[], int[], int> GetFunc;

        public Adapter(Func<int[], int[], int> func)
        {
            GetFunc = func;
        }

        public int Compare(int[] lhs, int[] rhs)
        {
            return GetFunc.Invoke(lhs, rhs);
        }
    }
}
