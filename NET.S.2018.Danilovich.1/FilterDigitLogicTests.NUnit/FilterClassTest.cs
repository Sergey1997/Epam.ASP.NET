using System;
using System.Collections.Generic;
using FilterDigitLogic;
using NUnit.Framework;

namespace FilterDigitLogicTests.NUnit
{
    [TestFixture]
    public class FilterClassTest
    {

        private static object[] sourceList =
        {
             new object[] { new int[] {  4, 53, 74, 27, 4 }, new int[] { 74, 27} , new SameDigit(7) },
             new object[] { new int[] {  33, 24, 3, 37, 4 }, new int[] { 24, 4} , new EvenNumber() },
             new object[] { new int[] {  4, 98, 97, 24, 3 }, new int[] { 4, 24, 3} , new LessThan(7) },
             new object[] { new int[] {  0, 21, 1, 11, 55 }, new int[] { 0, 21, 1, 11} , new LessThan(2) },
        };

        [Test, TestCaseSource("sourceList")]
        public void FilterDigit_DigitLogicTest(int[] array, int[] expected, IPredicate predicate)
        {
            int[] result = array.FilterDigit(predicate);
            Assert.AreEqual(expected, result);
        }
        
    }
}
