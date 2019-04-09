using System;

namespace Algorithms
{
    /// <summary>
    /// Concrete strategy for BubbleSort algorithm
    /// </summary>
    public class BubbleSortAlgorithm<T> : SortingAlgorithm<T> where T: struct, IComparable<T>
    {
        /// <summary>
        /// Constructor which initialize protected field _arr through base class
        /// </summary>
        /// <param name="arr"> array to sort </param>
        public BubbleSortAlgorithm(T[] arr) : base(arr)
        {
        }

        /// <summary>
        /// Main algorithm interface is a wrapper for BubbleSort method
        /// </summary>
        public override void Sort()
        {
            BubbleSort(_arr);
        }

        /// <summary>
        /// Bubble sort algorithm's implementation
        /// </summary>
        private void BubbleSort(T[] arr)
        {
            for (int i = 0; i < arr.Length - 1; ++i)
            {
                for (int j = arr.Length - 1; j > i; --j)
                {
                    if (arr[j - 1].CompareTo(arr[j]) > 0)
                        Swap(j - 1, j);
                }
            }
        }
    }
}
