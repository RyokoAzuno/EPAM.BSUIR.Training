﻿using System;
using System.Collections.Generic;

namespace JaggedArraySorter
{
    /// <summary>
    /// Simple class for sorting rows of a jagged array and elements of the array
    /// by given criteria
    /// </summary>
    public class JaggedArrayDelegateSorter
    {
        /// <summary>
        /// Sort rows of the two dimensional array (Based on  delegates)
        /// </summary>
        public static void SortRows(int[][] arr, IComparer<int[]> comparison) 
                           => SortRows(arr, comparison.Compare);

        /// <summary>
        /// Sort each row of the jagged array
        /// </summary>
        /// <param name="arr"> Array to sort </param>
        public static void Sort(int[][] arr, Func<int, int, bool> comparison)
        {
            if (arr == null || comparison == null)
            {
                throw new ArgumentNullException();
            }

            for (int i = 0; i < arr.Length; ++i)
            {
                for (int j = 0; j < arr[i].Length - 1; j++)
                {
                    for (int k = j + 1; k < arr[i].Length; k++)
                    {
                        if (comparison(arr[i][j], arr[i][k]))
                        {
                            Swap(arr[i], j, k);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Sort rows of the two dimensional array (Based on delegates)
        /// </summary>
        /// <param name="arr"> Jagged array </param>
        /// <param name="comparison"> Criteria of swapping</param>
        private static void SortRows(int[][] arr, Func<int[], int[], int> comparison)
        {
            if (arr == null || comparison == null)
            {
                throw new ArgumentNullException();
            }

            for (int i = 0; i < arr.Length; ++i)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (comparison(arr[i], arr[j]) > 0)
                    {
                        SwapRows(ref arr[i], ref arr[j]);
                    }
                }
            }
        }

        /// <summary>
        /// Swap elements of a given array
        /// </summary>
        /// <param name="arr"> Array which elements must be swapped</param>
        /// <param name="j"> First index to swap </param>
        /// <param name="k"> Second index to swap </param>
        private static void Swap(int[] arr, int i, int j)
        {
            arr[i] ^= arr[j];
            arr[j] ^= arr[i];
            arr[i] ^= arr[j];
        }

        /// <summary>
        /// Swap rows of a given array
        /// </summary>
        /// <param name="rowA"> First row to swap </param>
        /// <param name="rowB"> Second row to swap </param>
        private static void SwapRows(ref int[] rowA, ref int[] rowB)
        {
            int[] rowTmp = rowA;
            rowA = rowB;
            rowB = rowTmp;
        }
    }
}
