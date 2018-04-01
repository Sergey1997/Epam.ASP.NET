using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilterDigitLogic
{
    /// <summary>   A class for finding same digit in number. </summary>
    public class SameDigit : IPredicate
    {
        public SameDigit(int digit)
        {
            Digit = digit;
        }

        public int Digit { get; set; }

        /// <summary>   Query if 'number' is suitable. </summary>
        /// <param name="number">   Number for checking. </param>
        /// <returns>   True if suitable, false if not. </returns>
        public bool IsSuitable(int number)
        {
            if (number < 0)
            {
                number = -number;
            }

            while (number != 0)
            {
                if (number % 10 == Digit)
                {
                    return true;
                }

                number /= 10;
            }

            return false;
        }
    }

    /// <summary>   Looks for numbers less than argument . </summary>
    public class LessThan : IPredicate
    {
        public LessThan(int digit)
        {
            Digit = digit;
        }

        public int Digit { get; set; }

        public bool IsSuitable(int number)
        {
            if (number < 0)
            {
                number = -number;
            }

            while (number != 0)
            {
                if (number % 10 < Digit)
                {
                    return true;
                }

                number /= 10;
            }

            return false;
        }
    }

    /// <summary>   looks for fn even numbers. </summary>
    public class EvenNumber : IPredicate
    {
        public bool IsSuitable(int number)
        {
            if (number % 2 == 0)
            {
                return true;
            }

            return false;
        }
    }
}
