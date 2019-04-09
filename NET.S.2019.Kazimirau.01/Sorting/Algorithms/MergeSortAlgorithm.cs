using System;

namespace Algorithms
{
    /// <summary>
    /// Concrete strategy for MergeSort algorithm
    /// </summary>
    public class MergeSortAlgorithm<T> : SortingAlgorithm<T> where T: struct, IComparable<T>
    {
        /// <summary>
        /// Auxiliary array for keeping merged sub-arrays
        /// </summary>
        private T[] _aux;

        /// <summary>
        /// Constructor which initialize protected field _arr through base class
        /// </summary>
        /// <param name="arr"> array to sort </param>
        public MergeSortAlgorithm(T[] arr) : base(arr)
        {
            _aux = BuildAuxArray();
        }

        /// <summary>
        /// Main algorithm interface is a wrapper for MergeSort method
        /// </summary>
        public override void Sort() => MergeSort(0, _arr.Length - 1);

        /// <summary>
        /// Classical Top-Down Mergesort algorithm's implementation
        /// </summary>
        /// <param name="leftIdx"> left index </param>
        /// <param name="rightIdx"> right index </param>
        private void MergeSort(int leftIdx, int rightIdx)
        {
            if (leftIdx >= rightIdx)
                return;
            // Calculate middle element without overflow
            int mid = leftIdx + (rightIdx - leftIdx) / 2;
            // Recursively split and merge left and right parts on every step
            MergeSort(leftIdx, mid);
            MergeSort(mid + 1, rightIdx);
            Merge(leftIdx, mid, rightIdx);
        }

        /// <summary>
        /// Merge two sub-arrays into one array
        /// </summary>
        /// <param name="leftIdx"> left index </param>
        /// <param name="mid"> middle index </param>
        /// <param name="rightIdx"> right index </param>
        private void Merge(int leftIdx, int mid, int rightIdx)
        {
            for (int k = leftIdx; k <= rightIdx; k++)
            {
                _aux[k] = _arr[k];
            }

            int i = leftIdx;
            int j = mid + 1;

            for (int k = leftIdx; k <= rightIdx; k++)
            {
                if (i > mid)
                    _arr[k] = _aux[j++];
                else if (j > rightIdx)
                    _arr[k] = _aux[i++];
                else if (_aux[j].CompareTo(_aux[i]) < 0)
                    _arr[k] = _aux[j++];
                else
                    _arr[k] = _aux[i++];
            }
        }

        /// <summary>
        /// Create an auxiliary array
        /// </summary>
        /// <returns> new auxiliary array </returns>
        private T[] BuildAuxArray()
        {
            _aux = new T[_arr.Length];

            for (int i = 0; i < _arr.Length; i++)
            {
                _aux[i] = _arr[i];
            }

            return _aux;
        }
    }
}
