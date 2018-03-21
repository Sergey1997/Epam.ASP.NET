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
             new object[] { 2, new int[] { 36, 22, 0,0 } },
             new object[] { 5, new int[] { 55, 0, 20,40 } },
             new object[] { 3, new int[] { 0, 0, 3, 6 } },
             new object[] { 100, new int[] { 100 } },
        };
        [Test, TestCaseSource("sourceList")]
        public static void EuclidsAlgorithmTest(int expected, params int[] numbers)
        {
            Assert.AreEqual(expected, GreatestCommonDivisor.EuclidsAlgorithm(numbers));
        }

        [Test, TestCaseSource("sourceList")]
        public static void EuclidsBinaryAlgorithmTest(int expected, params int[] numbers)
        {
            Assert.AreEqual(expected, GreatestCommonDivisor.BinaryEuclideanAlgoritm(numbers));
        }

        [TestCase(new int[] { 0 })]
        [TestCase(new int[] { 0, 0, 0 })]
        [TestCase(null)]
        public static void EuclidsAlgorithmTest_Numbers_ArgumentException(params int[] numbers)
            => Assert.Throws<ArgumentException>(() => GreatestCommonDivisor.EuclidsAlgorithm(numbers));
        
        public static void EuclidsAlgorithmTest_Numbers_ArgumentNullException(int expected, params int[] numbers)
            => Assert.Throws<ArgumentNullException>(() => GreatestCommonDivisor.EuclidsAlgorithm(numbers));
    }
}
