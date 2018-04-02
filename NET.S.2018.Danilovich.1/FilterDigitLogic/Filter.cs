using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilterDigitLogic
{
    /// <summary>A filter.</summary>
    public static class Filter
    {
        /// <summary>Filter digit.</summary>
        /// <exception cref="ArgumentNullException">    Thrown when one or more required arguments are
        ///                                             null. </exception>
        /// <exception cref="ArgumentException">        Thrown when one or more arguments have
        ///                                             unsupported or illegal values. </exception>
        /// <param name="array">    [in,out] The array. </param>
        /// <param name="digit">    The digit. </param>
        public static int[] FilterDigit(this int[] array, IPredicate predicate, out long millisek)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int[] result = array.FilterDigit(predicate);
            stopwatch.Stop();
            millisek = stopwatch.ElapsedMilliseconds;
            return result;
        }
        
        /// <summary>   Filter digit . </summary>
        /// <param name="array">        The array. </param>
        /// <param name="predicate">    The predicate. </param>
        /// <returns>   An int[] filtered array by predicate . </returns>
        public static int[] FilterDigit(this int[] array, IPredicate predicate)
        {
            InputValidation(array, predicate);
            List<int> result = new List<int>();

            for (int i = 0; i < array.Length; i++)
            {
                if (predicate.IsSuitable(array[i]))
                {
                    result.Add(array[i]);
                }
            }

            return result.ToArray();
        }
        public static int[] TransformationArray(this int[] array, ITransformer transform)
        {
            List<int> result = new List<int>();

            for (int i = 0; i < array.Length; i++)
            {
                result.Add(transform.Transform(array[i]));
            }

            return result.ToArray();
        }
        
        /// <summary>Query if 'element' is contain.</summary>
        /// <param name="element">  The element. </param>
        /// <param name="digit">    The digit. </param>
        /// <returns>   True if contain, false if not. </returns>
        private static bool IsContain(int element, int digit)
        {
            if (element < 0)
            {
                element *= -1;
            }

            do
            {
                if (element % 10 == digit)
                {
                    return true;
                }

                element = element / 10;
            }
            while (element != 0);

            return false;
        }
        
        /// <summary>   A List&lt;int&gt; extension method that input validation. </summary>
        /// <exception cref="ArgumentNullException">        Thrown when one or more required arguments
        ///                                                 are null. </exception>
        /// <exception cref="ArgumentOutOfRangeException">  Thrown when one or more arguments are outside
        ///                                                 the required range. </exception>
        /// <param name="array">    The array. </param>
        /// <param name="digit">    The digit. </param>
        private static void InputValidation(this int[] array, IPredicate predicate)
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
