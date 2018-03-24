using System.Collections.Generic;

namespace SortingLibrary
{
    public static class Sorting
    {
        public static IStrategy Strategy { get; set; }
        
        public static void Sort(int[][] array)
        {
            int?[] result = new int?[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                result[i] = Strategy.Algorithm(array[i]);
            }

            BubbleSorting(result, array);
        }

        private static void BubbleSorting(int?[] array, int[][] jaggedArray)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - 1 - i; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        Swap(ref array[j], ref array[j + 1]);
                        Swap(ref jaggedArray[j], ref jaggedArray[j + 1]);
                    }
                }
            }
        }

        private static void Swap(ref int? lhs, ref int? rhs)
        {
            int? temp = lhs;
            lhs = rhs;
            rhs = temp;
        }

        private static void Swap(ref int[] lhs, ref int[] rhs)
        {
            int[] temp = lhs;
            lhs = rhs;
            rhs = temp;
        }
    }
}
