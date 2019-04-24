using System;

namespace Matrices
{
    public class MatrixEventArgs : EventArgs
    {
        private int _i;
        private int _j;

        public MatrixEventArgs(int i, int j)
        {
            _i = i;
            _j = j;
        }

        public int I
        {
            get { return _i; }
            set { _i = value; }
        }

        public int J
        {
            get { return _j; }
            set { _j = value; }
        }
    }
}
