using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace SortingLibrary
{
    public static class Sorting
    {
        /// <summary>
        /// Sorting jagged array by delegate
        /// </summary>
        /// <param name="jaggedArray"> an array int[][] </param>
        /// <param name="comparerDelegate"> Func<int[], int[], int> </param>
        public static void SortForDelegate(int[][] array, Func<int[], int[], int> comparerDelegate)
        {
            DataValidation(array, comparerDelegate);

            IComparer<int[]> comparer = new Adapter(comparerDelegate);

            BubbleSorting(array, comparer);
        }

        /// <summary>
        /// Sorting jagged array by delegate
        /// </summary>
        /// <param name="jaggedArray"> an array int[][] </param>
        /// <param name="comparer"> IComparer<int[]> </param>
        public static void SortForIterface(int[][] array, IComparer<int[]> comparer)
        {
            DataValidation(array, comparer);
            Func<int[], int[], int> comparerDelegate = comparer.Compare;

            BubbleSorting(array, comparerDelegate);
        }
        
        /// <summary>   Bubble sorting for int[][] array by using a IComparer. </summary>
        /// <param name="array">                The array for sorting. </param>
        private static void BubbleSorting(int[][] array, IComparer<int[]> comparer)
        {
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

        /// <summary>   Bubble sorting for int[][] array by using a Delegate. </summary>
        /// <param name="array">                The array for sorting. </param>
        private static void BubbleSorting(int[][] array, Func<int[], int[], int> comparerDelegate)
        {
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

        /// <summary>
        /// Validation of data jagged array
        /// </summary>
        /// <param name="array">an array int[][]</param>
        /// <param name="comparerDelegate">delegate Func<int[], int[], int></param>
        private static void DataValidation(int[][] array, Func<int[], int[], int> comparerDelegate)
        {
            if (array == null)
            {
                throw new ArgumentNullException($"{(nameof(array))} cant be a null)");
            }

            if (comparerDelegate == null)
            {
                throw new ArgumentNullException($"{(nameof(comparerDelegate))} cant be a null)");
            }
        }

        /// <summary>
        /// Validation of data jagged array
        /// </summary>
        /// <param name="array">an array int[][]</param>
        /// <param name="comparerDelegate">Interface IComparer</param>
        private static void DataValidation(int[][] array, IComparer<int[]> comparer)
        {
            if (array == null)
            {
                throw new ArgumentNullException($"{(nameof(array))} cant be a null)");
            }

            if (comparer == null)
            {
                throw new ArgumentNullException($"{(nameof(comparer))} cant be a null)");
            }
        }
    }
}
