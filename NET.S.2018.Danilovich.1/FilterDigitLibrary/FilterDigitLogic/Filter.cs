using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public static class Filter
    {
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
                    result.Add(result[i]);
                }
            }

            array = result.ToArray();
        }

        private static bool IsContain(int element, int digit)
        {
            string temp = element.ToString();
            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i].ToString().Equals(digit.ToString()))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
