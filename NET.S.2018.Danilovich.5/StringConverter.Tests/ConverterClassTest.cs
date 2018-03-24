using System;
using NUnit.Framework;
using StringExtension;
using static StringExtension.StringConverter;

namespace StringConverter.Tests
{
    public static class ConverterClassTest
    {
        private static object[] sourceList =
        {
             new object[] { "0110111101100001100001010111111", new Notation(2), 934331071 },
             new object[] { "01101111011001100001010111111", new Notation(2), 233620159 },
             new object[] { "1AeF101", new Notation(16), 28242177 },
             new object[] { "1ACB67", new Notation(16), 1756007 },
             new object[] { "764241", new Notation(8), 256161 },
        };

        [Test, TestCaseSource("sourceList")]
        public static void ConverterTest(this string inputString, Notation notation, int expected)
        {
            Assert.AreEqual(expected, inputString.ToDecimalConverter(notation));
        }

        [Test]
        public static void ToDecimalConvertMethod_UnpermissibleStringForNotation_ArgumentException()
        {
            string inputString = "SA123";
            Notation notation = new Notation(2);
            Assert.Throws<ArgumentException>(() => inputString.ToDecimalConverter(notation));
        }

        [Test]
        public static void ToDecimalConvertMethod_BigNumber_OverflowException()
        {
            string inputString = "11111111111111111111111111111111";
            Notation notation = new Notation(2);
            Assert.Throws<OverflowException>(() => inputString.ToDecimalConverter(notation));
        }
    }
}
