﻿using System;

namespace JaggedArraySorter
{
    /// <summary>
    /// Enum for keeping comparisons
    /// </summary>
    public enum Comparisons
    {
        AscSum,
        DescSum,
        AscMax,
        DescMax,
        AscMin,
        DescMin
    }

    public class JaggedArraySorter
    {
        /// <summary>
        /// Sort each row of the jagged array
        /// </summary>
        /// <param name="arr"> Array to sort </param>
        public static void Sort(int[][] arr, Func<int, int, bool> comparison)
        {
            for (int i = 0; i < arr.Length; ++i)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    for (int k = j + 1; k < arr[i].Length; k++)
                    {
                        if (comparison(arr[i][j], arr[i][k]))
                            Swap(arr[i], j, k);
                    }
                }
            }
        }
        /// <summary>
        /// Swap rows of the array
        /// </summary>
        /// <param name="arr"> Jagged array </param>
        /// <param name="comparison"> Criteria of swapping</param>
        public static void SortRows(int[][] arr, Comparisons comparison/*, Func<Func<int[]>, bool> comparison*/)
        {
            for (int i = 0; i < arr.Length; ++i)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    switch(comparison)
                    {
                        case Comparisons.AscSum: {
                            if (GetArraySum(arr[i]) > GetArraySum(arr[j]))
                                SwapRows(ref arr[i], ref arr[j]);
                            } break;
                        case Comparisons.DescSum:
                            {
                                if (GetArraySum(arr[i]) < GetArraySum(arr[j]))
                                    SwapRows(ref arr[i], ref arr[j]);
                            } break;
                        case Comparisons.AscMax:
                            {
                                if (GetArrayMaxElement(arr[i]) > GetArrayMaxElement(arr[j]))
                                    SwapRows(ref arr[i], ref arr[j]);
                            }
                            break;
                        case Comparisons.DescMax:
                            {
                                if (GetArrayMaxElement(arr[i]) < GetArrayMaxElement(arr[j]))
                                    SwapRows(ref arr[i], ref arr[j]);
                            }
                            break;
                        case Comparisons.AscMin:
                            {
                                if (GetArrayMinElement(arr[i]) > GetArrayMinElement(arr[j]))
                                    SwapRows(ref arr[i], ref arr[j]);
                            }
                            break;
                        case Comparisons.DescMin:
                            {
                                if (GetArrayMinElement(arr[i]) < GetArrayMinElement(arr[j]))
                                    SwapRows(ref arr[i], ref arr[j]);
                            }
                            break;
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
        /// <param name="rowA"> Firest row to swap </param>
        /// <param name="rowB"> Second row to swap </param>
        private static void SwapRows(ref int[] rowA, ref int[] rowB)
        {
            int[] rowTmp = rowA;
            rowA = rowB;
            rowB = rowTmp;
        }

        private static int GetArraySum(int[] arr)
        {
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }
            return sum;
        }

        private static int GetArrayMaxElement(int[] arr)
        {
            int max = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (max < arr[i])
                    max = arr[i];
            }
            return max;
        }

        private static int GetArrayMinElement(int[] arr)
        {
            int min = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (min > arr[i])
                    min = arr[i];
            }
            return min;
        }
    }
}