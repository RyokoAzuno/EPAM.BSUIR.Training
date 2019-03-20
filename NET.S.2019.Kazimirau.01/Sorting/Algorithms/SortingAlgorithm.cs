using System;

namespace Algorithms
{
    public abstract class SortingAlgorithm
    {
        /// <summary>
        /// Array which refers to array we want to sort
        /// </summary>
        protected int[] _arr;

        /// <summary>
        /// Constructor which initialize encapsulated array _arr
        /// </summary>
        /// <param name="arr"> array to sort </param>
        public SortingAlgorithm(int[] arr)
        {
            _arr = arr;
        }

        /// <summary>
        /// Sorting method which depends on concrete strategy
        /// </summary>
        public abstract void Sort();

        /// <summary>
        /// Print all elements of the array to console
        /// </summary>
        public void Show()
        {
            foreach (var item in _arr)
            {
                Console.Write($" {item} ");
            }
        }
    }
}
