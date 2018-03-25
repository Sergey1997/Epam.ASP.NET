using System.Collections.Generic;

namespace SortingLibrary
{
    public static class Sorting
    {
        /// <summary>   Gets or sets the strategy of sorting. </summary>
        /// <value> The strategy. </value>
        public static IStrategy Strategy { get; set; }
        
        /// <summary>   Sorts the given jagged array. </summary>
        /// <param name="array">    The array for sorting. </param>
        public static void Sort(int[][] array)
        {
            int?[] result = new int?[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                result[i] = Strategy.Algorithm(array[i]);
            }

            int countOfZeroElements = SwapNullElements(result, array);

            BubbleSorting(result, array, countOfZeroElements);
        }

        /// <summary>   Counts the number of permutations . </summary>
        /// <param name="result">   The array of strategies. </param>
        /// <param name="array">    The array for sorting. </param>
        /// <returns>   An int. </returns>
        private static int SwapNullElements(int?[] result, int[][] array)
        {
            int k = 0;
            for (int i = 0; i < result.Length; i++)
            {
                for (int j = 0; j < result.Length - 1 - i; j++)
                {
                    if (result[j] == null)
                    {
                        Swap(ref result[j], ref result[j + 1]);
                        Swap(ref array[j], ref array[j + 1]);
                        k++;
                    }
                }
            }

            return k;
        }
        
        /// <summary>   Bubble sorting. </summary>
        /// <param name="result">               The array of strategies. </param>
        /// <param name="array">                The array for sorting. </param>
        /// <param name="countOfZeroEleents">   The count of zero elements. </param>
        private static void BubbleSorting(int?[] result, int[][] array, int countOfZeroElements)
        {
            for (int i = 0; i < result.Length - countOfZeroElements; i++)
            {
                for (int j = 0; j < result.Length - 1 - i - countOfZeroElements; j++)
                {
                    if (result[j] > result[j + 1])
                    {
                        Swap(ref result[j], ref result[j + 1]);
                        Swap(ref array[j], ref array[j + 1]);
                    }
                }
            }
        }
        
        /// <summary>   Swaps lhs and rhs. </summary>
        /// <param name="lhs">  [in,out] The left hand side. </param>
        /// <param name="rhs">  [in,out] The right hand side. </param>
        private static void Swap(ref int? lhs, ref int? rhs)
        {
            int? temp = lhs;
            lhs = rhs;
            rhs = temp;
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
