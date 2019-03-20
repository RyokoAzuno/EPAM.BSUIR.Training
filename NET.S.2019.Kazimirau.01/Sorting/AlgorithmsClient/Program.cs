using Algorithms;
using System;

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
            Console.WriteLine("Quicksort:");
            SortingAlgorithm alg = new QuickSortAlgorithm(array1);
            alg.Sort();
            alg.Show();

            Console.WriteLine();

            Console.WriteLine("Mergesort:");
            alg = new MergeSortAlgorithm(array2);
            alg.Sort();
            alg.Show();

            Console.ReadLine();
        }
    }
}
