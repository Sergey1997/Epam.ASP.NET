using System;

namespace MathExtension
{
    public class GreatestCommonDivisor
    {
        /// <summary>   Euclids algorithm for int array. </summary>
        /// <exception cref="ArgumentNullException">    Thrown when one or more required arguments are
        ///                                             null. </exception>
        /// <exception cref="ArgumentException">        Thrown when one or more arguments have
        ///                                             unsupported or illegal values. </exception>
        /// <param name="numbers">  A variable-length parameters list containing numbers. </param>
        /// <returns>   Greatest Common Divisor of numbers like a integer value . </returns>
        public static int EuclidsAlgorithm(params int[] numbers)
        {
            if (numbers.Length == 0)
            {
                throw new ArgumentNullException($"{nameof(numbers.Length)} must not be zero");
            }

            int greatestCommonDivisor = FindFirstNotZeroNumber(out int startIndex, numbers);

            if (greatestCommonDivisor == 0)
            {
                throw new ArgumentException($"{nameof(numbers)} at least one of numbers must not be a zero");
            }

            for (int i = startIndex + 1; i < numbers.Length; i++)
            {
                while (greatestCommonDivisor != numbers[i] && numbers[i] != 0)
                {
                    if (numbers[i] < 0)
                    {
                        numbers[i] = -numbers[i];
                    }

                    if (greatestCommonDivisor > numbers[i])
                    {
                        greatestCommonDivisor -= numbers[i];
                    }
                    else
                    {
                        numbers[i] -= greatestCommonDivisor;
                    }
                }
            }

            return greatestCommonDivisor;
        }

        /// <summary>   Binary Euclidean algoritm for search of Greatest common divisor . </summary>
        /// <exception cref="ArgumentException">    Thrown when one or more arguments have unsupported or
        ///                                         illegal values. </exception>
        /// <param name="numbers">  A variable-length parameters list containing numbers. </param>
        /// <returns>   Greatest Common Divisor of numbers like a integer value . </returns>
        public static int BinaryEuclideanAlgoritm(params int[] numbers)
        {
            int greatestCommonDivisor = FindFirstNotZeroNumber(out int startIndex, numbers);

            if (greatestCommonDivisor == 0)
            {
                throw new ArgumentException($"{nameof(numbers)} at least one of numbers must not be a zero");
            }

            for (int i = startIndex + 1; i < numbers.Length; i++)
            {
                int k = 1;

                if (numbers[i] == 0)
                {
                    numbers[i] = greatestCommonDivisor;
                }

                while (greatestCommonDivisor != 0 && numbers[i] != 0)
                {
                    if (numbers[i] < 0)
                    {
                        numbers[i] = -numbers[i];
                    }

                    while (greatestCommonDivisor % 2 == 0 && numbers[i] % 2 == 0)
                    {
                        greatestCommonDivisor /= 2;
                        numbers[i] /= 2;
                        k *= 2;
                    }

                    while (greatestCommonDivisor % 2 == 0)
                    {
                        greatestCommonDivisor /= 2;
                    }

                    while (numbers[i] % 2 == 0)
                    {
                        numbers[i] /= 2;
                    }

                    if (greatestCommonDivisor >= numbers[i])
                    {
                        greatestCommonDivisor -= numbers[i];
                    }
                    else
                    {
                        numbers[i] -= greatestCommonDivisor;
                    }
                }

                greatestCommonDivisor = numbers[i] * k;
            }

            return greatestCommonDivisor;
        }

        /// <summary>  
        /// Searches for the first not zero number in numbers. 
        /// </summary>
        /// <param name="index"> [out] Index for new point of entry. </param>
        /// <param name="numbers">  A variable-length parameters list containing numbers. </param>
        /// <returns>   The found first not zero number. </returns>
        private static int FindFirstNotZeroNumber(out int index, params int[] numbers)
        {
            int greatestCommonDivisor = 0;
            index = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] != 0)
                {
                    greatestCommonDivisor = numbers[i];
                    index = i;
                    break;
                }
            }

            return Math.Abs(greatestCommonDivisor);
        }
    }
}
