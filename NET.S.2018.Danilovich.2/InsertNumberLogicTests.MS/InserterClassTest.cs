using System;
using InsertNumberLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InsertNumberLogicTests.MS
{
    [TestClass]
    public class InserterClassTest
    {
        [TestMethod]
        public void InsertNumberTest_TwoIntNumbers_ConvertedNumber()
        {
            int actual = Inserter.InsertNumber(8, 15, 3, 8);
            int expected = 120;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void InsertNumberTest_NegativeIndex_ArgumentOutOfRangeException()
        {
            int i = -5;
            int j = 2;
            Inserter.InsertNumber(8, 15, i, j);
        }
    }
}
