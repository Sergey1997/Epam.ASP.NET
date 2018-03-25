using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingLibrary
{
    public class MinOfArray : IStrategy
    {
        /// <summary>   Algorithm for array strategy - MinOfArray which get min number in array . </summary>
        /// <param name="array">    The array. </param>
        /// <returns>   An min int? number. </returns>
        public int? Algorithm(int[] array)
        {
            if (array is null)
            {
                return null;
            }

            int minOfArray = array[0];
            for (int i = 0; i < array.Length; i++)
            {
                if (minOfArray > array[i])
                {
                    minOfArray = array[i];
                }
            }

            return minOfArray;
        }
    }
}
