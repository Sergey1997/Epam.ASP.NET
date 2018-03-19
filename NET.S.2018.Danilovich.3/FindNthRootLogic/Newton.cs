using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindNthRootLogic
{
    public static class Newton
    {
        public static double FindNthRoot(double number, int degree, double precision)
        {
            if (degree < 0 || precision < 0 || (number < 0 && degree % 2 == 0))
            {
                throw new ArgumentOutOfRangeException(nameof(degree));
            }

            double firstPosition = number / degree;
            double finalPosition = Step(number, degree, firstPosition);

            while (Math.Abs(finalPosition - firstPosition) > precision)
            {
                firstPosition = finalPosition;
                finalPosition = Step(number, degree, firstPosition);
            }
            
            return finalPosition;
        }

        private static double Step(double number, double degree, double firstPosition)
        {
            return 1.0 / degree * (((degree - 1) * firstPosition) + (number / Math.Pow(firstPosition, degree - 1)));
        }
    }
}
