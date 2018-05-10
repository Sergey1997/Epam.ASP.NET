using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace MatrixLogic.Tests
{
    public class MatrixMoqTest
    {
        public void IndexViewModelNotNull()
        {
            SquareMatrix<double> square = new SquareMatrix<double>(3);
            Calculater<double> visitor = new Calculater<double>(square);

            Mock<SquareMatrix<double>> mock = new Mock<SquareMatrix<double>>();
            mock.Setup(m => m.Accept(visitor));

            DiagonalMatrix<double> matrix = new DiagonalMatrix<double>(mock.Object.Size);

        }

    }
}
