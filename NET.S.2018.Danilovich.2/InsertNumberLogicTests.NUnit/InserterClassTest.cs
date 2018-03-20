using System;
using InsertNumberLogic;
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
        
        [TestCase(8, 15, -1, 5)]
        public static void InsertNumberTest_FirstNumber_SecondNumber_i_j_ArgumentOutOfRangeException(int firstNumber, int secondNumber, int i, int j)
            => Assert.Throws<ArgumentOutOfRangeException>(() => Inserter.InsertNumber(firstNumber, secondNumber, i, j));
        [TestCase(8, 15, 30, 35)]
        public static void InsertNumberTest_FirstNumber_SecondNumber_i_jMoreThen31_ArgumentOutOfRangeException(int firstNumber, int secondNumber, int i, int j)
           => Assert.Throws<ArgumentOutOfRangeException>(() => Inserter.InsertNumber(firstNumber, secondNumber, i, j));

        [TestCase(8, 15, 6, 3)]
        public static void InsertNumberTest_FirstNumber_SecondNumber_i_j_ArgumentException(int firstNumber, int secondNumber, int i, int j)
            => Assert.Throws<ArgumentException>(() => Inserter.InsertNumber(firstNumber, secondNumber, i, j));
    }
}
