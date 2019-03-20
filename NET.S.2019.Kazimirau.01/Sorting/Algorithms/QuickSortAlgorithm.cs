namespace Algorithms
{
    /// <summary>
    /// Concrete implementation of SortingAlgorithm strategy
    /// </summary>
    public class QuickSortAlgorithm : SortingAlgorithm
    {
        /// <summary>
        /// Constructor which initialize protected field _arr through base class
        /// </summary>
        /// <param name="arr"> array to sort </param>
        public QuickSortAlgorithm(int[] arr) : base(arr)
        {
        }

        /// <summary>
        /// Main algorithm interface
        /// </summary>
        public override void Sort()
        {
            QuickSort(_arr, 0, _arr.Length - 1);
        }

        /// <summary>
        /// Quick sort algorithm's implementation (the simpliest you can find)
        /// </summary>
        /// <param name="arr"> array to sort </param>
        /// <param name="leftIdx"> most left index </param>
        /// <param name="rightIdx"> most right index </param>
        private void QuickSort(int[] arr, int leftIdx, int rightIdx)
        {
            // Calculate pivot element
            int pivot = arr[(leftIdx + rightIdx) / 2];
            int i = leftIdx;
            int j = rightIdx;

            do
            {
                while ((arr[i] < pivot) && (i < rightIdx))
                    ++i;
                while ((arr[j] > pivot) && (j > leftIdx))
                    --j;
                if (i <= j)
                {
                    if (arr[i] != arr[j])
                    {
                        arr[i] ^= arr[j];
                        arr[j] ^= arr[i];
                        arr[i] ^= arr[j];
                    }
                    ++i;
                    --j;
                }
            } while (i <= j);

            if (leftIdx < j)
                QuickSort(arr, leftIdx, j);
            if (i < rightIdx)
                QuickSort(arr, i, rightIdx);
        }
    }
}
