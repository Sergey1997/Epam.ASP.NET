using DoubleExtension;
using NUnit.Framework;

namespace DoubleExtension.Tests
{
    public static class DoubleClassTest
    {
        private static object[] sourceList =
        {
             new object[] { -255.255, "1100000001101111111010000010100011110101110000101000111101011100" },
             new object[] { 255.255,"0100000001101111111010000010100011110101110000101000111101011100" },
             new object[] { double.MinValue, "1111111111101111111111111111111111111111111111111111111111111111" },
             new object[] { double.MaxValue, "0111111111101111111111111111111111111111111111111111111111111111" },
        };
        
        [Test, TestCaseSource("sourceList")]
        public static void ConvertDoubleTest(double number, string expected)
        {
            Assert.AreEqual(expected, Double.ConvertDouble(number));
        }


        [TestCase(double.NaN, ExpectedResult = "1111111111111000000000000000000000000000000000000000000000000000")]
        [TestCase(double.NegativeInfinity, ExpectedResult = "1111111111110000000000000000000000000000000000000000000000000000")]
        [TestCase(double.PositiveInfinity, ExpectedResult = "0111111111110000000000000000000000000000000000000000000000000000")]
        [TestCase(double.Epsilon, ExpectedResult = "0000000000000000000000000000000000000000000000000000000000000001")]
        [TestCase(0.0, ExpectedResult = "0000000000000000000000000000000000000000000000000000000000000000")]
        public static string ConverterDoubleTests(double number)
        {
            return Double.ConvertDouble(number);
        }



    }
}
