namespace Matrices
{
    public class SquareMatrix<T> where T: struct
    {
        private T[,] _matrix;

        public SquareMatrix(int order)
        {
            _matrix = new T[order, order];
        }

        public SquareMatrix(int order, T[,] arr)
        {
            _matrix = new T[order, order];

            for (int outer = arr.GetLowerBound(0); outer <= arr.GetUpperBound(0); outer++)
            {
                for (int inner = arr.GetLowerBound(1); inner <= arr.GetUpperBound(1); inner++)
                {
                    _matrix[outer, inner] = arr[outer, inner];
                }
            }
        }

        public T this[int i, int j]
        {
            get
            {
                return _matrix[i, j];
            }
            set
            {
                _matrix[i, j] = value;
            }
        }

        public SquareMatrix<T> Add(SquareMatrix<T> m)
        {
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
    }
}
