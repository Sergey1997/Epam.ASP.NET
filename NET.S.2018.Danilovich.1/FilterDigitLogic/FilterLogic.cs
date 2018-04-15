using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilterDigitLogic
{
    /// <summary>A filter.</summary>
    public static class FilterLogic
    {
        /// <summary>Filter digit.</summary>
        /// <exception cref="ArgumentNullException">    Thrown when one or more required arguments are
        ///                                             null. </exception>
        /// <exception cref="ArgumentException">        Thrown when one or more arguments have
        ///                                             unsupported or illegal values. </exception>
        /// <param name="array">    [in,out] The array. </param>
        /// <param name="digit">    The digit. </param>
        public static T[] FilterDigit<T>(this T[] array, T value, Func<T, T, bool> predicate, out long millisek)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            T[] result = array.FilterDigit(value, predicate);
            stopwatch.Stop();
            millisek = stopwatch.ElapsedMilliseconds;
            return result;
        }
        
        /// <summary>   Filter digit . </summary>
        /// <param name="array">        The array. </param>
        /// <param name="predicate">    The predicate. </param>
        /// <returns>   An int[] filtered array by predicate . </returns>
        public static T[] FilterDigit<T>(this T[] array, T value, Func<T, T, bool> predicate)
        {
            InputValidation(array, predicate);
            List<T> result = new List<T>();

            for (int i = 0; i < array.Length; i++)
            {
                if (predicate.Invoke(arg1: array[i], arg2: value))
                {
                    result.Add(array[i]);
                }
            }

            return result.ToArray();
        }
        
        /// <summary>   A List&lt;int&gt; extension method that input validation. </summary>
        /// <exception cref="ArgumentNullException">        Thrown when one or more required arguments
        ///                                                 are null. </exception>
        /// <exception cref="ArgumentOutOfRangeException">  Thrown when one or more arguments are outside
        ///                                                 the required range. </exception>
        /// <param name="array">    The array. </param>
        /// <param name="digit">    The digit. </param>
        private static void InputValidation<T>(T[] array, Func<T, T, bool> predicate)
        {
            if (array == null)
            {
                throw new ArgumentNullException($"{(nameof(array))} must not be a null");
            }

            if (predicate == null)
            {
                throw new ArgumentNullException($"{(nameof(predicate))} must not be a null");
            }
        }
    }
}
