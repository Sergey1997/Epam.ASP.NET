using System;
using System.Collections.Generic;
using System.Numerics;

namespace MathExtension
{
    public static class Fibonacci
    {
        /// <summary>
        /// Generate of Fibonacci numbers in the array
        /// </summary>
        /// <param name="size">size of generated array</param>
        /// <returns></returns>
        public static IEnumerable<BigInteger> GenerateSequenceOfFibonacci(uint size)
        {
            if (size == 0)  
            {
                throw new ArgumentException($"{ (nameof(size))} of array of sequence a zero");
            }

            return GenerateHelper();

            IEnumerable<BigInteger> GenerateHelper()
            {
                BigInteger[] array = new BigInteger[size];
                yield return array[0] = 1;
                yield return array[1] = 1;

                for (int i = 2; i < size; i++)
                {
                    yield return array[i] = array[i - 1] + array[i - 2];
                }
            }
        }
    }
}
