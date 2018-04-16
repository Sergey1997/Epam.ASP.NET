using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathExtension
{
    public static class Search 
    {
        /// <summary>
        /// Reload of Binary search with IComparer<typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T">type</typeparam>
        /// <param name="array">array</param>
        /// <param name="item">item for finding</param>
        /// <param name="comparer">comparer</param>
        /// <returns>The value found</returns>
        public static int BinarySearch<T>(this T[] array, T item, IComparer<T> comparer) => BinarySearch(array, item, 0, array.Length, comparer.Compare);

        /// <summary>
        /// Reload of Binary search with IComparer<typeparamref name="T"/> 
        /// </summary>
        /// <typeparam name="T">T param</typeparam>
        /// <param name="array">inputing array</param>
        /// <param name="item">item for finding</param>
        /// <param name="left">left hand side</param>
        /// <param name="right">right hand side</param>
        /// <param name="comparer">comparer</param>
        /// <returns>The value found</returns>
        public static int BinarySearch<T>(this T[] array, T item, int left, int right, IComparer<T> comparer) => BinarySearch(array, item, left, right, comparer.Compare);

        /// <summary>
        /// Binary search with default comparer of type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array">array</param>
        /// <param name="value">value for finding</param>
        /// <returns>The value found</returns>
        public static int BinarySearch<T>(this T[] array, T value) => BinarySearch(array, value, 0, array.Length, Comparer<T>.Default.Compare);

        /// <summary>
        /// Reload of Binary search
        /// </summary>
        /// <typeparam name="T">T param</typeparam>
        /// <param name="array">inputing array</param>
        /// <param name="item">item for finding</param>
        /// <param name="left">left hand side</param>
        /// <param name="right">right hand side</param>
        /// <returns>The value found</returns>
        public static int BinarySearch<T>(this T[] array, T value, int left, int right) => BinarySearch(array, value, left, right, Comparer<T>.Default.Compare);

        /// <summary>
        /// Reload of Binary search with Comparison<typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T">T param</typeparam>
        /// <param name="array">inputing array</param>
        /// <param name="item">item for finding</param>
        /// <param name="comparison"></param>
        /// <returns>The value found</returns>
        public static int BinarySearch<T>(this T[] array, T item, Comparison<T> comparison) => BinarySearch(array, item, 0, array.Length, comparison);

        /// <summary>
        /// Binary search 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">array of elements</param>
        /// <param name="value">value for finding</param>
        /// <param name="comparer">comparer</param>
        /// <returns></returns>
        private static int BinarySearch<T>(T[] array, T value, int left, int right, Comparison<T> comparison)
        {
            DataValidation(array, value, comparison);

            Array.Sort(array, comparison);
            
            while (left <= right)
            {
                int mid = left + ((right - left) / 2);
                int result = comparison.Invoke(array[mid], value);
                if (result == 0)
                {
                    return mid;
                }

                if (result < 0)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
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
        private static void DataValidation<T>(T[] list, T value, Comparison<T> comparison)
        {
            if (list.Length == 0)
            {
                throw new ArgumentException($"{(list.Length)} cant be a zero");
            }

            if (value == null)
            {
                throw new ArgumentNullException($"{(value)} cant be a null");
            }

            if (comparison == null)
            {
                throw new ArgumentNullException($"{(comparison)} cant be a null");
            }
        }
    }
}
