using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleExtension
{
    public static class Double
    {
        /// <summary>   Convert double to 64bit IEEE754 format. </summary>
        /// <param name="number">   Number of double. </param>
        /// <returns>   The double converted. </returns>
        public static string ConvertDouble(double number)
        {
            string sign;
            
            if (number < 0 || double.IsNaN(number) || double.IsNegativeInfinity(number))
            {
                number = -number;
                sign = "1";
            }
            else
            {
                sign = "0";
            }

            return sign + IdentifyExpOfNumber(number).Substring(0, 11) + IdentifyMantissa(number).Substring(0, 52);
        }

        private static string IdentifyExpOfNumber(double number)
        {
            string exponenta = string.Empty;
            if (DefineConstForExp(number, ref exponenta) == true)
            {
                return exponenta;
            }

            ConvertToBinary(number, out exponenta, out string mantissa);
            int exp = exponenta.Length - 1;
            ConvertToBinary(exp + 1023, out exponenta, out mantissa);
            return exponenta;
        }
        
        /// <summary>   Identify mantissa for transformation to string. </summary>
        /// <param name="number">   Number of double. </param>
        /// <returns>   A string of bits. </returns>
        private static string IdentifyMantissa(double number)
        {
            string mantissa = string.Empty;
            if (DefineConstForMantissa(number, ref mantissa) == true)
            {
                return mantissa;
            }

            ConvertToBinary(number, out string exponenta, out mantissa);
            mantissa = mantissa.Insert(0, exponenta.Substring(1));
            exponenta = "1";
            return mantissa;
        }

        /// <summary>   Convert exponent part to string of bits. </summary>
        /// <param name="number">   Number of double. </param>
        /// <returns>   The number converted. </returns>
        private static string ConvertExp(int number)
        {
            StringBuilder result = new StringBuilder();

            while (number != 1)
            {
                result.Insert(0, number % 2);
                number /= 2;
            }

            result.Insert(0, 1);

            return result.ToString();
        }

        /// <summary>   Convert mantissa to string of bits. </summary>
        /// <param name="number">   Number of double. </param>
        /// <returns>   The mantissa converted to string. </returns>
        private static string ConvertMantissa(double number)
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < 52; i++)
            {
                number *= 2;
                int intPart = (int)number;
                result.Append(intPart.ToString());
                number -= intPart;
            }

            return result.ToString();
        }

        /// <summary>   Converts this number(exponenta and mantissa parts) to a binary. </summary>
        /// <param name="number">       Number of double. </param>
        /// <param name="exponenta">    [out] The exponenta. </param>
        /// <param name="mantissa">     [out] The mantissa. </param>
        private static void ConvertToBinary(double number, out string exponenta, out string mantissa)
        {
            exponenta = ConvertExp((int)number);
            mantissa = ConvertMantissa(number - (int)number);
        }

        /// <summary>   Define constant values for mantissa. </summary>
        /// <param name="number">   Number of double. </param>
        /// <param name="answer">   [in,out] The answer. </param>
        /// <returns>   True if it succeeds, false if it fails. </returns>
        private static bool DefineConstForMantissa(double number, ref string answer)
        {
            if (double.IsPositiveInfinity(number))
            {
                answer = "0000000000000000000000000000000000000000000000000000";
                return true;
            }

            if (double.IsNaN(number) || double.IsNegativeInfinity(number))
            {
                answer = "1000000000000000000000000000000000000000000000000000";
                return true;
            }

            if (double.Epsilon == number)
            {
                answer = "0000000000000000000000000000000000000000000000000001";
                return true;
            }

            if (double.MinValue == number || double.MaxValue == number)
            {
                answer = "1111111111111111111111111111111111111111111111111111";
                return true;
            }

            return false;
        }
        
        /// <summary>   Define constant values for exponenta part. </summary>
        /// <param name="number">   Number of double. </param>
        /// <param name="answer">   [in,out] The answer. </param>
        /// <returns>   True if it succeeds, false if it fails. </returns>
        private static bool DefineConstForExp(double number, ref string answer)
        {
            if (double.IsNegativeInfinity(number) || double.IsNaN(number) || double.IsPositiveInfinity(number))
            {
                answer = "11111111111";
                return true;
            }

            if (double.MaxValue == number || double.MinValue == number)
            {
                answer = "11111111110";
                return true;
            }

            if (double.Epsilon == number)
            {
                answer = "00000000000";
                return true;
            }

            return false;
        }
    }
}
