using System;

namespace BinarySearch
{
    public class BinarySearch
    {
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
                int mid = lo + (hi - lo) / 2;
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
