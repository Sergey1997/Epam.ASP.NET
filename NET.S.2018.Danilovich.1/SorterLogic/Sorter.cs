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
        
        public static void MergeSort(this int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException();
            }

            MergeSort(array, 0, array.Length);
        }
        public static void MergeSort(this int[] array, int start, int end)
        {
            int N = end - start;
            if (N <= 1)
                return;

            int mid = start + N / 2;

            MergeSort(array, start, mid);
            MergeSort(array, mid, end);

            int[] temp = new int[N];
            int i = start, j = mid;
            for (int k = 0; k < N; k++)
            {
                if (i == mid) temp[k] = array[j++];
                else if (j == end) temp[k] = array[i++];
                else if (array[j].CompareTo(array[i]) < 0) temp[k] = array[j++];
                else temp[k] = array[i++];
            }

            for (int k = 0; k < N; k++)
            {
                array[start + k] = temp[k];
            }
        }
    }
}