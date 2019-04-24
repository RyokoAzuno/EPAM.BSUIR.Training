using System;
using System.Collections.Generic;

namespace Matrices
{
    // Class represents symmetric matrix
    public class SymmetricMatrix<T> : SquareMatrix<T> where T : struct
    {
        public SymmetricMatrix(int order) : base(order)
        {
        }

        public SymmetricMatrix(T[] arr) : base(arr)
        {
            if(!IsSymmetric())
            {
                throw new Exception("Not a symmetric matrix!");
            }
        }

        public SymmetricMatrix(T[,] arr) : base(arr)
        {
            if (!IsSymmetric())
            {
                throw new Exception("Not a symmetric matrix!");
            }
        }

        private bool IsSymmetric()
        {
            for (int outer = _matrix.GetLowerBound(0); outer <= _matrix.GetUpperBound(0); outer++)
            {
                for (int inner = _matrix.GetLowerBound(1); inner <= _matrix.GetUpperBound(1); inner++)
                {
                    if (!EqualityComparer<T>.Default.Equals(_matrix[outer, inner], _matrix[inner, outer]))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
