using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertNumberLogic
{
    public static class Inserter
    {
        /// <summary>   
        /// Inserting firstNumber into second so that the second number occupies the position from bit j to bit i.
        /// </summary>
        /// <param name="firstNumber">  The first number. </param>
        /// <param name="secondNumber"> The second number. </param>
        /// <param name="i">            Zero-based index of the. </param>
        /// <param name="j">            An int to process. </param>
        /// <returns>   An int. </returns>
        public static int InsertNumber(int firstNumber, int secondNumber, int i, int j)
        {
            ValidateOfException(firstNumber, secondNumber, i, j);

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
        
        /// <summary>   
        /// Validates the of exception. 
        /// </summary>
        /// <exception cref="ArgumentException">
        /// Thrown when one or more arguments have unsupported or illegal values. 
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException"> 
        /// Thrown when one or more arguments are outside the required range. 
        /// </exception>
        /// <param name="firstNumber">  The first number. </param>
        /// <param name="secondNumber"> The second number. </param>
        /// <param name="i">            Zero-based index of the. </param>
        /// <param name="j">            An int to process. </param>
        private static void ValidateOfException(int firstNumber, int secondNumber, int i, int j)
        {
            if (i >= j)
            {
                throw new ArgumentException($"{ (nameof(i)) } more then  { (nameof(j)) } ");
            }

            if (i < 0 || j < 0)
            {
                throw new ArgumentOutOfRangeException($"{ (nameof(i)) } or { (nameof(j)) } less then zero ");
            }

            if (i > 31 || j > 31)
            {
                throw new ArgumentOutOfRangeException($"{ (nameof(i)) } or { (nameof(j)) } more then 31 ");
            }
        }
    }
}