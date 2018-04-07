using System;
using NUnit.Framework;

namespace MathExtension.Tests
{
    public class GreatestCommonDivisorTests
    {
        private static object[] sourceList =
        {
             new object[] { 4, new int[] { 32, 36, 44, 24 } },
             new object[] { 50, new int[] { 4200, 2850, 4300, 2500 } },
             new object[] { 25, new int[] { -300, 275, 2850, -25 } },
             new object[] { 2, new int[] { 36, 22, 0, 0 } },
             new object[] { 5, new int[] { 55, 0, 20, 40 } },
             new object[] { 3, new int[] { 0, 0, 3, 6 } },
             new object[] { 2, new int[] { 4, 6 } },
             new object[] { 7, new int[] { 7, 7, 14 } },
             new object[] { 100, new int[] { 100 } },
        };
        
        private static object[] sourceList1 =
        {
             new object[] { 2, 4, 6 },
             new object[] { 7, 7, 14 },
             new object[] { 50, 50, 100 },
        };

        private static object[] sourceList2 =
        {
             new object[] { 5, new int[] { 55, 0, 20, 40 } },
             new object[] { 3, new int[] { 0, 0, 3, 6 } },
             new object[] { 2, new int[] { 4, 6 } },
             new object[] { 7, new int[] { 7, 7, 14 } },
        };

        [Test, TestCaseSource("sourceList")]
        public static void EuclidsAlgorithmTest(int expected, params int[] numbers)
        {
            Assert.AreEqual(expected, GreatestCommonDivisor.FingingGCD.Find(numbers));
        }

        [Test, TestCaseSource("sourceList")]
        public static void EuclidsBinaryAlgorithmTest(int expected, params int[] numbers)
        {
            Assert.AreEqual(expected, GreatestCommonDivisor.FingingGCD.FindBinary(numbers));
        }
        
        [TestCase(null)]
        public static void EuclidsAlgorithmTest_Numbers_ArgumentException(params int[] numbers)
            => Assert.Throws<ArgumentException>(() => GreatestCommonDivisor.FingingGCD.Find(numbers));
        
        [TestCase(null)]
        public static void BinaryEuclideanAlgoritmTest_Numbers_ArgumentException(params int[] numbers)
            => Assert.Throws<ArgumentException>(() => GreatestCommonDivisor.FingingGCD.Find(numbers));

        [Test, TestCaseSource("sourceList1")]
        public static void EuclidsGCDAlgorithmTest(int expected, int a, int b)
        {
            Assert.AreEqual(expected, GreatestCommonDivisor.FingingGCD.Find(a, b));
        }

        [Test, TestCaseSource("sourceList2")]
        public static void BinaryEuclidsGCDAlgorithmTest(int expected, params int[] numbers)
        {
            Assert.AreEqual(expected, GreatestCommonDivisor.FingingGCD.FindBinary(numbers));
        }
    }
}
