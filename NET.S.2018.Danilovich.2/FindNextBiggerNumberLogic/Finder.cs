using System;
using System.Collections.Generic;

namespace FindNext
{
    public static class Finder
    {
        /// <summary>   
        /// Searches for the next bigger number. 
        /// if number doesn't exist returns -1
        /// </summary>
        /// <param name="number">   Number of. </param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when number less then zero</exception>
        /// <returns>   The found bigger number. </returns>
        public static int FindNextBiggerNumber(int number)
        {
            if (number < 0)
            {
                throw new ArgumentOutOfRangeException($"{ nameof(number) } should not be less then zero");
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
        /// Add number to List
        /// </summary>
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
        
        /// <summary>
        /// Extension method that swap main elements.
        /// </summary>
        /// <param name="list"> The list. </param>
        /// <param name="indexOfSwap">  The index of swap. </param>
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
        
        /// <summary>
        /// Extension method that sort tail.
        /// </summary>
        /// <param name="list">The list. </param>
        /// <param name="indexOfSwap">  The index of swap. Starting element. </param>
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
        
        /// <summary>
        /// List to int.
        /// </summary>
        /// <param name="list"> The list. </param>
        /// <returns>   An integer result of Bigger number. </returns>
        private static int ListToInt(List<int> list)
        {
            int nearestBiggerNumber = 0;
            for (int i = 0, rate = 1; i < list.Count; i++)
            {
                nearestBiggerNumber += list[i] * rate;
                rate *= 10;
            }

            return nearestBiggerNumber;
        }
    }
}
