using System;
using InsertNumLogic;
using NUnit.Framework;

namespace InsertNumberLogicTests.NUnit
{
    [TestFixture]
    public class InserterClassTest
    {
        [TestCase(8, 15, 3, 8, ExpectedResult = 120)]
        public static int InsertNumberTest(int firstNumber, int secondNumber, int i, int j)
        {
            return Inserter.InsertNumber(firstNumber, secondNumber, i, j);
        }
    }
}
