using System;
using System.Linq.Expressions;

namespace MathExtension
{
    public class GreatestCommonDivisor
    {
        /// <summary>   Euclids gcd. </summary>
        /// <param name="a">    An int to process. </param>
        /// <param name="b">    An int to process. </param>
        /// <returns>   An int. </returns>
        public static int EuclidsGCD(int a, int b)
        {
            return Algorithm(a, b, EuclidsAlgorithm);
        }
        
        /// <summary>   Euclids gcd. </summary>
        /// <param name="a">    An int to process. </param>
        /// <param name="b">    An int to process. </param>
        /// <param name="c">    An int to process. </param>
        /// <returns>   An int. </returns>
        public static int EuclidsGCD(int a, int b, int c)
        {
            return Algorithm(a, b, c, EuclidsAlgorithm);
        }
        
        /// <summary>   Euclids gcd. </summary>
        /// <exception cref="ArgumentException">    Thrown when one or more arguments have unsupported or
        ///                                         illegal values. </exception>
        /// <param name="numbers">  A variable-length parameters list containing numbers. </param>
        /// <returns>   An int. </returns>
        public static int EuclidsGCD(params int[] numbers)
        {
            if (numbers.Length == 1 && numbers[0] == 0)
            {
                throw new ArgumentException($"{nameof(numbers)} cant have length is one and element zero");
            }

            return Algorithm(EuclidsAlgorithm, numbers);
        }
        
        /// <summary>   Binary finding of GCD. </summary>
        /// <param name="a">    An int to process. </param>
        /// <param name="b">    An int to process. </param>
        /// <returns>   An int - GCD. </returns>
        public static int BinaryGCD(int a, int b)
        {
            return Algorithm(a, b, BinaryEuclideanAlgoritm);
        }
        
        /// <summary>   Binary finding of GCD. </summary>
        /// <param name="a">    An int to process. </param>
        /// <param name="b">    An int to process. </param>
        /// <param name="c">    An int to process. </param>
        /// <returns>   An int - GCD. </returns>
        public static int BinaryGCD(int a, int b, int c)
        {
            return Algorithm(a, b, c, BinaryEuclideanAlgoritm);
        }
        
        /// <summary>   Binary finding of GCD. </summary>
        /// <exception cref="ArgumentException">    Thrown when one or more arguments have unsupported or
        ///                                         illegal values. </exception>
        /// <param name="numbers">  A variable-length parameters list containing numbers. </param>
        /// <returns>   An int. </returns>
        public static int BinaryGCD(params int[] numbers)
        {
            return Algorithm(BinaryEuclideanAlgoritm, numbers);
        }
        
        /// <summary>   Common euclids algorithm. </summary>
        /// <param name="a">            An int to process. </param>
        /// <param name="b">            An int to process. </param>
        /// <param name="Algorithm">    The algorithm of finding GCD. </param>
        /// <returns>   An int. </returns>
        private static int Algorithm(int a, int b, Func<int, int, int> algorithm)
        {
            return algorithm(a, b);
        }
        
        /// <summary>   Common euclids algorithm. </summary>
        /// <param name="a">            An int to process. </param>
        /// <param name="b">            An int to process. </param>
        /// <param name="c">            An int to process. </param>
        /// <param name="Algorithm">    The algorithm of finding GCD. </param>
        /// <returns>   An int. </returns>
        private static int Algorithm(int a, int b, int c, Func<int, int, int> algorithm)
        {
            return algorithm(algorithm(a, b), c);
        }
        
        /// <summary>   Common euclids algorithm. </summary>
        /// <exception cref="ArgumentException">    Thrown when one or more arguments have unsupported or
        ///                                         illegal values. </exception>
        /// <param name="Algorithm">    The algorithm of finding GCD. </param>
        /// <param name="numbers">      A variable-length parameters list containing numbers. </param>
        /// <returns>   An int. </returns>
        private static int Algorithm(Func<int, int, int> algorithm, params int[] numbers)
        {
            if (numbers.Length == 1 && numbers[0] == 0)
            {
                throw new ArgumentException($"{nameof(numbers)} cant have length is one and element zero");
            }

            int answer = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                answer = algorithm(answer, numbers[i]);
            }

            return answer;
        }

