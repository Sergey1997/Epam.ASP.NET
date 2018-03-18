////////////////////////////////////////////////////////////////////////////////////////////////////
// file: Sorter.cs
//
// summary: Implements the sorter class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Linq;

namespace SorterLogic
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A sorter. </summary>
    ///
    /// <remarks>   Sergey, 16.03.2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public static class Sorter
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   An int[] extension method that quick sort. </summary>
        ///
        /// <remarks>   Sergey, 16.03.2018. </remarks>
        ///
        /// <exception cref="ArgumentNullException">    Thrown when one or more required arguments are
        ///                                             null. </exception>
        ///
        /// <param name="array">    The array to act on. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static void QuickSort(this int[] array)
        {
            try
            {
                QuickSort(array, 0, array.Length - 1);
            }
            catch (ArgumentNullException e)
            {
                throw e;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   An int[] extension method that quick sort. </summary>
        ///
        /// <remarks>   Sergey, 16.03.2018. </remarks>
        ///
        /// <exception cref="ArgumentOutOfRangeException">  Thrown when one or more arguments are outside
        ///                                                 the required range. </exception>
        /// <exception cref="ArgumentNullException">        Thrown when one or more required arguments
        ///                                                 are null. </exception>
        ///
        /// <param name="array">    The array to act on. </param>
        /// <param name="left">     The left. </param>
        /// <param name="right">    The right. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static void QuickSort(this int[] array, int left, int right)
        {
            if (left < 0 || right < 0 || right > array.Length || left > array.Length)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (array == null)
            {
                throw new ArgumentNullException();
            }
            
            int mid = array[left + ((right - left) / 2)];
            int temp = 0;
            int i = left;
            int j = right;

            while (i <= j)
            {
                while (array[i] < mid)
                {
                    i++;
                }

                while (array[j] > mid)
                {
                    j--;
                }

                if (i <= j)
                {
                    temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                    i++;
                    j--;
                }
            }

            if (i < right)
            {
                QuickSort(array, i, right);
            }

            if (left < j)
            {
                QuickSort(array, left, j);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   An int[] extension method that merge sort. </summary>
        ///
        /// <remarks>   Sergey, 16.03.2018. </remarks>
        ///
        /// <exception cref="ArgumentNullException">    Thrown when one or more required arguments are
        ///                                             null. </exception>
        ///
        /// <param name="array">    The array to act on. </param>
        ///
        /// <returns>   An int[]. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static int[] MergeSort(this int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException();
            }

            if (array.Length == 1)
            {
                return array;
            }

            int middle = array.Length / 2;
            return Merge(MergeSort(array.Take(middle).ToArray()), MergeSort(array.Skip(middle).ToArray()));
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Merges. </summary>
        ///
        /// <remarks>   Sergey, 16.03.2018. </remarks>
        ///
        /// <param name="arr1"> The first array. </param>
        /// <param name="arr2"> The second array. </param>
        ///
        /// <returns>   An int[]. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private static int[] Merge(int[] arr1, int[] arr2)
        {
            int a = 0, b = 0;
            int[] merged = new int[arr1.Length + arr2.Length];
            for (int i = 0; i < arr1.Length + arr2.Length; i++)
            {
                if ((b < arr2.Length) && (a < arr1.Length))
                {
                    if ((arr1[a] > arr2[b]) && (b < arr2.Length))
                    {
                        merged[i] = arr2[b++];
                    }
                    else
                    {
                        merged[i] = arr1[a++];
                    }
                }
                else
                {
                    if (b < arr2.Length)
                    {
                        merged[i] = arr2[b++];
                    }
                    else
                    {
                        merged[i] = arr1[a++];
                    }
                }
            }

            return merged;
        }
    }
}