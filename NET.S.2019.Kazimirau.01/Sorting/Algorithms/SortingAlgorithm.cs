﻿using System;

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

        /// <summary>
        /// Generate random array
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
    }
}