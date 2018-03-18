using System.Collections.Generic;
using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FilterDigitLogicTests.DDT
{
    [TestClass]
    public class FilterClassTestDDT
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        [DeploymentItem("Objectivity.Test.Automation.MsTests\\Filters.xml"),
        DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
        "|DataDirectory|\\Filters.xml", "TestCase",
         DataAccessMethod.Sequential)]

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>(Unit Test Method) tests filter logic tests ddt. Bicycle.</summary>
        ///
        /// <remarks>Sergey, 18.03.2018.</remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void FilterLogicTests_DDTTest()
        {
            string rowInput = TestContext.DataRow["InputArray"].ToString();
            int digit = int.Parse((string)TestContext.DataRow["Digit"]);
            string expectedResult = TestContext.DataRow["ExpectedResult"].ToString();

            List<int> actualList = new List<int>();
            string[] actualString = rowInput.Split(',');
            for (int i = 0; i < actualString.Length; i++)
            {
                actualList.Add(int.Parse(actualString[i]));
            }

            List<int> expectedList = new List<int>();

            string[] expectedString = expectedResult.Split(',');

            for (int i = 0; i < expectedString.Length; i++)
            {
                expectedList.Add(int.Parse(expectedString[i]));
            }

            int[] expectedArray = new int[expectedList.Count];
            int[] actuaArray = new int[actualList.Count];

            for (int i = 0; i < expectedArray.Length; i++)
            {
                expectedArray[i] = expectedList[i];
            }

            for (int i = 0; i < actuaArray.Length; i++)
            {
                actuaArray[i] = actualList[i];
            }

            Filter.FilterDigit(ref actuaArray, digit);
            CollectionAssert.AreEqual(expectedArray, actuaArray);
        }
    }
}