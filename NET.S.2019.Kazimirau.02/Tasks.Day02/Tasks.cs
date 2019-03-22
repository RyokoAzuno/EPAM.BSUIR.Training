using System;
using System.Collections.Generic;
using System.Linq;

namespace Tasks.Day02
{
    public static class Tasks
    {
        #region InsertNumber
        /// <summary>
        /// Insert bits from second number into first number
        /// </summary>
        /// <param name="a"> a first number </param>
        /// <param name="b"> a second number </param>
        /// <param name="i"> a first bit index</param>
        /// <param name="j"> a second bit index </param>
        /// <returns> new integer number </returns>
        public static int InsertNumber(int a, int b, int i, int j)
        {
            string result = string.Empty;
            string numA = new string(Convert.ToString(a, 2).PadLeft(32, '0').Reverse().ToArray());
            string numB = new string(Convert.ToString(b, 2).PadLeft(32, '0').Reverse().ToArray());
            string bitsToInsert = numB.Substring(0, j - i + 1);
            result = new string(numA.Remove(i, j - i + 1).Insert(i, bitsToInsert).Reverse().ToArray());

            return Convert.ToInt32(result, 2);
        }
        #endregion

        #region FindNextBiggerNumber
        /// <summary>
        /// Find next bigger number consists from n-argument digits
        /// </summary>
        /// <param name="n"></param>
        /// <returns> -1 - if there is no such number and integer value vice versa</returns>
        public static int FindNextBiggerNumber(int n)
        {
            string str = n.ToString();
            int tmp = n + 1;
            while (tmp < int.MaxValue)
            {
                string s = tmp.ToString();
                if (str.Length < s.Length)
                    break;
                if (s.Length == str.Length)
                {
                    if (AreEqual(str, s))
                    {
                        return Convert.ToInt32(s);
                    }
                }
                tmp++;
            }
            return -1;
        }
        /// <summary>
        /// Check if any two strings are absolutely equivalent
        /// </summary>
        /// <param name="str1"> first string </param>
        /// <param name="str2"> second string </param>
        /// <returns> are they equal? </returns>
        private static bool AreEqual(string str1, string str2)
        {
            char[] arr1 = str1.ToArray();
            char[] arr2 = str2.ToArray();
            Array.Sort(arr1);
            Array.Sort(arr2);
            for (int i = 0; i < arr1.Length; i++)
            {
                if (arr1[i] != arr2[i])
                    return false;
            }
            return true;
        }
        #endregion

        #region FilterDigit
        /// <summary>
        /// Filter elements of the array where arr[i] contains number
        /// </summary>
        /// <param name="arr"> array of ints</param>
        /// <param name="number"> a value-filter </param>
        /// <returns> new int array where each element consists of number value </returns>
        public static int[] FilterDigit(int[] arr, int number)
        {
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
        /// <param name="arr"> array of ints </param>
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
    }
}
