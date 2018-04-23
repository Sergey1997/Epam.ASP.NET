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
            double[] lhs = (double[])x;
            double[] rhs = (double[])y;
            for(int i = 0; i < lhs.Length; i++)
            {
                if(Math.Abs(lhs[i]) - Math.Abs(rhs[i]) < Accuracy)
                {
                    return -1;
                }
            }

            return 1;
        }
    }
}
