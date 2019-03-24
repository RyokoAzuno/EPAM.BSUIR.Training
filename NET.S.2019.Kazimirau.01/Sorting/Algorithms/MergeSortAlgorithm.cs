namespace Algorithms
{
    public class MergeSortAlgorithm : SortingAlgorithm
    {
        /// <summary>
        /// Auxiliary array for keeping merged sub-arrays
        /// </summary>
        private int[] _aux;

        /// <summary>
        /// Constructor which initialize protected field _arr through base class
        /// </summary>
        /// <param name="arr"> array to sort </param>
        public MergeSortAlgorithm(int[] arr) : base(arr)
        {
        }

        /// <summary>
        /// Main algorithm interface is a wrapper for MergeSort method
        /// </summary>
        public override void Sort()
        {
            _aux = BuildAuxArray(_arr);
            MergeSort(_arr, 0, _arr.Length - 1);
        }

        /// <summary>
        /// Classical Top-Down Mergesort algorithm's implementation
        /// </summary>
        /// <param name="arr"> array to sort</param>
        /// <param name="leftIdx"> left index </param>
        /// <param name="rightIdx"> right index </param>
        private void MergeSort(int[] arr, int leftIdx, int rightIdx)
        {
            if (leftIdx >= rightIdx)
                return;
            // Calculate middle element
            int mid = leftIdx + (rightIdx - leftIdx) / 2;
            // Recursively split and merge left and right parts on every step
            MergeSort(arr, leftIdx, mid);
            MergeSort(arr, mid + 1, rightIdx);
            Merge(arr, leftIdx, mid, rightIdx);
        }

        /// <summary>
        /// Merge two sub-arrays into one array
        /// </summary>
        /// <param name="arr"> array </param>
        /// <param name="leftIdx"> left index </param>
        /// <param name="mid"> middle index </param>
        /// <param name="rightIdx"> right index </param>
        private void Merge(int[] arr, int leftIdx, int mid, int rightIdx)
        {
            for (int k = leftIdx; k <= rightIdx; k++)
            {
                _aux[k] = arr[k];
            }

            int i = leftIdx;
            int j = mid + 1;

            for (int k = leftIdx; k <= rightIdx; k++)
            {
                if (i > mid)
                    arr[k] = _aux[j++];
                else if (j > rightIdx)
                    arr[k] = _aux[i++];
                else if (_aux[j] < _aux[i])
                    arr[k] = _aux[j++];
                else
                    arr[k] = _aux[i++];
            }
        }

        /// <summary>
        /// Create auxiliary array
        /// </summary>
        /// <param name="arr"> source array </param>
        /// <returns> new auxiliary array </returns>
        private int[] BuildAuxArray(int[] arr)
        {
            int[] aux = new int[arr.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                aux[i] = arr[i];
            }

            return aux;
        }
    }
}
