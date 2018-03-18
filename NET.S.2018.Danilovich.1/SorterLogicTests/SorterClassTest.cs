using System;
using SorterLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logic.Tests
{
    [TestClass]
    public class SorterClassTest
    {
        [TestMethod]
        public void QuickSort_ComparisionOfTwoArrays_ReturnedSortedArray()
        {
            int[] actual = { 90, 9, -2, 5, 1, 93, 0 };
            int[] expected = { -2, 0, 1, 5, 9, 90, 93 };
            actual.QuickSort();
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void QuickSort_ComparisionInRange_ReturnedSortedPartOfArray()
        {
            int left = 2;
            int right = 4;
            int[] actual = { 0, 6, 2, 9, 1, 21, 52 };
            int[] expected = { 0, 6, 1, 2, 9, 21, 52 };

            actual.QuickSort(left, right);
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void QuickSort_SortingOfNullArray_ReturnedNullException()
        {
            int[] array = null;
            int left = 2;
            int right = 4;
            array.QuickSort(left, right);
            array.QuickSort();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void QuickSort_ComparisionWithNullArgument_ReturnedArgumentOutOfRangeException()
        {
            int[] array = { 5, 4, 3, 2 };
            int left = 2;
            int right = array.Length + 1;
            array.QuickSort(left, right);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MergeSort_ComparisionWithNullArgument_ReturnedNullArgumentException()
        {
            int[] array = null;
            array.MergeSort();
        }

        [TestMethod]
        public void MergeSort_ComparisionOfTwoArrays_ReturnedSortedArray()
        {
            int[] array = { 0, 6, 2, 9, 1, 21, 52 };
            int[] expected = { 0, 1, 2, 6, 9, 21, 52 };
            int[] actual = array.MergeSort();

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
