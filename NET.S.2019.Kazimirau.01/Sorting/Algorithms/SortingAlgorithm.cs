using System;
using System.Runtime.InteropServices;

namespace Algorithms
{
    [StructLayout(LayoutKind.Explicit)]
    public struct MagicBox
    {
        [FieldOffset(0)]
        public double d;
        [FieldOffset(0)]
        public long l;
    };

    /// <summary>
    /// Define an abstract base strategy class for sorting strategies
    /// </summary>
    public abstract class SortingAlgorithm
    {
        /// <summary>
        /// An array which refers to array we want to sort
        /// </summary>
        protected int[] _arr;

        /// <summary>
        /// Constructor which initialize encapsulated array _arr
        /// </summary>
        /// <param name="arr"> array to sort </param>
        public SortingAlgorithm(int[] arr)
        {
            _arr = arr ?? throw new ArgumentNullException();
        }

        /// <summary>
        /// Sorting method which depends on concrete strategy
        /// </summary>
        public abstract void Sort();

        /// <summary>
        /// Prints all elements of the array to console
        /// </summary>
        public void Show()
        {
            foreach (var item in _arr)
            {
                Console.Write($" {item} ");
            }
        }

        /// <summary>
        /// Generate a random array of integers
        /// </summary>
        /// <param name="size"> size of the random array</param>
        /// <returns> new random array </returns>
        public static int[] CreateRandomArray(int size)
        {
            int[] arr = new int[size];
            Random rnd = new Random();

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(-size, size);
            }

            return arr;
        }

        protected void Swap(int i, int j)
        {
            _arr[i] ^= _arr[j];
            _arr[j] ^= _arr[i];
            _arr[i] ^= _arr[j];
        }

        //protected void Swap(int i, int j)
        //{
        //    if (i != j)
        //    {
        //        MagicBox mb1 = new MagicBox
        //        {
        //            d = i
        //        };
        //        MagicBox mb2 = new MagicBox
        //        {
        //            d = j
        //        };
        //        mb1.l ^= mb2.l;
        //        mb2.l ^= mb1.l;
        //        mb1.l ^= mb2.l;
        //        i = mb1.d;
        //        j = mb2.d;
        //    }
        //}
    }
}
