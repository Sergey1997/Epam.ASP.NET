using System;

namespace FindNthRootLogic
{
    public static class Newton
    {
        /// <summary>   
        /// Searches for the nth root of number. 
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">  Thrown when one or more arguments are outside
        ///                                                 the required range. </exception>
        /// <param name="number"> Number of. </param>
        /// <param name="degree"> The degree. </param>
        /// <param name="precision"> The precision. </param>
        /// <returns>   The found nth root. </returns>
        public static double FindNthRoot(double number, int degree, double precision)
        {
            ValidateException(number, degree, precision);
      
            double prev = number / degree;
            double next = Step(number, degree, prev);

            while (Math.Abs(next - prev) > precision)
            {
                prev = next;
                next = Step(number, degree, prev);
            }
            
            return next;
        }

        /// <summary>   
        /// Iteration. 
        /// </summary>
        /// <param name="number"> Number of. </param>
        /// <param name="degree"> The degree. </param>
        /// <param name="prev"> The first position. </param>
        /// <returns>   The following result after iteration. </returns>
        private static double Step(double number, int degree, double prev)
        {
            return 1.0 / degree * (((degree - 1) * prev) + (number / Math.Pow(prev, degree - 1)));
        }

        private static void ValidateException(double number, int degree, double precision)
        {
            if (degree < 0)
            {
                throw new ArgumentOutOfRangeException($" { nameof(degree) } must not be less then zero");
            }

            if (precision < 0 || precision > 1)
            {
                throw new ArgumentOutOfRangeException($" { nameof(precision) } less then zero or more then one");
            }

            if (number < 0 && degree % 2 == 0)
            {
                throw new ArgumentOutOfRangeException($" { nameof(number) } less then zero and {nameof(degree) } even");
            }
        }
    }
}
