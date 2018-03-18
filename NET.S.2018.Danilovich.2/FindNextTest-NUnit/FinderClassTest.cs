using NUnit.Framework;
using FindNext;
using System;
using System.Diagnostics;

namespace FindNextTest_NUnit
{
    [TestFixture]
    public class FinderClassTest
    {
        [TestCase(12, ExpectedResult = 21)]
        [TestCase(513, ExpectedResult = 531)]
        [TestCase(2017, ExpectedResult = 2071)]
        [TestCase(414, ExpectedResult = 441)]
        [TestCase(144, ExpectedResult = 414)]
        [TestCase(1234321, ExpectedResult = 1241233)]
        [TestCase(1234126, ExpectedResult = 1234162)]
        [TestCase(3456432, ExpectedResult = 3462345, TestName = "FindNextTest_BigValue_ReturnedRightValue")]
        [TestCase(10, ExpectedResult = -1)]
        [TestCase(20, ExpectedResult = -1)]
        public static int FindNextBiggerNumber(int number)
        {
            return Finder.FindNextBiggerNumber(number);
        }

        [Test]
        public void FindNextMethod_NumberIsNegative_ArgumentException()
        {
            int number = -5;
            Assert.Throws<ArgumentOutOfRangeException>(() => Finder.FindNextBiggerNumber(number));
        }
    }
}
