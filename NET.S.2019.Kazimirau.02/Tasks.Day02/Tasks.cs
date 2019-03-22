using System;
using System.Linq;

namespace Tasks.Day02
{
    public static class Tasks
    {
        public static int InsertNumber(int a, int b, int i, int j)
        {
            string result = string.Empty;
            string numA = new string(Convert.ToString(a, 2).PadLeft(32, '0').Reverse().ToArray());
            string numB = new string(Convert.ToString(b, 2).PadLeft(32, '0').Reverse().ToArray());
            string bitsToInsert = numB.Substring(0, j - i + 1);
            result = new string(numA.Remove(i, j - i + 1).Insert(i, bitsToInsert).Reverse().ToArray());

            return Convert.ToInt32(result, 2);
        }
    }
}
