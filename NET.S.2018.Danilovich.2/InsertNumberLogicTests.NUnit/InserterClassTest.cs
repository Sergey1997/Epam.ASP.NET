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

        [TestCase(8, 15, 8, 3)]
        [TestCase(8, 15, -1, 5)]
        [TestCase(8, 15, 5, -2)]
        public static void InsertNumberTest_FirstNumber_SecondNumber_i_j_ArgumentOutOfRangeException
            (int firstNumber,int secondNumber,int i,int j)
            => Assert.Throws<ArgumentOutOfRangeException>(() => Inserter.InsertNumber(firstNumber, secondNumber, i,j));
    }
}
