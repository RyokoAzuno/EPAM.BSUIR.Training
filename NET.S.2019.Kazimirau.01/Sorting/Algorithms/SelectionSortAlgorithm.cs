using System;

namespace Algorithms
{
    /// <summary>
    /// Concrete strategy for SelectionSort algorithm
    /// </summary>
    public class SelectionSortAlgorithm<T> : SortingAlgorithm<T> where T: struct, IComparable<T>
    {
        /// <summary>
        /// Constructor which initialize protected field _arr through base class
        /// </summary>
        /// <param name="arr"> array to sort </param>
        public SelectionSortAlgorithm(T[] arr) : base(arr)
        {
        }

        /// <summary>
        /// Main algorithm interface is a wrapper for SelectionSort method
        /// </summary>
        public override void Sort()
        {
            SelectionSort(_arr);
        }

        /// <summary>
        /// Selection sort algorithm's implementation
        /// </summary>
        private void SelectionSort(T[] arr)
        {
            for (int i = 0; i < arr.Length; ++i)
            {
                int min = i;
                for (int j = i + 1; j < arr.Length; ++j)
                {
                    if (arr[j].CompareTo(arr[min]) < 0)
                        min = j;
                }

                if(arr[i].CompareTo(arr[min]) != 0)
                    Swap(i, min);
            }
        }
    }
}
