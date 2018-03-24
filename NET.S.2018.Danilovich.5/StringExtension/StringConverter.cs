using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringExtension
{
    public static class StringConverter
    {
        /// <summary>
        /// A string extension method that converts string representation  to a int number.
        /// </summary>
        /// <exception cref="ArgumentException">    Thrown when one or more arguments have unsupported or
        ///                                         illegal values. </exception>
        /// <param name="inputString">  The inputString to act on. </param>
        /// <param name="notation">     The notation. </param>
        /// <returns>   The given data converted to an int. </returns>
        public static int ToDecimalConverter(this string inputString, Notation notation)
        {
            if (inputString.Length == 0)
            {
                return 0;
            }

            inputString = inputString.ToUpper();

            int result = 0;
            int power = 0;

            for (int i = inputString.Length - 1; i >= 0; i--)
            {
                if (power == 0)
                {
                    power = 1;
                }
                else
                {
                    checked
                    {
                        power *= notation.BaseSystem;
                    }
                }

                char currentPosition = inputString[i];

                if (notation.AvailableChars.Contains(currentPosition))
                {
                    int digit = notation.AvailableChars.IndexOf(currentPosition);

                    checked
                    {
                        result += digit * power;
                    }
                }
                else
                {
                    throw new ArgumentException($"{nameof(currentPosition)} is not contained in available chars of notation");
                }
            }

            return result;
        }

        /// <summary>   
        /// Class for the notation of the number system.
        /// </summary>
        public class Notation
        {
            private const string PermissibleChars = "0123456789ABCDEF";
            private const int MinSystem = 2;
            private const int MaxSystem = 16;
            
            public Notation(int baseSystem)
            {
                if (baseSystem < MinSystem || baseSystem > MaxSystem)
                {
                    throw new ArgumentOutOfRangeException($"{nameof(baseSystem)} must be >= {MinSystem} and <= {MaxSystem}");
                }

                this.BaseSystem = baseSystem;

                AvailableChars = PermissibleChars.Substring(0, baseSystem);
            }

            public string AvailableChars { get; }

            public int BaseSystem { get; }
        }
    }
}
