using Algorithms;
using System;
using System.Diagnostics;

namespace AlgorithmsClient
{
    /// <summary>
    /// Client for testing our sorting algorithms
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            int[] array1 = { -2, 5, -1, 3, 1, 2, -3, 4, 0 };
            int[] array2 = { -8, 5, -1, 33, 81, -2, -3, 4, 0 };
            Stopwatch sw = new Stopwatch();
            Console.WriteLine("Quicksort:");
            //SortingAlgorithm alg = new QuickSortAlgorithm(SortingAlgorithm.CreateRandomArray(20000000)); // ~6000 ms
            SortingAlgorithm alg = new QuickSortAlgorithm(array1);
            sw.Start();
            alg.Sort();
            sw.Stop();
            alg.Show();
            Console.WriteLine($"\nTotal time: {sw.Elapsed.TotalMilliseconds.ToString("0.00 ms")}");

            sw.Reset();
            Console.WriteLine();

            Console.WriteLine("Mergesort:");
            //alg = new MergeSortAlgorithm(SortingAlgorithm.CreateRandomArray(20000000)); //~11000 ms
            alg = new MergeSortAlgorithm(array2);
            sw.Start();
            alg.Sort();
            sw.Stop();
            alg.Show();
            Console.WriteLine($"\nTotal time: {sw.Elapsed.TotalMilliseconds.ToString("0.00 ms")}");

            Console.ReadLine();
        }
    }
}
