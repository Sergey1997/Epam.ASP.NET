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
            int result = firstNumber;

            for (int k = i; k <= j; k++)
            {
                int inMask = (1 << (k - i));
                int sourceMask = (1 << k);

                if ((secondNumber & inMask) != 0)
                {
                    result = result | sourceMask;
                }
                else
                {
                    if ((firstNumber & sourceMask) != 0)
                    {
                        result ^= sourceMask;
                    }
                }
            }

            return result;
        }
    }
}