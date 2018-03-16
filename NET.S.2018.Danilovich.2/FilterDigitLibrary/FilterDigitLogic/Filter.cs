////////////////////////////////////////////////////////////////////////////////////////////////////
// file: Filter.cs
//
// summary: Implements the filter class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>A filter.</summary>
    /// 
    /// <remarks>Sergey, 16.03.2018.</remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public static class Filter
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Filter digit.</summary>
        ///
        /// <remarks>Sergey, 16.03.2018.</remarks>
        ///
        /// <exception cref="ArgumentNullException">    Thrown when one or more required arguments are
        ///                                             null. </exception>
        /// <exception cref="ArgumentException">        Thrown when one or more arguments have
        ///                                             unsupported or illegal values. </exception>
        ///
        /// <param name="array">    [in,out] The array. </param>
        /// <param name="digit">    The digit. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static void FilterDigit(ref int[] array, int digit)
        {
            if (array == null)
            {
                throw new ArgumentNullException();
            }

            if ((digit < 0) || (digit > 9))
            {
                throw new ArgumentException();
            }

            List<int> result = new List<int>();

            for (int i = 0; i < array.Length; i++)
            {
                if (IsContain(array[i], digit) == true)
                {
                    result.Add(array[i]);
                }
            }

            array = result.ToArray();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Query if 'element' is contain.</summary>
        ///
        /// <remarks>Sergey, 16.03.2018.</remarks>
        ///
        /// <param name="element">  The element. </param>
        /// <param name="digit">    The digit. </param>
        ///
        /// <returns>   True if contain, false if not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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
    }
}
