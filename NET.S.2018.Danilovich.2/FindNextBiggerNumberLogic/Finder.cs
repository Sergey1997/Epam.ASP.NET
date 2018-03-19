// file: Finder.cs
//
// summary: Implements the finder class

using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace FindNext
{
    /// <summary>A finder.</summary>
    ///
    /// <remarks>Sergey, 17.03.2018.</remarks>
    public static class Finder
    {
        /// <summary>   Searches for the next bigger number. </summary>
        ///
        /// <remarks>   Sergey, 17.03.2018. </remarks>
        ///
        /// <param name="number">   Number of. </param>
        ///
        /// <returns>   The found bigger number. </returns>
        public static int FindNextBiggerNumber(int number)
        {
            if (number < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(number));
            }

            List<int> digitElements = new List<int>();
            int startIndexOfSwap = 0;
            int nearestBiggerNumber = 0;
            digitElements.AddNumbersToList(number);
            digitElements.SwapMainElements(ref startIndexOfSwap);
            digitElements.Reverse();
            digitElements.SortTail(startIndexOfSwap);
            digitElements.Reverse();
            nearestBiggerNumber = ListToInt(digitElements);

            if (nearestBiggerNumber == number)
            {
                return -1;
            }

            return nearestBiggerNumber;
        }
        
        /// <summary>
        /// A List&lt;int&gt; extension method that adds the numbers to list to 'number'.
        /// </summary>
        ///
        /// <remarks>   Sergey, 17.03.2018. </remarks>
        ///
        /// <param name="list">     The list. </param>
        /// <param name="number">   Number of. </param>
        private static void AddNumbersToList(this List<int> list, int number)
        {
            while (number != 0)
            {
                list.Add(number % 10);
                number /= 10;
            }
        }
        
        /// <summary>A List&lt;int&gt; extension method that swap main elements.</summary>
        ///
        /// <remarks>Sergey, 17.03.2018.</remarks>
        ///
        /// <param name="list">         The list. </param>
        /// <param name="indexOfSwap">  [in,out] The index of swap. </param>
        private static void SwapMainElements(this List<int> list, ref int indexOfSwap)
        {
            for (int i = 0; i < list.Count - 1; i++)
            {
                if (list[i] > list[i + 1])
                {
                    int temp = list[i];
                    list[i] = list[i + 1];
                    list[i + 1] = temp;
                    indexOfSwap = i + 1;
                    break;
                }
            }
        }
        
        /// <summary>A List&lt;int&gt; extension method that sort tail.</summary>
        ///
        /// <remarks>Sergey, 17.03.2018.</remarks>
        ///
        /// <param name="list">         The list. </param>
        /// <param name="indexOfSwap">  The index of swap. </param>
        private static void SortTail(this List<int> list, int indexOfSwap)
        {
            for (int j = list.Count - indexOfSwap; j < list.Count; j++)
            {
                for (int k = j + 1; k < list.Count; k++)
                {
                    if (list[k] < list[j])
                    {
                        int temp = list[k];
                        list[k] = list[j];
                        list[j] = temp;
                    }
                }
            }
        }
        
        /// <summary>List to int.</summary>
        ///
        /// <remarks>Sergey, 17.03.2018.</remarks>
        ///
        /// <param name="list"> The list. </param>
        ///
        /// <returns>   An int. </returns>
        private static int ListToInt(List<int> list)
        {
            int nearestBiggerNumber = 0;
            for (int i = 0; i < list.Count; i++)
            {
                nearestBiggerNumber += list[i] * (int)Math.Pow(10, i);
            }

            return nearestBiggerNumber;
        }
    }
}
