using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace SortingLibrary
{
    /// <summary>
    /// Comparer delegate for arrays
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns>Result of compare</returns>
    public delegate int ComparerDelegate(int[] lhs, int[] rhs);

    public static class Sorting
    {
        /// <summary>
        /// Sorting jagged array by delegate
        /// </summary>
        /// <param name="jaggedArray"></param>
        /// <param name="comparerDelegate"></param>
        public static void Sort(int[][] array, ComparerDelegate comparerDelegate)
        {
            IComparer<int[]> comparer = (IComparer<int[]>)comparerDelegate.Target;
            BubbleSorting(array, comparer);
        }

        /// <summary>
        /// Sorting jagged array by delegate
        /// </summary>
        /// <param name="jaggedArray"></param>
        /// <param name="comparerDelegate"></param>
        public static void Sort(int[][] array, IComparer<int[]> comparer)
        {
            MethodInfo methodInfo = comparer.GetType().GetMethod("Compare");
            ComparerDelegate @delegate = (ComparerDelegate)Delegate.CreateDelegate(typeof(ComparerDelegate), null, methodInfo);

            BubbleSorting(array, @delegate);
        }
        
        /// <summary>   Bubble sorting for int[][] array by using a IStrategy. </summary>
        /// <param name="array">                The array for sorting. </param>
        private static void BubbleSorting(int[][] array, IComparer<int[]> comparer)
        {
            if (array == null)
            {
                throw new ArgumentNullException($"{(nameof(array))} cant be a null)");
            }

            if (comparer == null)
            {
                throw new ArgumentNullException($"{(nameof(comparer))} cant be a null)");
            }

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - 1 - i; j++)
                {
                    if (comparer.Compare(array[j], array[j + 1]) > 0)
                    {
                        Swap(ref array[j], ref array[j + 1]);
                    }
                }
            }
        }

        /// <summary>   Bubble sorting for int[][] array by using a IStrategy. </summary>
        /// <param name="array">                The array for sorting. </param>
        private static void BubbleSorting(int[][] array, ComparerDelegate comparerDelegate)
        {
            if (array == null)
            {
                throw new ArgumentNullException($"{(nameof(array))} cant be a null)");
            }

            if (comparerDelegate == null)
            {
                throw new ArgumentNullException($"{(nameof(comparerDelegate))} cant be a null)");
            }

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - 1 - i; j++)
                {
                    if (comparerDelegate.Invoke(array[j], array[j + 1]) > 0)
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
