using System.Collections.Generic;

namespace SortingLibrary
{
    public static class Sorting
    {      
        /// <summary>   Bubble sorting for int[][] array by using a IStrategy. </summary>
        /// <param name="array">                The array for sorting. </param>
        public static void BubbleSorting(int[][] array, IStrategy strategy)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - 1 - i; j++)
                {
                    if (strategy.Algorithm(array[j]) > strategy.Algorithm(array[j + 1]) || strategy.Algorithm(array[j]) == null)
                    {
                        Swap(ref array[j], ref array[j + 1]);
                    }
                }
            }
        }
        
        /// <summary>   Swaps lhs and rhs overload for arrays. </summary>
        /// <param name="lhs">  [in,out] The left hand side. </param>
        /// <param name="rhs">  [in,out] The right hand side. </param>
        private static void Swap(ref int[] lhs, ref int[] rhs)
        {
            int[] temp = lhs;
            lhs = rhs;
            rhs = temp;
        }
    }
}