        /// <summary>   Euclids algorithm for int array. </summary>
        /// <exception cref="ArgumentException">    Thrown when one or more arguments have unsupported or
        ///                                         illegal values. </exception>
        /// <param name="numbers">  A variable-length parameters list containing numbers. </param>
        /// <returns>   Greatest Common Divisor of numbers like a integer value . </returns>
        private static int EuclidsAlgorithm(params int[] numbers)
        {
            int greatestCommonDivisor = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                greatestCommonDivisor = EuclidsAlgorithm(greatestCommonDivisor, numbers[i]);
            }

            return greatestCommonDivisor;
        }

        /// <summary>   Euclids algorithm for int array. </summary>
        /// <param name="a">    An int to process. </param>
        /// <param name="b">    An int to process. </param>
        /// <returns>   Greatest Common Divisor of numbers like a integer value . </returns>
        private static int EuclidsAlgorithm(int a, int b)
        {
            CheckingForParams(ref a, ref b);
            if (a == 0)
            {
                return b;
            }

            if (b == 0)
            {
                return a;
            }

            while (a != b)
            {
                if (a > b)
                {
                    a -= b;
                }
                else
                {
                    b -= a;
                }
            }

            return a;
        }
        
        /// <summary>   Euclids algorithm for int array. </summary>
        /// <param name="a">    An int to process. </param>
        /// <param name="b">    An int to process. </param>
        /// <param name="c">    An int to process. </param>
        /// <returns>   Greatest Common Divisor of numbers like a integer value . </returns>
        private static int EuclidsAlgorithm(int a, int b, int c)
        {
            return EuclidsAlgorithm(EuclidsAlgorithm(a, b), c);
        }

        /// <summary>   Binary Euclidean algoritm for search of Greatest common divisor . </summary>
        /// <exception cref="ArgumentException">    Thrown when one or more arguments have unsupported or
        ///                                         illegal values. </exception>
        /// <param name="numbers">  A variable-length parameters list containing numbers. </param>
        /// <returns>   Greatest Common Divisor of numbers like a integer value . </returns>
        private static int BinaryEuclideanAlgoritm(params int[] numbers)
        {
            if (numbers.Length == 1 && numbers[0] == 0)
            {
                throw new ArgumentException($"{nameof(numbers)} cant have length is one and element zero");
            }

            int greatestCommonDivisor = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                greatestCommonDivisor = BinaryEuclideanAlgoritm(greatestCommonDivisor, numbers[i]);
            }

            return greatestCommonDivisor;
        }
        
        /// <summary>   Binary Euclidean algoritm for search of Greatest common divisor . </summary>
        /// <param name="a">    An int to process. </param>
        /// <param name="b">    An int to process. </param>
        /// <returns>   Greatest Common Divisor of numbers like a integer value . </returns>
        private static int BinaryEuclideanAlgoritm(int a, int b)
        {
            CheckingForParams(ref a, ref b);

            if (a == 0)
            {
                return b;
            }

            if (b == 0)
            {
                return a;
            }

            int k = 1;

            while (a != 0 && b != 0)
            {
                while (a % 2 == 0 && b % 2 == 0)
                {
                    a /= 2;
                    b /= 2;
                    k *= 2;
                }

                EvenNumberDevBy2(a, b);

                if (a >= b)
                {
                    a -= b;
                }
                else
                {
                    b -= a;
                }
            }

            return b * k;
        }
        
        /// <summary>   Binary Euclidean algoritm for search of Greatest common divisor . </summary>
        /// <param name="a">    An int to process. </param>
        /// <param name="b">    An int to process. </param>
        /// <param name="c">    An int to process. </param>
        /// <returns>   Greatest Common Divisor of numbers like a integer value . </returns>
        private static int BinaryEuclideanAlgoritm(int a, int b, int c)
        {
            return BinaryEuclideanAlgoritm(BinaryEuclideanAlgoritm(a, b), c);
        }
        
        /// <summary>   Checking for parameters. </summary>
        /// <param name="a">    [in,out] An int to process. </param>
        /// <param name="b">    [in,out] An int to process. </param>
        private static void CheckingForParams(ref int a, ref int b)
        {
            if (a < 0)
            {
                a = -a;
            }

            if (b < 0)
            {
                b = -b;
            }
        }

        /// <summary>   Even number devision by 2. </summary>
        /// <param name="greatestCommonDivisor">    The greatest common number. </param>
        /// <param name="number">                   Number of. </param>
        private static void EvenNumberDevBy2(int greatestCommonDivisor, int number)
        {
            while (greatestCommonDivisor % 2 == 0)
            {
                greatestCommonDivisor /= 2;
            }

            while (number % 2 == 0)
            {
                number /= 2;
            }
        }
    }
}
