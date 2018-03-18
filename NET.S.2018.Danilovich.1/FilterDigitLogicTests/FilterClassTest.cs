﻿using System;
using System.Collections.Generic;
using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FilterDigitLogicTests
{
    [TestClass]
    public class FilterClassTest
    {
        [TestMethod]
        public void FilterDigitTest_PositiveEntries_ReturnedFiltredArray()
        {
            int[] array = { 55, 123, 52, 85, 23, 41, 31 };
            int digit = 5;
            Filter.FilterDigit(ref array, digit);
            int[] expected = { 55, 52, 85 };

            CollectionAssert.AreEqual(expected, array);
        }

        [TestMethod]
        public void FilterDigitTest_NegativeEntries_ReturnedFiltredArray()
        {
            int[] array = { -55, 123, -52, 85, 23, 41, 31 };
            int digit = 5;
            Filter.FilterDigit(ref array, digit);
            int[] expected = { -55, -52, 85 };

            CollectionAssert.AreEqual(expected, array);
        }

        [TestMethod]
        public void FilterDigitTest_WasteOfTime_ReturnedArrayWithTime()
        {
            int[] array = { -55, 123, -52, 85, 23, 41, 31 };
            int digit = 5;
            long time;
            Filter.FilterDigit(ref array, digit, out time);
            int[] expected = { -55, -52, 85 };
            Console.Write(time.ToString());
            CollectionAssert.AreEqual(expected, array);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FilterDigitTest_FilterOfNullArray_ReturnedNullArgumentException()
        {
            int[] array = null;
            int digit = 5;

            Filter.FilterDigit(ref array, digit);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FilterDigitTest_FilterWithBadDigit_ReturnedEArgumentException()
        {
            int[] array = { 55, 123, 52, 85, 23, 41, 31 };
            int digit = -11;

            Filter.FilterDigit(ref array, digit);
        }
    }
}
