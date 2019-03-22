using System;
using System.Linq;

namespace Tasks.Day02
{
    public static class Tasks
    {
        #region InsertNumber
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
    }
}
