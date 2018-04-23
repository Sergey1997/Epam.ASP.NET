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
        public double Accuracy { get; set; }
        public Comparator(double accuracy)
        {
            Accuracy = accuracy;
        }

        public int Compare(object x, object y)
        {
            if (Math.Abs((double)x) - Math.Abs((double)y) < Accuracy)
            {
                return 0;
            }
            return 1;
        }
    }
}
