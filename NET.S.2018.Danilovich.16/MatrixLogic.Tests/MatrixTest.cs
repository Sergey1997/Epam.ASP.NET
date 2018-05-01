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
        public static int[,] expectedSquare = new int[,]
        {
            {2,4,6 },
            {8,10,12 },
            {14,16,18 }
        };

        
        public static SquareMatrix<int> SquareMatrix = new SquareMatrix<int>(new[,]
        {
        {1, 2, 3 },
        {4, 5, 6 },
        {7, 8, 9 }
        });

        public readonly DiagonalMatrix<int> DiagonalMatrix = new DiagonalMatrix<int>(new[] { 1, 2 });

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
           SquareMatrix<int> expected = new SymmetricMatrix<int>(new int[3][]
           {
            new int[] {1},
            new int[] {1, 2},
            new int[] {1 ,2, 3}
           });
           int[][] expectedSquare = new int[3][]
           {
            new int[] {1},
            new int[] {1, 2},
            new int[] {1 ,2, 3}
           };

            SquareMatrix<int> actual = new SymmetricMatrix<int>(expectedSquare);
            CollectionAssert.AreEqual(expected, actual);
        }
        [Test]
        public void SquareMatrixSumTest()
        {
            Assert.AreEqual(expectedSquare, SquareMatrix.Sum(SquareMatrix));
        }

        [Test]
        public void DiagonalMatrixSumTest()
        {
            int[] array = new int[] { 1, 2 };
            int[] ex = new int[] { 2, 4 };
            DiagonalMatrix<int> expected = new DiagonalMatrix<int>(ex);
            DiagonalMatrix<int> actual = new DiagonalMatrix<int>(array);

            Assert.AreEqual(expected, actual.Sum(actual));
        }
        [Test]
        public void SymetricMatrixSumTest()
        {
           int[][] expectedSymmetricMatrix = new int[3][]
           {
            new int[] {1},
            new int[] {1, 2},
            new int[] {1 ,2, 3}
           };

            SquareMatrix<int> expected = new SymmetricMatrix<int>(expectedSymmetricMatrix);
            SquareMatrix<int> actual = new SymmetricMatrix<int>(expectedSymmetricMatrix);
            Assert.AreEqual(expected, actual);
        }
    }
}
