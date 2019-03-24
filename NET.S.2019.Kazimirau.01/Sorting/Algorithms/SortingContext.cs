using System;

namespace Algorithms
{
    public class SortingContext
    {
        private SortingAlgorithm _sortingAlgorithm;

        public SortingContext()
        {
        }

        public SortingContext(SortingAlgorithm sortingAlgorithm)
        {
            _sortingAlgorithm = sortingAlgorithm ?? throw new ArgumentNullException();
        }

        public void SetAlgorithm(SortingAlgorithm sortingAlgorithm)
        {
            _sortingAlgorithm = sortingAlgorithm ?? throw new ArgumentNullException();
        }

        public void Sort()
        {
            _sortingAlgorithm.Sort();
        }

        public void Show()
        {
            _sortingAlgorithm.Show();
        }
    }
}
