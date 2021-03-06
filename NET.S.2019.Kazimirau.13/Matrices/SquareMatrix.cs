﻿using System;
using System.Threading;

namespace Matrices
{
    // Class represents square matrix
    public class SquareMatrix<T> where T : struct
    {
        protected T[,] _matrix;

        public event EventHandler<MatrixEventArgs> ChangeIndex;

        public SquareMatrix(int order)
        {
            if(order <= 0)
            {
                throw new ArgumentException();
            }

            _matrix = new T[order, order];
        }

        /// <summary>
        /// Constructor builds the square matrix from one dim. array if it's possible 
        /// </summary>
        /// <param name="arr"> One dimentional array </param>
        public SquareMatrix(T[] arr)
        {
            if (arr == null || arr.Length == 0)
            {
                throw new ArgumentException("Array Can't be null or empty");
            }

            int order = GetOrder(arr.Length);

            // Get order(if possible) of the number
            int GetOrder(int n)
            {
                if (n == 0 || n == 1)
                {
                    return -1;
                }
                else
                {
                    int root = 2;
                    while(root < n / 2)
                    {
                        if(root * root == n)
                        {
                            return root;
                        }

                        ++root;
                    }
                }

                return -1;
            }

            if(order != -1)
            {
                _matrix = new T[order, order];
                int idx = 0;
                for (int outer = _matrix.GetLowerBound(0); outer <= _matrix.GetUpperBound(0); outer++)
                {
                    for (int inner = _matrix.GetLowerBound(1); inner <= _matrix.GetUpperBound(1); inner++)
                    {
                        _matrix[outer, inner] = arr[idx++];
                    }
                }
            }
            
        }

        /// <summary>
        /// Constructor builds the square matrix from two dim. array
        /// </summary>
        /// <param name="arr"></param>
        public SquareMatrix(T[,] arr)
        {
            if (arr == null)
            {
                throw new ArgumentException("Array Can't be null");
            }

            int order = arr.GetUpperBound(0) + 1;

            _matrix = new T[order, order];

            for (int outer = arr.GetLowerBound(0); outer <= arr.GetUpperBound(0); outer++)
            {
                for (int inner = arr.GetLowerBound(1); inner <= arr.GetUpperBound(1); inner++)
                {
                    _matrix[outer, inner] = arr[outer, inner];
                }
            }
        }

        // Indexer
        public T this[int i, int j]
        {
            get
            {
                return _matrix[i, j];
            }
            set
            {
                _matrix[i, j] = value;
                OnIndexChange(new MatrixEventArgs(i, j));
            }
        }
        
        // Convert matrix into two dimentional array
        public T[,] ToArray()
        {
            int order = _matrix.GetUpperBound(0) + 1;
            T[,] arr = new T[order, order];

            for (int outer = _matrix.GetLowerBound(0); outer <= _matrix.GetUpperBound(0); outer++)
            {
                for (int inner = _matrix.GetLowerBound(1); inner <= _matrix.GetUpperBound(1); inner++)
                {
                    arr[outer, inner] = _matrix[outer, inner];
                }
            }

            return arr;
        }

        public static SquareMatrix<T> operator +(SquareMatrix<T> m1, SquareMatrix<T> m2)
        {
            return m1.Add(m2);
        }

        protected virtual void OnIndexChange(MatrixEventArgs e)
        {
            Volatile.Read(ref ChangeIndex)?.Invoke(this, e);
        }

        // Add two matrices
        private SquareMatrix<T> Add(SquareMatrix<T> m)
        {
            if (m == null)
            {
                throw new ArgumentNullException();
            }

            int order = _matrix.GetUpperBound(0) + 1;
            SquareMatrix<T> result = new SquareMatrix<T>(order);

            for (int outer = _matrix.GetLowerBound(0); outer <= _matrix.GetUpperBound(0); outer++)
            {
                for (int inner = _matrix.GetLowerBound(1); inner <= _matrix.GetUpperBound(1); inner++)
                {
                    dynamic d1 = _matrix[outer, inner];
                    dynamic d2 = m[outer, inner];
                    result[outer, inner] = d1 + d2;
                }
            }

            return result;
        }
    }
}
