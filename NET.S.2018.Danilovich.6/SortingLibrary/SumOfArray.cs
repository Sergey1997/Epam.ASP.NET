using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingLibrary
{
    public class SumOfArray : IStrategy
    {
        public int? Algorithm(int[] array)
        {
            if (array is null)
            {
                return null;
            }

            int sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }
            return sum;
        }
    }
}
