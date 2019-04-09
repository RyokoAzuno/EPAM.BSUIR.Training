using Algorithms;
using System;
using System.Diagnostics;

namespace AlgorithmsClient
{
    /// <summary>
    /// Client for testing sorting algorithms strategies
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            int[] array1Int32 = { -2, 5, -1, 3, 1, 2, -3, 4, 0 };
            int[] array2Int32 = { -8, 5, -1, 33, 81, -2, -3, 4, 0 };

            double[] array1Double = { -6.2, 5.82, -11.56, 13.34, 1.8, 2.98, -13.46, 4.34, 0.0 };
            double[] array2Double = { -18.34, 25.245, -31.3, 33.53, 81.535, -12.13, -3.04, 4.532, 0.1353 };

            //SortingContext<int> sortingContext = new SortingContext<int>(new QuickSortAlgorithm<int>(SortingAlgorithm<int>.CreateRandomArray(20000000))); // ~6000 ms
            SortingContext<int> sortingContextInt32 = new SortingContext<int>(new QuickSortAlgorithm<int>(array1Int32));
            SortingContext<double> sortingContextDouble = new SortingContext<double>(new QuickSortAlgorithm<double>(array1Double));

            Stopwatch sw = new Stopwatch();

            #region Int32 Sorting
            Console.WriteLine("Quicksort(Int32):");
            sw.Start();
            sortingContextInt32.Sort();
            sw.Stop();
            sortingContextInt32.Show();

            Console.WriteLine($"\nTotal time: {sw.Elapsed.TotalMilliseconds.ToString("0.00 ms")}");

            sw.Reset();
            Console.WriteLine();

            Console.WriteLine("Mergesort(Int32):");
            //sortingContext.SetAlgorithm<int>(new MergeSortAlgorithm<int>(SortingAlgorithm<int>.CreateRandomArray(20000000))); // ~11000 ms
            sortingContextInt32.SetAlgorithm(new MergeSortAlgorithm<int>(array2Int32));

            sw.Start();
            sortingContextInt32.Sort();
            sw.Stop();
            sortingContextInt32.Show();

            Console.WriteLine($"\nTotal time: {sw.Elapsed.TotalMilliseconds.ToString("0.00 ms")}");
            #endregion
            Console.WriteLine("*****************************");
            #region Double Sorting
            sw.Reset();
            Console.WriteLine("Quicksort(Double):");
            sw.Start();
            sortingContextDouble.Sort();
            sw.Stop();
            sortingContextDouble.Show();

            Console.WriteLine($"\nTotal time: {sw.Elapsed.TotalMilliseconds.ToString("0.00 ms")}");

            sw.Reset();
            Console.WriteLine();

            Console.WriteLine("Mergesort(Double):");
            //sortingContext.SetAlgorithm<double>(new MergeSortAlgorithm<double>(SortingAlgorithm<double>.CreateRandomArray(20000000))); // ~11000 ms
            sortingContextDouble.SetAlgorithm(new MergeSortAlgorithm<double>(array2Double));

            sw.Start();
            sortingContextDouble.Sort();
            sw.Stop();
            sortingContextDouble.Show();

            Console.WriteLine($"\nTotal time: {sw.Elapsed.TotalMilliseconds.ToString("0.00 ms")}");
            #endregion
            Console.ReadLine();
        }

    }
}
