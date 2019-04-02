using System;
using System.Collections.Generic;
using System.Linq;

namespace Tasks.Day02.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            //int nextBigger = Tasks.FindNextBiggerNumber(1234126, out double time);
            //Console.WriteLine($"FindNextBiggerNumber for 1234126 = {nextBigger}, total time: {time.ToString("0.00 ms")}");
            //nextBigger = Tasks.FindNextBiggerNumber(3456432, out time);
            //Console.WriteLine($"FindNextBiggerNumber for 3456432 = {nextBigger}, total time: {time.ToString("0.00 ms")}");
            //nextBigger = Tasks.FindNextBiggerNumber(777777777, out time);
            //Console.WriteLine($"FindNextBiggerNumber for 777777777 = {nextBigger}, total time: {time.ToString("0.00 ms")}");

            Console.WriteLine((int)'9'); // '0' - 48 ... '9' - 57
            Console.WriteLine(AreConsistOfTheSimilarDigits("41234561", "26543241"));
            Console.ReadLine();
        }

        public static int FindNextBiggerNumber(int n)
        {
            if (n < 0 || n > int.MaxValue)
                throw new ArgumentException();

            string str = n.ToString();
            int nextNumber = n + 1;

            if (IsConsistOfTheSameDigit(str))
                return -1; 

            while (nextNumber < int.MaxValue)
            {
                string s = nextNumber.ToString();
                if (str.Length < s.Length)
                    break;
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

        private static bool IsFullySortedInDescendingOrder(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                for (int j = i + 1; j < str.Length; j++)
                {
                    if (str[i] < str[j])
                        return false;
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
                    return false;
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
                    return false;
            }

            return true;
        }
    }
}
