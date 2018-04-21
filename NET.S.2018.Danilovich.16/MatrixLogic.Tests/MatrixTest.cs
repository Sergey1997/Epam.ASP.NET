using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace MatrixLogic.Tests
{
    [TestFixture]
    public class MatrixTest
    {
        int[,] expectedSquare = new int[,]
        {
            {2,4,6 },
            {8,10,12 },
            {14,16,18 }
        };

        public static readonly SquareMatrix<int> SquareMatrix =
             new SquareMatrix<int>(new[,]
                 {
                    {1, 2, 3 },
                    {4, 5, 6 },
                    {7, 8, 9 }
                 });
        int[,] expectedDiagonal = new int[,]
        {
            {2,0,0 },
            {0,10,0 },
            {0,0,18 }
        };

        public static readonly SquareMatrix<int> DiagonalMatrix =
             new DiagonalMatrix<int>(new[,]
                 {
                    {1, 0, 0 },
                    {0, 5, 0 },
                    {0, 0, 9 }
                 });
        int[,] expectedSymmetric = new int[,]
        {
            {2,8,12 },
            {8,10,24 },
            {12,24,18 }
        };
        public static readonly SquareMatrix<int> SymmetricMatrix =
             new SymmetricMatrix<int>(new[,]
                 {
                    {1, 2, 3 },
                    {2, 5, 6 },
                    {3, 6, 9 }
                 });
        [Test]
        public void SquareMatrixConstructorTest()
        {
            SquareMatrix<int> actual = new SquareMatrix<int>(3);
            int[,] expected = new int[3, 3];
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void SymmetricMatrixConstructorTest()
        {
            SymmetricMatrix<int> actual = new SymmetricMatrix<int>(3)
            {
                [0, 1] = 2
            };
            int[,] expected = new int[3, 3];
            expected[0, 1] = 2;
            expected[1, 0] = 2;
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void SquareMatrixSumTest()
        {
            Assert.AreEqual(expectedSquare, SquareMatrix.Sum(SquareMatrix));
        }
        [Test]
        public void DiagonalMatrixSumTest()
        {
            Assert.AreEqual(expectedDiagonal, DiagonalMatrix.Sum(DiagonalMatrix));
        }
        [Test]
        public void SymmeetricMatrixSumTest()
        {
            Assert.AreEqual(expectedSymmetric, SymmetricMatrix.Sum(SymmetricMatrix));
        }
    }
}
