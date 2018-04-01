using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilterDigitLogic
{
    class DigitLogic
    {
        private int digit;
        public int Digit
        {
            get
            {
                return digit;
            }
            set
            {
                if (value < 0 || value > 9)
                {
                    throw new ArgumentOutOfRangeException(nameof(digit));
                }

                digit = value;
            }
        }
        public DigitLogic(int digit)
        {
            this.digit = digit;
        }
    }
}
