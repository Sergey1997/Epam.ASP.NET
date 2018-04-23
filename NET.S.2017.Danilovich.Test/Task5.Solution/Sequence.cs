using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5.Solution
{
    public static class Sequence<T>
    {
        public static IEnumerable<T> GenerateSequenceOfFibonacci(uint size)
        {
            if (size == 0)
            {
                throw new ArgumentException($"{ (nameof(size))} of array of sequence a zero");
            }

            return GenerateHelper();

            IEnumerable<T> GenerateHelper()
            {
                T[] array = new T[size];
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