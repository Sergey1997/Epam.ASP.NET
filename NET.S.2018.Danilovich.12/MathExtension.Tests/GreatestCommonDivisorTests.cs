using System;
using NUnit.Framework;
using static MathExtension.GreatestCommonDivisor;

namespace MathExtension.Tests
{
    public static class GreatestCommonDivisorTests
    {
        private static object[] sourceListForParams =
        {
             new object[] { 5, new int[] { 55, 0, 20, 40 } },
             new object[] { 3, new int[] { 0, 0, 3, 6 } },
             new object[] { 7, new int[] { 7, 7, 14 } },
             new object[] { 4, new int[] { 32, 36, 44, 24 } },
             new object[] { 50, new int[] { 4200, 2850, 4300, 2500 } },
             new object[] { 25, new int[] { -300, 275, 2850, -25 } },
             new object[] { 2, new int[] { 36, 22, 0, 0 } },
             new object[] { 5, new int[] { 55, 0, 20, 40 } },
             new object[] { 100, new int[] { 100 } },
        };

        private static object[] sourceListForTwoNumbers =
        {
             new object[] { 55, -55, 0 },
             new object[] { 9, -18, 9 },
             new object[] { 10, 10, 10 },
             new object[] { 7, 7, 14 },
             new object[] { 2, 4, 6 },
        };

        [Test, TestCaseSource("sourceListForParams")]
        public static void EuclidsAlgorithmTest(int expected, params int[] numbers)
        {
            Assert.AreEqual(expected, GreatestCommonDivisor.EuclidsAlgorithm(numbers));
        }

        [Test, TestCaseSource("sourceListForTwoNumbers")]
        public static void EuclidsAlgorithmTest(int expected, int a, int b)
        {
            Assert.AreEqual(expected, GreatestCommonDivisor.BinaryEuclideanAlgoritm(a, b));
        }

        [TestCase(null)]
        public static void EuclidsAlgorithmTest_Numbers_ArgumentNullException(params int[] numbers)
            => Assert.Throws<ArgumentNullException>(() => GreatestCommonDivisor.BinaryEuclideanAlgoritm(numbers));
    }
}
