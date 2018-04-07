using System;
using NUnit.Framework;
using static MathExtension.GreatestCommonDivisor;

namespace MathExtension.Tests
{
    public class GreatestCommonDivisorTests
    {
        private static object[] sourceListForParams =
        {
             new object[] { new FindingDelegateGCD(FindingGCD.Find), 5, new int[] { 55, 0, 20, 40 } },
             new object[] { new FindingDelegateGCD(FindingGCD.Find), 3, new int[] { 0, 0, 3, 6 } },
             new object[] { new FindingDelegateGCD(FindingGCD.Find), 7, new int[] { 7, 7, 14 } },
             new object[] { new FindingDelegateGCD(FindingGCD.Find), 4, new int[] { 32, 36, 44, 24 } },
             new object[] { new FindingDelegateGCD(FindingGCD.FindBinary), 50, new int[] { 4200, 2850, 4300, 2500 } },
             new object[] { new FindingDelegateGCD(FindingGCD.FindBinary), 25, new int[] { -300, 275, 2850, -25 } },
             new object[] { new FindingDelegateGCD(FindingGCD.FindBinary), 2, new int[] { 36, 22, 0, 0 } },
             new object[] { new FindingDelegateGCD(FindingGCD.FindBinary), 5, new int[] { 55, 0, 20, 40 } },
             new object[] { new FindingDelegateGCD(FindingGCD.FindBinary), 100, new int[] { 100 } },
        };

        private static object[] sourceListForTwoNumbers =
        {
             new object[] { new FindingDelegateGCD(FindingGCD.Find), 55, -55, 0 },
             new object[] { new FindingDelegateGCD(FindingGCD.Find), 9, -18, 9 },
             new object[] { new FindingDelegateGCD(FindingGCD.FindBinary), 10, 10, 10 },
             new object[] { new FindingDelegateGCD(FindingGCD.FindBinary), 7, 7, 14 },
             new object[] { new FindingDelegateGCD(FindingGCD.FindBinary), 2, 4, 6 },
        };

        [Test, TestCaseSource("sourceListForParams")]
        public static void EuclidsAlgorithmTest(FindingDelegateGCD findingDelegateGCD, int expected, params int[] numbers)
        {
            Assert.AreEqual(expected, GreatestCommonDivisor.EuclidMethodForFindingGCD(findingDelegateGCD, numbers));
        }

        [Test, TestCaseSource("sourceListForTwoNumbers")]
        public static void EuclidsAlgorithmTest(FindingDelegateGCD findingDelegateGCD, int expected, int a, int b)
        {
            Assert.AreEqual(expected, GreatestCommonDivisor.EuclidMethodForFindingGCD(findingDelegateGCD, a, b));
        }

        [TestCase(null, null)]
        public static void EuclidsAlgorithmTest_Numbers_ArgumentNullException(FindingDelegateGCD findingDelegateGCD, params int[] numbers)
            => Assert.Throws<ArgumentNullException>(() => GreatestCommonDivisor.EuclidMethodForFindingGCD(findingDelegateGCD, numbers));
    }
}
