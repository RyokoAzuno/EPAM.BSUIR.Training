﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Tasks.Day02
{
    /// <summary>
    /// Class wrapper for tasks
    /// </summary>
    public static class Tasks
    {
        #region InsertNumber
        /// <summary>
        /// Insert bits(from i to j) from second number into first number
        /// </summary>
        /// <param name="a"> a first number </param>
        /// <param name="b"> a second number </param>
        /// <param name="i"> a first bit index </param>
        /// <param name="j"> a second bit index </param>
        /// <returns> new integer number </returns>
        public static int InsertNumber(int a, int b, int i, int j)
        {
            if (i < 0 || j > 31)
            {
                throw new IndexOutOfRangeException();
            }

            int[] bits = GetBitsFromNumber(b, i, j);
            int result = SetBitsInNumber(a, bits, i, j);

            return result;
        }

        /// <summary>
        /// Insert bits by LINQ
        /// </summary>
        public static int InsertNumberLINQ(int a, int b, int i, int j)
        {
            if (i < 0 || j > 31)
            {
                throw new IndexOutOfRangeException();
            }

            string result = string.Empty;
            string numA = new string(Convert.ToString(a, 2).PadLeft(32, '0').Reverse().ToArray());
            string numB = new string(Convert.ToString(b, 2).PadLeft(32, '0').Reverse().ToArray());
            string bitsToInsert = numB.Substring(0, j - i + 1);
            result = new string(numA.Remove(i, j - i + 1).Insert(i, bitsToInsert).Reverse().ToArray());

            return Convert.ToInt32(result, 2);
        }

        /// <summary>
        /// Get bits from i to j in a given number
        /// </summary>
        /// <param name="number"> Number </param>
        /// <param name="i"> First bit </param>
        /// <param name="j"> Last bit </param>
        /// <returns> Array of extracted bits from number</returns>
        private static int[] GetBitsFromNumber(int number, int i, int j)
        {
            int[] result = new int[j - i + 1];

            for (int k = 0; k < result.Length; k++)
            {
                result[k] = (number >> k) & 1;
            }

            return result;
        }

        /// <summary>
        /// Set bits from i to j positions of a given number
        /// </summary>
        private static int SetBitsInNumber(int number, int[] bits, int i, int j)
        {
            int result = number;

            for (int k = 0, l = i; k < bits.Length; k++, l++)
            {
                result = result | (bits[k] << l);      ////(result & ~(1 << l));
            }

            return result;
        }
        #endregion

        #region FindNextBiggerNumber
        /// <summary>
        /// Find next bigger number consists from n-argument digits and calculate performance measurement
        /// </summary>
        /// <param name="n"> Initial number consists of digits</param>
        /// <param name="time"></param>
        /// <returns> -1 - if there is no such number and integer value vice versa </returns>
        public static int FindNextBiggerNumber(int n)
        {
            if (n < 0 || n > int.MaxValue)
            {
                throw new ArgumentException();
            }

            string str = n.ToString();
            int nextNumber = n + 1;

            if (IsConsistOfTheSameDigit(str))
            {
                return -1;
            }

            if (IsFullySortedInDescendingOrder(str))
            {
                return -1;
            }

            while (nextNumber < int.MaxValue)
            {
                string s = nextNumber.ToString();

                if (str.Length < s.Length)
                {
                    break;
                }

                if (s.Length == str.Length)
                {
                    if (AreConsistOfTheSimilarDigits(str, s))
                    {
                        return Convert.ToInt32(s);
                    }
                }

                nextNumber++;
            }

            return -1;
        }

        /// <summary>
        /// FindNextBiggerNumber for performance measurement
        /// </summary>
        public static int FindNextBiggerNumber(int n, out double time)
        {
            Stopwatch sw = new Stopwatch();

            sw.Start();
            int result = FindNextBiggerNumber(n);
            sw.Stop();

            time = sw.Elapsed.TotalMilliseconds;

            return result;
        }

        private static bool IsFullySortedInDescendingOrder(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                for (int j = i + 1; j < str.Length; j++)
                {
                    if (str[i] < str[j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Check if any two strings are absolutely equivalent
        /// </summary>
        /// <param name="str1"> first string </param>
        /// <param name="str2"> second string </param>
        /// <returns> are they equal? </returns>
        private static bool AreConsistOfTheSimilarDigits(string str1, string str2)
        {
            char[] arr1 = str1.ToArray();
            char[] arr2 = str2.ToArray();
            Array.Sort(arr1);
            Array.Sort(arr2);

            for (int i = 0; i < arr1.Length; i++)
            {
                if (arr1[i] != arr2[i])
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Check if current string consists of the same char(3333, 999999, etc.)
        /// </summary>
        /// <param name="str"> String to check</param>
        /// <returns> True or false</returns>
        private static bool IsConsistOfTheSameDigit(string str)
        {
            char pattern = str[0];

            foreach (var item in str)
            {
                if (item != pattern)
                {
                    return false;
                }
            }

            return true;
        }
        #endregion

        #region FilterDigit
        /// <summary>
        /// Filter elements of the array where array[i] contains number
        /// </summary>
        /// <param name="arr"> array of integers </param>
        /// <param name="number"> value-filter </param>
        /// <returns> new integer array where each element consists of number value </returns>
        public static int[] FilterDigit(int[] arr, int number)
        {
            if (arr == null)
            {
                throw new ArgumentNullException("Can't be null");
            }

            if (number < 0)
            {
                throw new ArgumentNullException("Can't be less than zero");
            }

            List<int> result = new List<int>();
            
            foreach (var item in arr)
            {
                if (IsConsistOfDigit(item, number))
                {
                    result.Add(item);
                }
            }

            return result.ToArray();
        }

        /// <summary>
        /// Check if a given number consist of a given digit
        /// </summary>
        /// <param name="number"> Number </param>
        /// <param name="digit"> Digit </param>
        /// <returns> Returns true if the number consists of the digit </returns>
        private static bool IsConsistOfDigit(int number, int digit)
        {
            while (number != 0)
            {
                if (number % 10 == digit)
                {
                    return true;
                }

                number /= 10;
            }

            return false;
        }

        #region FilterDigitInefficient
        /// <summary>
        /// Inefficient implementation of FilterDigit
        /// </summary>
        public static int[] FilterDigitInefficient(int[] arr, int number)
        {
            if (arr == null)
            {
                throw new ArgumentNullException("Can't be null");
            }

            if (number < 0)
            {
                throw new ArgumentNullException("Can't be less than zero");
            }

            string[] strs = IntArrayToStringArray(arr);
            List<string> lst = new List<string>();
            int count = 0;

            for (int i = 0; i < strs.Length; i++)
            {
                foreach (var item in strs[i])
                {
                    if (item == number.ToString()[0])
                    {
                        lst.Add(strs[i]);
                        ++count;
                        break;
                    }
                }
            }

            int[] result = new int[count];
            for (int i = 0; i < lst.Count; i++)
            {
                result[i] = Convert.ToInt32(lst[i]);
            }

            return result;
        }

        /// <summary>
        /// Convert array of integers into array of strings
        /// </summary>
        /// <param name="arr"> array of integers </param>
        /// <returns> array of strings </returns>
        private static string[] IntArrayToStringArray(int[] arr)
        {
            string[] str = new string[arr.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                str[i] = arr[i].ToString();
            }

            return str; 
        }
        #endregion
        #endregion

        #region FindNthRoot
        /// <summary>
        /// Find N-th root of number with with a given accuracy epsilon
        /// </summary>
        /// <param name="number"> Number </param>
        /// <param name="n"> Root degree </param>
        /// <param name="eps"> Accuracy </param>
        /// <returns> N-th root of the number </returns>
        public static double FindNthRoot(double number, int n, double epsilon)
        {
            if (number == 0)
            {
                return 0;
            }

            if (n == 1)
            {
                return number;
            }

            if (epsilon > 1 || epsilon < 0)
            {
                throw new ArgumentException("Epsilon must be: 0 < epsilon < 1");
            }

            if (n < 1)
            {
                throw new ArgumentException("Root degree must be positive");
            }

            double x = 0.1; //// x = n % 2 == 0 ? 0.3 : 0.1;!!!!!! <= ;o..o;

            while (true)
            {
                double nxt = (((n - 1) * x) + (number / Math.Pow(x, n - 1))) / n;

                if (Math.Abs(x - nxt) < epsilon)
                {
                    break;
                }

                x = nxt;
            }

            return x;
        }
        #endregion
    }
}
