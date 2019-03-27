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
            int[] array1 = { -2, 5, -1, 3, 1, 2, -3, 4, 0 };
            int[] array2 = { -8, 5, -1, 33, 81, -2, -3, 4, 0 };
            //SortingContext sortingContext = new SortingContext(new QuickSortAlgorithm(SortingAlgorithm.CreateRandomArray(20000000))); // ~6000 ms
            SortingContext sortingContext = new SortingContext(new QuickSortAlgorithm(array1));
            Stopwatch sw = new Stopwatch();

            Console.WriteLine("Quicksort:");
            sw.Start();
            sortingContext.Sort();
            sw.Stop();
            sortingContext.Show();

            Console.WriteLine($"\nTotal time: {sw.Elapsed.TotalMilliseconds.ToString("0.00 ms")}");

            sw.Reset();
            Console.WriteLine();

            Console.WriteLine("Mergesort:");
            //sortingContext.SetAlgorithm(new MergeSortAlgorithm(SortingAlgorithm.CreateRandomArray(20000000))); // ~11000 ms
            sortingContext.SetAlgorithm(new MergeSortAlgorithm(array2));

            sw.Start();
            sortingContext.Sort();
            sw.Stop();
            sortingContext.Show();

            Console.WriteLine($"\nTotal time: {sw.Elapsed.TotalMilliseconds.ToString("0.00 ms")}");

            Console.ReadLine();
        }
    }
}
