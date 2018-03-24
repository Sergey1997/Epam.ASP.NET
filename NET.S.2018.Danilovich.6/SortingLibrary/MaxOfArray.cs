using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingLibrary
{
    public class MaxOfArray : IStrategy
    {
        public int? Algorithm(int[] array)
        {
            if (array is null)
            {
                return null;
            }

            int maxOfArray = array[0];
            for (int i = 0; i < array.Length; i++)
            {
                if (maxOfArray < array[i])
                {
                    maxOfArray = array[i];
                }
            }

            return maxOfArray;
        }
    }
}
