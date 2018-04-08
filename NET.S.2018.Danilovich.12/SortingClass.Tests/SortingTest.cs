using NUnit.Framework;
using SortingLibrary;
using System;
using System.Collections.Generic;

namespace SortingClass.Tests
{
    [TestFixture]
    public class SortingTest
    {
        private static object[] sourceList =
        {
             new object[] { new int[][] { new int[] { 1, 3, 5, 7, 9 }, new int[] { 0, 2, 4, 6 }, new int[] { 43, 223, 12 }, new int[] { 532, 22 }, new int[] { 2, 11 } },
                            new int[][] { new int[] { 0, 2, 4, 6 }, new int[] { 2, 11 }, new int[] { 1, 3, 5, 7, 9 }, new int[] { 43, 223, 12 }, new int[] { 532, 22 } },
                            new SumOfArray() },
             new object[] { new int[][] { new int[] { 1, 3 }, new int[] { 0, 2 }, new int[] { -2, 5 } },
                            new int[][] { new int[] { 0, 2 }, new int[] { 1, 3 }, new int[] { -2, 5 } },
                            new MaxOfArray() },
             new object[] { new int[][] { new int[] { -2, 3 }, new int[] { -5, 2 }, new int[] { 8, 5 } },
                            new int[][] { new int[] { -5, 2 }, new int[] { -2, 3 }, new int[] { 8, 5 } },
                            new MinOfArray() },
             new object[] { new int[][] { new int[] { -2, 9 }, null, new int[] { 8, 5 }, new int[] { 53, 5 } },
                            new int[][] { new int[] { 8, 5 }, new int[] { -2, 9 }, new int[] { 53, 5 }, null },
                            new MaxOfArray() },
             new object[] { new int[][] { new int[] { -2, 9 }, null, new int[] { 8, 5 }, null },
                            new int[][] { new int[] { 8, 5 }, new int[] { -2, 9 }, null, null },
                            new MaxOfArray() },
             new object[] { new int[][] { null, null },
                            new int[][] { null, null },
                            new MaxOfArray() },
             new object[] { new int[][] { null, new int[] { 5 }, null },
                            new int[][] { new int[] { 5 }, null, null },
                            new MaxOfArray() },
        };
        
        [Test, TestCaseSource("sourceList")]
        public void TestMethodForSorting(int[][] actual, int[][] expected, IComparer<int[]> strategy)
        {
            Sorting.Sort(actual,strategy.Compare);
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
