using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilterDigitLogic
{
    public static class TransformerLogic
    {
        /// <summary>   An int[] extension method that transformation array. </summary>
        /// <param name="array">        The array. </param>
        /// <param name="transform">    The transform. </param>
        /// <returns>   An int[]. </returns>
        public static T[] TransformationArray<T>(this T[] array, Func<T, T> transform)
        {
            InputValidationTransform(array, transform);

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = transform.Invoke(array[i]);
            }

            return array;
        }

        /// <summary>   An int[] extension method that input validation transform. </summary>
        /// <exception cref="ArgumentNullException">    Thrown when one or more required arguments are
        ///                                             null. </exception>
        /// <param name="array">        The array. </param>
        /// <param name="predicate">    The predicate. </param>
        private static void InputValidationTransform<T>(T[] array, Func<T, T> transform)
        {
            if (array == null)
            {
                throw new ArgumentNullException($"{(nameof(array))} must not be a null");
            }

            if (transform == null)
            {
                throw new ArgumentNullException($"{(nameof(transform))} must not be a null");
            }
        }
    }
}
