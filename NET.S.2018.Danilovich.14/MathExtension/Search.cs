﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathExtension
{
    public static class Search 
    {
        public static int BinarySearch<T>(this T[] array, T item, Comparison<T> comparison)
        {
            Array.Sort(array, comparison);
            return BinarySearch(array, item, comparison);
        }
        public static int BinarySearch<T>(this T[] array, T item, IComparer<T> comparer)
        {
            Array.Sort(array, comparer);
            return BinarySearch(array, item, 0, array.Length, comparer);
        }
        /// <summary>
        /// Binary search with default comparer of type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array">array</param>
        /// <param name="value">value for finding</param>
        /// <returns></returns>
        public static int BinarySearch<T>(this T[] array, T value)
        {           
            Array.Sort(array, Comparer<T>.Default);
            return BinarySearch(array, value, 0, array.Length, Comparer<T>.Default);
        }

        /// <summary>
        /// Binary search 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">array of elements</param>
        /// <param name="value">value for finding</param>
        /// <param name="comparer">comparer</param>
        /// <returns></returns>
        private static int BinarySearch<T>(T[] list, T value, int left, int right, IComparer<T> comparer)
        {
            DataValidation(list, value, comparer);

            comparer = comparer ?? Comparer<T>.Default;

            int start = left;
            int end = right;
            while (start < end)
            {
                int mid = start + ((end - start) / 2);
                int result = comparer.Compare(list[mid], value);
                if (result == 0)
                {
                    return mid;
                }

                if (result < 0)
                {
                    start = mid + 1;
                }
                else
                {
                    end = mid - 1;
                }
            }

            return -1;
        }

        /// <summary>
        /// Validation of arguments
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">array</param>
        /// <param name="value">value</param>
        /// <param name="comparer">comparer</param>
        private static void DataValidation<T>(T[] list, T value, IComparer<T> comparer)
        {
            if (list.Length == 0)
            {
                throw new ArgumentException($"{(list.Length)} cant be a zero");
            }

            if (value == null)
            {
                throw new ArgumentNullException($"{(value)} cant be a null");
            }

            if (comparer == null)
            {
                throw new ArgumentNullException($"{(comparer)} cant be a null");
            }
        }
    }
}
