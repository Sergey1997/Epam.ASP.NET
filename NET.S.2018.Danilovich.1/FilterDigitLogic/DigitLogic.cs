using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilterDigitLogic
{
    public class SameDigit : IPredicate
    {
        public int Digit { get; set; }

        public SameDigit(int digit)
        {
            Digit = digit;
        }

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
    public class LessThan : IPredicate
    {
        public int Digit { get; set; }

        public LessThan(int digit)
        {
            Digit = digit;
        }

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
