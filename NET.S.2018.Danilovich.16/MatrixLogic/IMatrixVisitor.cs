﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLogic
{
    public interface IMatrixVisitor<T>
    {
        SquareMatrix<T> Visit(SquareMatrix<T> matrix);

        SymmetricMatrix<T> Visit(SymmetricMatrix<T> matrix);

        DiagonalMatrix<T> Visit(DiagonalMatrix<T> matrix);
    }
}
