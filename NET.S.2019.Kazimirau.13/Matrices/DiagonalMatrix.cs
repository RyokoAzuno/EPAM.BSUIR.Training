using System;
using System.Collections.Generic;

namespace Matrices
{
    public class DiagonalMatrix<T> : SquareMatrix<T> where T : struct
    {
        public DiagonalMatrix(T[] arr) : base(arr)
        {
            if(!IsDiagonal())
            {
                throw new Exception("Not a diagonal matrix!");
            }
        }

        public DiagonalMatrix(T[,] arr) : base(arr)
        {
            if (!IsDiagonal())
            {
                throw new Exception("Not a diagonal matrix!");
            }
        }

        private bool IsDiagonal()
        {
            for (int outer = _matrix.GetLowerBound(0); outer <= _matrix.GetUpperBound(0); outer++)
            {
                for (int inner = _matrix.GetLowerBound(1); inner <= _matrix.GetUpperBound(1); inner++)
                {
                    if(outer != inner)
                    {
                        if(!EqualityComparer<T>.Default.Equals(_matrix[outer, inner], default(T)))
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }
    }
}
