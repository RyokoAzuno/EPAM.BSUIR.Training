using System;
using System.Collections.Generic;

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

            //Console.ReadLine();
        }
        public static int[] FilterDigit(int[] arr, int number)
        {
            if (arr == null)
                throw new ArgumentNullException("Can't be null");

            if (number < 0)
                throw new ArgumentNullException("Can't be less than zero");
            List<int> result = new List<int>();

            foreach (var item in arr)
            {
                if (IsConsist(item, number))
                    result.Add(item);
            }
            //string[] strs = IntArrayToStringArray(arr);
            //List<string> lst = new List<string>();
            //int count = 0;

            //for (int i = 0; i < strs.Length; i++)
            //{
            //    foreach (var item in strs[i])
            //    {
            //        if (item == number.ToString()[0])
            //        {
            //            lst.Add(strs[i]);
            //            ++count;
            //            break;
            //        }
            //    }
            //}
            //int[] result = new int[count];
            //for (int i = 0; i < lst.Count; i++)
            //{
            //    result[i] = Convert.ToInt32(lst[i]);
            //}

            return result.ToArray();
        }

        private static bool IsConsist(int number, int digit)
        {
            while(number != 0)
            {
                if (number % 10 == digit)
                    return true;
                number /= 10;
            }

            return false;
        }
    }
}
