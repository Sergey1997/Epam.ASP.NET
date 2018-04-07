using System;
using System.Linq.Expressions;

namespace MathExtension
{
    public class GreatestCommonDivisor
    {
        /// <summary>   Delegate for finding a GCD of numbers. </summary>
        /// <param name="numbers">  A variable-length parameters list containing numbers. </param>
        /// <returns>   An int value - GCD. </returns>
        public delegate int FindGCD(params int[] numbers);
        
        /// <summary>   Gcd for euclid. </summary>
        /// <param name="findGCD">  The find gcd delegate. </param>
        /// <param name="numbers">  A variable-length parameters list containing numbers. </param>
        /// <returns>   An int value. </returns>
        public int GCDForEuclid(FindGCD findGCD, params int[] numbers)
        {
            return findGCD.Invoke(numbers);
        }

        /// <summary>   Euclids algorithm for int array. </summary>
        /// <exception cref="ArgumentException">    Thrown when one or more arguments have unsupported or
        ///                                         illegal values. </exception>
        /// <param name="numbers">  A variable-length parameters list containing numbers. </param>
        /// <returns>   Greatest Common Divisor of numbers like a integer value . </returns>
        private static int EuclidsAlgorithm(params int[] numbers)
        {
            if (numbers.Length == 1 && numbers[0] == 0)
            {
                throw new ArgumentException($"{nameof(numbers)} cant have length is one and element zero");
            }

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

        public static class FingingGCD
        {
            public static int Find(int a, int b) => EuclidsAlgorithm(a, b);

            public static int Find(int a, int b, int c) => EuclidsAlgorithm(EuclidsAlgorithm(a, b), c);

            public static int Find(params int[] numbers) => EuclidsAlgorithm(numbers);

            public static int FindBinary(int a, int b) => BinaryEuclideanAlgoritm(a, b);

            public static int FindBinary(int a, int b, int c) => BinaryEuclideanAlgoritm(EuclidsAlgorithm(a, b), c);

            public static int FindBinary(params int[] numbers) => BinaryEuclideanAlgoritm(numbers);
        }
    }
}
