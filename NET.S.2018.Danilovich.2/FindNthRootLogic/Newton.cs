using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindNthRootLogic
{
    public static class Newton
    {
        public static double FindNthRoot(double number,int degree,double precision)
        {
            if(degree < 0 || precision < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(degree));
            }

            double formatDegree = (double)degree;
            double firstPosition = number / (formatDegree);
            double finalPosition = Step(number, formatDegree, firstPosition);

            while (Math.Abs(finalPosition - firstPosition) > precision)
            {
                firstPosition = finalPosition;
                finalPosition = Step(number, formatDegree, firstPosition);
            }

            string str = precision.ToString();

            return Math.Round(finalPosition, str.Length-2);
        }
        private static double Step(double number,double formatDegree,double firstPosition)
        {
            return (1 / formatDegree) * ((formatDegree - 1) * firstPosition + number / Math.Pow(firstPosition, (formatDegree - 1)));
        }
    }
}
