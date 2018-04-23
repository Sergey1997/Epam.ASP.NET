using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test6.Solution
{
    public class Comparator : IComparer
    {

        public int Compare(object x, object y)
        {
            if (Math.Abs((double)x - (double)y) > 0.00001)
            {
                return 1;
            }
            return -1;
        }
    }
}
