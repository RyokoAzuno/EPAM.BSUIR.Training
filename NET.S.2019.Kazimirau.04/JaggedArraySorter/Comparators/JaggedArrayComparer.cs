using System.Collections.Generic;
using System.Linq;

namespace JaggedArraySorter.Comparators
{
    /// <summary>
    /// Enum for keeping comparisons
    /// </summary>
    public enum SortBy
    {
        AscSum,
        DescSum,
        AscMax,
        DescMax,
        AscMin,
        DescMin
    }

    /// <summary>
    /// Class comparator for sorting JaggedArray
    /// </summary>
    public class JaggedArrayComparer : IComparer<int[]>
    {
        private SortBy _comparer;

        public JaggedArrayComparer()
        {
            _comparer = SortBy.AscSum;
        }

        public SortBy Comparer
        {
            get
            {
                return _comparer;
            }

            set
            {
                _comparer = value;
            }
        }

        public int Compare(int[] arr1, int[] arr2)
        {
            switch (_comparer)
            {
                case SortBy.DescSum:
                    {
                        return arr2.Sum().CompareTo(arr1.Sum());
                    }

                case SortBy.AscMax:
                    {
                        return arr1.Max().CompareTo(arr2.Max());
                    }

                case SortBy.DescMax:
                    {
                        return arr2.Max().CompareTo(arr1.Max());
                    }

                case SortBy.AscMin:
                    {
                        return arr1.Min().CompareTo(arr2.Min());
                    }

                case SortBy.DescMin:
                    {
                        return arr2.Min().CompareTo(arr1.Min());
                    }

                default: break;
            }

            return arr1.Sum().CompareTo(arr2.Sum());
        }
    }
}
