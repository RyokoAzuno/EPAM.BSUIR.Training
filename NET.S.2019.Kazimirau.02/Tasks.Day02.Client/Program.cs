using System;

namespace Tasks.Day02.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            int nextBigger = Tasks.FindNextBiggerNumber(1234126, out double time);
            Console.WriteLine($"FindNextBiggerNumber for 1234126 = {nextBigger}, total time: {time.ToString("0.00 ms")}");
            nextBigger = Tasks.FindNextBiggerNumber(3456432, out time);
            Console.WriteLine($"FindNextBiggerNumber for 3456432 = {nextBigger}, total time: {time.ToString("0.00 ms")}");
            nextBigger = Tasks.FindNextBiggerNumber(777777777, out time);
            Console.WriteLine($"FindNextBiggerNumber for 777777777 = {nextBigger}, total time: {time.ToString("0.00 ms")}");

            Console.ReadLine();
        }
    }
}
