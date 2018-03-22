using NUnit.Framework;
using StringExtension;
using System;

namespace StringConverter.Tests
{
    public static class ConverterClassTest
    {
        private static object[] sourceList =
        {
             new object[] { "0110111101100001100001010111111", 2, 934331071 },
             new object[] { "01101111011001100001010111111", 2, 233620159 },
             new object[] { "11111111111111111111111101101110", 2, 37777777556 },
             new object[] { "1AeF101", 16, 28242177 },
             new object[] { "1ACB67", 16, 1756007 },
             new object[] { "764241", 8, 256161 },
        };

        [Test, TestCaseSource("sourceList")]
        public static void ConverterTest(this string inputString, int baseSystem,int expected)
        {
            Assert.AreEqual(expected, inputString.Converter(baseSystem));
        }

        [TestCase("764241",20)]
        [TestCase("SA123",10)]
        public static void ConverterTest_InputString_BaseSystem_ArgumentException(this string inputString, int baseSystem)
           => Assert.Throws<ArgumentException>(() => inputString.Converter(baseSystem));
    }
}
