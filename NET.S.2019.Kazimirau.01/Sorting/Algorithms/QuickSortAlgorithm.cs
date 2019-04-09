using System;

namespace Algorithms
{
    /// <summary>
    /// Concrete strategy for QuickSort algorithm
    /// </summary>
    public class QuickSortAlgorithm<T> : SortingAlgorithm<T> where T: struct, IComparable<T>
    {
        /// <summary>
        /// Constructor which initialize protected field _arr through base class
        /// </summary>
        /// <param name="arr"> array to sort </param>
        public QuickSortAlgorithm(T[] arr) : base(arr)
        {
        }

        /// <summary>
        /// Main algorithm interface is a wrapper for QuickSort method
        /// </summary>
        public override void Sort()
        {
            QuickSort(0, _arr.Length - 1);
        }

        /// <summary>
        /// Quick sort algorithm's implementation (the simpliest you can find)
        /// </summary>
        /// <param name="arr"> array to sort </param>
        /// <param name="leftIdx"> most left index </param>
        /// <param name="rightIdx"> most right index </param>
        private void QuickSort(int leftIdx, int rightIdx)
        {
            // Calculate pivot element
            T pivot = _arr[leftIdx + (rightIdx - leftIdx) / 2];
            int i = leftIdx;
            int j = rightIdx;

            do
            {
                while ((_arr[i].CompareTo(pivot) < 0) && (i < rightIdx))
                    ++i;
                while ((_arr[j].CompareTo(pivot) > 0) && (j > leftIdx))
                    --j;
                if (i <= j)
                {
                    if (_arr[i].CompareTo(_arr[j]) != 0)
                    {
                        Swap(i, j);
                    }
                    ++i;
                    --j;
                }
            } while (i <= j);

            if (leftIdx < j)
                QuickSort(leftIdx, j);
            if (i < rightIdx)
                QuickSort(i, rightIdx);
        }
    }
}
