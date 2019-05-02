using System;

namespace BinarySearch
{
    /// <summary>
    /// Binary search algorithm
    /// </summary>
    public class BinarySearch
    {
        /// <summary>
        /// Method implements binary search algorithm
        /// </summary>
        /// <typeparam name="T"> Generic type </typeparam>
        /// <param name="key"> Key to find </param>
        /// <param name="arr"> Sorted generic array </param>
        /// <returns></returns>
        public static int Search<T>(IComparable<T> key, T[] arr)
        {
            if (arr == null || (key is IComparable<T>) == false)
            {
                throw new ArgumentNullException();
            }

            int lo = 0;
            int hi = arr.Length - 1;

            while (lo <= hi)
            {
                int mid = lo + ((hi - lo) / 2);
                if (key.CompareTo(arr[mid]) < 0)
                {
                    hi = mid - 1;
                }
                else if (key.CompareTo(arr[mid]) > 0)
                {
                    lo = mid + 1;
                }
                else
                {
                    return mid;
                }
            }

            return -1;
        }
    }
}
