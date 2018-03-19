using System.Collections.Generic;
using Logic;
using NUnit.Framework;

namespace FilterDigitLogicTests.NUnit
{
    [TestFixture]
    public class FilterClassTest
    {
        private static object[] sourceList = 
            {
            new object[] { new List<int> { 54, 125, 321, 32 }, new List<int> { 125, 321 }, 1, },
            new object[] { new List<int> { 921, 23, 123, 22 }, new List<int> { 921, 23, 123, 22 }, 2, },
            };

        [Test, TestCaseSource("sourceList")]
        public void FilterDigitTests(List<int> actual, List<int> expected, int digit)
        {
            List<int> actualList = actual.FilterDigit(digit);
            Assert.AreEqual(expected, actualList);
        }
    }
}
