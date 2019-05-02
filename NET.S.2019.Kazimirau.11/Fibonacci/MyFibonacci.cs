using System;
using System.Collections.Generic;

namespace Fibonacci
{
    /// <summary>
    /// Class for working with fibonacci numbers 
    /// </summary>
    public sealed class MyFibonacci
    {
        /// <summary>
        /// Calculate only positive Fibonacci numbers with recursion
        /// </summary>
        /// <param name="n"> Fibonacci number position </param>
        /// <returns> Fibonacci number </returns>
        public static int FibonacciRec(int n)
        {
            if (n < 0)
            {
                throw new ArgumentException();
            }

            if (n == 0)
            {
                return 0;
            }

            return (n == 1) || (n == 2) ? 1 : Fibonacci(n - 1) + Fibonacci(n - 2);
        }

        /// <summary>
        /// Calculate only positive Fibonacci numbers without recursion
        /// </summary>
        /// <param name="n"> Fibonacci number position </param>
        /// <returns> Fibonacci number </returns>
        public static int Fibonacci(int n)
        {
            if (n < 0)
            {
                throw new ArgumentException();
            }

            if (n == 0)
            {
                return 0;
            }

            if (n == 1 || n == 2)
            {
                return 1;
            }

            int fibNum = 0;
            int leftNum = 1;
            int righNum = 1;

            for (int i = 3; i <= n; i++)
            {
                fibNum = leftNum + righNum;
                leftNum = righNum;
                righNum = fibNum;
            }

            return fibNum;
        }

        /// <summary>
        /// Calculate a list of n first Fibonacci numbers begin with 0(zero)
        /// </summary>
        /// <param name="n"> A count of Fibonacci numbers </param>
        /// <returns> Returns a list of n first positive Fibonacci numbers </returns>
        public static List<int> FibonacciList(int n)
        {
            if (n < 0 || n == 0)
            {
                throw new ArgumentException();
            }

            if (n == 1)
            {
                return new List<int> { 1 };
            }

            if (n == 2)
            {
                return new List<int> { 1, 1 };
            }
            ////if (n == 3)
            ////    return new List<int> { 1, 1, 2 };

            List<int> fibList = new List<int>() { 1, 1 };
            int fibNum = 0;
            int leftNum = 1;
            int righNum = 1;

            for (int i = 3; i <= n; i++)
            {
                fibNum = leftNum + righNum;
                leftNum = righNum;
                righNum = fibNum;
                fibList.Add(fibNum);
            }

            return fibList;
        }
    }
}
