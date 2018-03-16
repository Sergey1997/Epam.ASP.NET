using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logic.DDT.Tests
{
    [TestClass]
    public class FilterClassTest
    {

        public TestContext TestContext { get; set; }

        [DataSource(
           "Microsoft.VisualStudio.TestTools.DataSource.XML",
           "|DataDirectory|\\Filters.xml",
           "TestCase",
           DataAccessMethod.Sequential)]
        [DeploymentItem("Logic.DDT.Tests\\Filters.xml")]
        [TestMethod]
        public void TestMethod1()
        {
            var inputArray = Convert.ToString(TestContext.DataRow["InputArray"]).Split(',');
            for(int i=0;i<inputArray.Length;i++)
            Console.WriteLine(inputArray[i]);
            var lastName = Convert.ToInt32(TestContext.DataRow["Digit"]);
            var expected = Convert.ToString(TestContext.DataRow["ExpectedResult"]);

            inputArray.ToCharArray();
            inputArray.Split(',');
        }
    }
}
