using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilterDigitLogic
{
    /// <summary>   A class for finding same digit in number. </summary>
    public class Filter<T>
    {
        public static bool IsSuitable(T number, T value)
        {
            string str = number.ToString();
            int i = 0;
            do
            {
                if (str[i].ToString() == value.ToString())
                {
                    return true;
                }

                i++;
            }
            while (i < str.Length);

            return false;
        }
    }
}
