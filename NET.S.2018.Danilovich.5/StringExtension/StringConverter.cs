using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringExtension
{
    public static class StringConverter
    {
        /// <summary>   A string extension method that converters to baseSystem. </summary>
        /// <exception cref="ArgumentOutOfRangeException">  Thrown when one or more arguments are outside
        ///                                                 the required range. </exception>
        /// <param name="inputString">  The inputString to act on. </param>
        /// <param name="baseSystem">   The base system. </param>
        /// <returns>   An int. </returns>

        public static int Converter(this string inputString, int baseSystem)
        {
            inputString = inputString.ToUpper();
            if (baseSystem < 2 || baseSystem > 16)
            {
                throw new ArgumentOutOfRangeException($"{ nameof(baseSystem) } must not be less then 2 and more then 16");
            }

            int res = 0;
            int j = 0;
            for (int i = inputString.Length - 1; i >= 0; i--)
            {
                if (inputString[i] >= 'A' && inputString[i] <= 'F')
                {
                    res += (int)((inputString[i] - 55) * Math.Pow(baseSystem, j));
                }
                else
                {
                    res += (int)((inputString[i] - '0') * Math.Pow(baseSystem, j));
                }

                j++;
            }

            return res;
        }
    }
}
