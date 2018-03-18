using Logic;
using NUnit.Framework;

namespace LogicTests_NUnit
{
    [TestFixture]
    public class FilterClassTest
    {
        [Test]
        [TestCase(new int[] { 54, 125, 321, 32 }, 5, ExpectedResult = new int[] { 54, 125 }, TestName = "FiterDigitUNitTest_FilterWithPositiveValuesOfArray_ReturnedFiltredArray")]
        [TestCase(new int[] { -5321, 9843, 1241, 1232 }, 3, ExpectedResult = new int[] { -5321, 9843, 1232 }, TestName = "FiterDigitUNitTest_FilterWithNegativeValuesOfArray_ReturnedFiltredArray")]
        [TestCase(new int[] { 23, 23, 23, 23 }, 4, ExpectedResult = new int[] { }, TestName = "FiterDigitUNitTest_FilterWithOutEntries_ReturnedEmptyArray")]
       
        public int[] FilterDigitTests(ref int[] array, int digit)
        {
            Filter.FilterDigit(ref array, digit);
            return array;
        }
    }
}
