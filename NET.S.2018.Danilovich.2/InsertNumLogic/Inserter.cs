using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertNumLogic
{
    public static class Inserter
    {
        public static int InsertNumber(int firstNumber, int secondNumber, int i, int j)
        {
            if (i >= j || i < 0 || j < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            
            int result = firstNumber;

            for (int k = i; k <= j; k++)
            {
                int secondMask = 1 << (k - i);
                int firstMask = 1 << k;
                if ((secondNumber & secondMask) != 0)
                {
                    result = result | firstMask;
                }
                else
                {
                    if ((firstNumber & firstMask) != 0)
                    {
                        result ^= firstMask;
                    }
                }
            }

            return result;
        }
    }
}