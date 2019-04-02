namespace Algorithms
{
    /// <summary>
    /// Concrete strategy for SelectionSort algorithm
    /// </summary>
    public class SelectionSortAlgorithm : SortingAlgorithm
    {
        /// <summary>
        /// Constructor which initialize protected field _arr through base class
        /// </summary>
        /// <param name="arr"> array to sort </param>
        public SelectionSortAlgorithm(int[] arr) : base(arr)
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
        private void SelectionSort(int[] arr)
        {
            for (int i = 0; i < arr.Length; ++i)
            {
                int min = i;
                for (int j = i + 1; j < arr.Length; ++j)
                {
                    if (arr[j] < arr[min])
                        min = j;
                }

                if(arr[i] != arr[min])
                    Swap(i, min);
            }
        }
    }
}
