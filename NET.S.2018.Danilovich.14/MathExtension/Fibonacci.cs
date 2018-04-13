using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathExtension
{
    public static class Fibonacci
    {
        /// <summary>
        /// Generate of Fibonacci numbers in the array
        /// </summary>
        /// <param name="size">size of generated array</param>
        /// <returns></returns>
        public static ulong[] GenerateSequenceOfFibonacci(uint size)
        {
            ulong[] array = new ulong[size];

            if (size == 0)
            {
                return array;
            }

            array[0] = 1;
            array[1] = 1;

            for (int i = 2; i < size; i++)
            {
                checked
                {
                    array[i] = array[i - 1] + array[i - 2];
                }
            }

            return array;
        }
    }
}
