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
    public class PolynomialClassTest
    {
        [Test]
        [TestCase(new double[] { 5, 324, 2, 1, 43.2 }, ExpectedResult = 4)]
        [TestCase(new double[] { 21, 4, 6, 12}, ExpectedResult = 3)]
        public int PolynomialDegreeTests(double[] actual)
        {
            Polynomial polynomial = new Polynomial(actual);

            return polynomial.Degree;
        }
    }
}
