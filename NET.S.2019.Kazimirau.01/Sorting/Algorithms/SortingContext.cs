using System;

namespace Algorithms
{
    /// <summary>
    /// Context class, using a concrete strategy for sorting algorithms
    /// </summary>
    public class SortingContext<T> where T: struct, IComparable<T>
    {
        /// <summary>
        /// Reference to a concrete sorting strategy that allows to change concrete implementation
        /// </summary>
        private SortingAlgorithm<T> _sortingAlgorithm;

        // Not necessary!!!!!(only for tests simplification)
        public SortingContext()
        {
        }

        /// <summary>
        /// Constructor for initializing a sorting strategy
        /// </summary>
        /// <param name="sortingAlgorithm"> Concrete sorting strategy </param>
        public SortingContext(SortingAlgorithm<T> sortingAlgorithm)
        {
            _sortingAlgorithm = sortingAlgorithm ?? throw new ArgumentNullException();
        }

        /// <summary>
        /// Method that allows to set a new sorting strategy on runtime
        /// </summary>
        /// <param name="sortingAlgorithm"> New sorting strategy </param>
        public void SetAlgorithm(SortingAlgorithm<T> sortingAlgorithm)
        {
            _sortingAlgorithm = sortingAlgorithm ?? throw new ArgumentNullException();
        }

        /// <summary>
        /// Execute a sorting algorithm depends on concrete sorting strategy
        /// </summary>
        public void Sort()
        {
            _sortingAlgorithm.Sort();
        }

        /// <summary>
        /// Execute a printing algorithm
        /// </summary>
        public void Show()
        {
            _sortingAlgorithm.Show();
        }
    }
}
