using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilterDigitLogic
{
    public class PositivePow : ITransformer
    {
        public PositivePow(int degree)
        {
            Degree = degree;
        }

        public int Degree { get; set; }

        public int Transform(int number)
        {
            int result = number;

            if (Degree == 0)
            {
                return 1;
            }

            for (int i = 1; i < Degree; i++)
            {
                number *= result;
            }

            return number;
        }
    }
}
