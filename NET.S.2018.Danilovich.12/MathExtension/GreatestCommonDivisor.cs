using System;
using System.Linq.Expressions;

namespace MathExtension
{
    public class GreatestCommonDivisor
    {
        /// <summary>   Delegate for finging GCD of numbers. </summary>
        /// <param name="a">    An int to process. </param>
        /// <param name="b">    An int to process. </param>
        /// <returns>   An GCD - int. </returns>
        public delegate int FindingDelegateGCD(int a, int b);

        /// <summary>   Gcd for a lot of numbers. </summary>
        /// <param name="findGCD">  The find gcd delegate. </param>
        /// <param name="numbers">  A variable-length parameters list containing numbers. </param>
        /// <returns>   An int value. </returns>
        public static int EuclidMethodForFindingGCD(FindingDelegateGCD findGCD, params int[] numbers)
        {
            ValidateData(findGCD, numbers);
            return GetGCD(findGCD, numbers);
        }

        /// <summary>   Gcd for a tree numbers. </summary>
        /// <param name="findGCD">  The find gcd delegate. </param>
        /// <param name="a">        An int to process. </param>
        /// <param name="b">        An int to process. </param>
        /// <param name="c">        An int to process. </param>
        /// <returns>   An int value. </returns>
        public static int EuclidMethodForFindingGCD(FindingDelegateGCD findGCD, int a, int b, int c) => findGCD(findGCD.Invoke(a, b), c);
        
        /// <summary>   Gcd for a two numbers. </summary>
        /// <param name="findGCD">  The find gcd delegate. </param>
        /// <param name="a">        An int to process. </param>
        /// <param name="b">        An int to process. </param>
        /// <returns>   An int value. </returns>
        public static int EuclidMethodForFindingGCD(FindingDelegateGCD findGCD, int a, int b)
        {
            ValidateData(findGCD);
            return findGCD.Invoke(a, b);
        }

        /// <summary>   Euclids algorithm for int array. </summary>
        /// <param name="a">    An int to process. </param>
        /// <param name="b">    An int to process. </param>
        /// <returns>   Greatest Common Divisor of numbers like a integer value . </returns>
        public static int EuclidsAlgorithm(int a, int b)
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
        
        /// <summary>   Binary Euclidean algoritm for search of Greatest common divisor . </summary>
        /// <param name="a">    An int to process. </param>
        /// <param name="b">    An int to process. </param>
        /// <returns>   Greatest Common Divisor of numbers like a integer value . </returns>
        public static int BinaryEuclideanAlgoritm(int a, int b)
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
        
        /// <summary>   Validates the data described by findGCD. </summary>
        /// <exception cref="ArgumentNullException">    Thrown when one or more required arguments are
        ///                                             null. </exception>
        /// <param name="findGCD">  The find gcd delegate. </param>
        private static void ValidateData(FindingDelegateGCD findingDelegate)
        {
            if (findingDelegate == null)
            {
                throw new ArgumentNullException($"{(nameof(findingDelegate))} cant be a null");
            }
        }
        
        /// <summary>   Validates the data described by findGCD. </summary>
        /// <exception cref="ArgumentNullException">    Thrown when one or more required arguments are
        ///                                             null. </exception>
        /// <exception cref="ArgumentException">        Thrown when one or more arguments have
        ///                                             unsupported or illegal values. </exception>
        /// <param name="findingDelegate">  The finding delegate. </param>
        /// <param name="numbers">          A variable-length parameters list containing numbers. </param>
        private static void ValidateData(FindingDelegateGCD findingDelegate, params int[] numbers)
        {
            if (findingDelegate == null)
            {
                throw new ArgumentNullException($"{(nameof(findingDelegate))} cant be a null");
            }

            if (numbers.Length == 1 && numbers[0] == 0)
            {
                throw new ArgumentException($"{nameof(numbers)} cant have length is one and element zero");
            }
        }

        private static int GetGCD(FindingDelegateGCD findingDelegate, params int[] numbers)
        {
            int greatestCommonDivisor = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                greatestCommonDivisor = findingDelegate(greatestCommonDivisor, numbers[i]);
            }

            return greatestCommonDivisor;
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
        
        /// <summary>   A finding gcd class. </summary>
        public static class FindingGCD
        {   
            public static int Find(int a, int b) => EuclidsAlgorithm(a, b);

            public static int FindBinary(int a, int b) => BinaryEuclideanAlgoritm(a, b);
        }
    }
}
