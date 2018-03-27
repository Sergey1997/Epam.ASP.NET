using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using PolynomialLibrary;

namespace PolynomialLibrary.Tests
{
    [TestFixture]
    public class PolynomialTests
    {
        public static IEnumerable<TestCaseData> AddMethodTestData
        {
            get
            {
                yield return new TestCaseData(new Polynomial(new[] { 1.2, 2, 1, 1 } ),
                                              new Polynomial(new[] { 1.2, 2, 6.1, 1, 1 }))
                                     .Returns(new Polynomial(new[] { 2.4, 4, 7.1, 2, 1 }));
            }
        }

        [Test, TestCaseSource(nameof(AddMethodTestData))]
        public Polynomial Polynomial_Plus_Polynomial_Test(Polynomial lhs, Polynomial rhs)
        {
            return lhs + rhs;
        }

        public static IEnumerable<TestCaseData> MultiplyMethodTestData
        {
            get
            {
                yield return new TestCaseData(new Polynomial(new[] { 2d, 2.0 }),
                                              new Polynomial(new[] { 2d, 2.0 }))
                                     .Returns(new Polynomial(new[] { 4d, 8, 4.0 }));
            }
        }

        [Test, TestCaseSource(nameof(MultiplyMethodTestData))]
        public Polynomial Multiply_Polynomials_Test(Polynomial lhs, Polynomial rhs)
        {
            return lhs * rhs;
        }

        [TestCase(3)]
        public void Multiply_Polynomial_With_Number_Test(double number)
        {
            Polynomial actual = new Polynomial(1, 3, 2) * number;
            Polynomial expected = new Polynomial(3, 9, 6);
            Assert.AreEqual(expected, actual);
        }

        public static IEnumerable<TestCaseData> IsEqualsMethodTestData
        {
            get
            {
                yield return new TestCaseData(new Polynomial(new[] { -1.0, 2 }),
                                              new Polynomial(new[] { -1.0, 2 }))
                                     .Returns(true);
            }
        }

        [Test, TestCaseSource(nameof(IsEqualsMethodTestData))]
        public bool IsEquals_Polynomials_Test(Polynomial lhs, Polynomial rhs)
        {
            return lhs == rhs;
        }

        public static IEnumerable<TestCaseData> IsNotEqualsMethodTestData
        {
            get
            {
                yield return new TestCaseData(new Polynomial(new[] { -1.0, 2 } ),
                                              new Polynomial(new[] { -1.5, 2 }))
                                     .Returns(true);
            }
        }

        [Test, TestCaseSource(nameof(IsNotEqualsMethodTestData))]
        public bool IsNotEquals_Polynomials_Test(Polynomial lhs, Polynomial rhs)
        {
            return lhs != rhs;
        }
    }
}
