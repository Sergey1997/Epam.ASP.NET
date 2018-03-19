using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FindNthRootLogic;
using NUnit.Framework;

namespace FindNthRootLogicTests.NUnit
{
    public class NewtonClassTest
    {
        private static object[] sourceList =
        {
             new object[] { 1, 5, 0.0001, 1 },
             new object[] { 8, 3, 0.0001, 2 },
             new object[] { 0.001, 3, 0.0001, 0.1 },
             new object[] { 0.04100625, 4, 0.0001, 0.45 },
             new object[] { 8, 3, 0.0001, 2 },
             new object[] { 0.0279936, 7, 0.0001, 0.6 },
             new object[] { 0.004241979, 9, 0.00000001, 0.545 },
        };

        [Test, TestCaseSource("sourceList")]
        public static void FindNthRootTest(double number, int degree, double eps, double expected)
        {
            Assert.AreEqual(expected, Newton.FindNthRoot(number, degree, eps), eps);
        }
        
        [TestCase(8, 15, -7, -5)]
        [TestCase(8, 15, -0.6, -0.1)]
        [TestCase(-9, 2, 0.001, 3)]
        public static void FindNthRootTest_Number_Degree_Precision_ArgumentOutOfRangeException(double number, int degree, double precision, double expected) 
            => Assert.Throws<ArgumentOutOfRangeException>(() => Newton.FindNthRoot(number, degree, precision));
    }
}
