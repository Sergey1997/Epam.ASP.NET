using System;
using System.Collections.Generic;
using FilterDigitLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FilterDigitLogicTests
{
    [TestClass]
    public class FilterClassTest<T>
    {
        public void FilterDigitTest_PositiveEntries_ReturnedFiltredArray()
        {
            List<int> array = new List<int>{ 55, 123, 52, 85, 23, 41, 31 };
            T digit = 5;
            List<T> actual = array.FilterDigit(digit);
            List<int> expected = new List<int>{ 55, 52, 85 };

            CollectionAssert.AreEqual(expected, actual);
        }
        
        public void FilterDigitTest_WasteOfTime_ReturnedArrayWithTime()
        {
            List<int> array = new List<int> { -55, 123, -52, 85, 23, 41, 31 };
            int digit = 5;
            long time;
            List<int> actual = array.FilterDigit(digit, out time);
            List<int> expected = new List<int> { -55, -52, 85 };
            CollectionAssert.AreEqual(expected, actual);
        }

        
        public void FilterDigitTest_NegativeEntries_ReturnedFiltredArray()
        {
            List<int> array = new List<int>{ -55, 123, -52, 85, 23, 41, 31 };
            int digit = 5;
            List<int> actual = array.FilterDigit(digit);
            List<int> expected = new List<int>{ -55, -52, 85 };

            CollectionAssert.AreEqual(expected, actual);
        }
        
        [ExpectedException(typeof(ArgumentNullException))]
        public void FilterDigitTest_FilterOfNullArray_ReturnedNullArgumentException()
        {
            List<int> array = null;
            int digit = 5;

            array.FilterDigit(digit);
        }
        
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FilterDigitTest_FilterWithBadDigit_ReturnedEArgumentException()
        {
            List<int> array = new List<int> { -55, 123, -52, 85, 23, 41, 31 };
            int digit = -11;
            array.FilterDigit(digit);
        }
    }
}
