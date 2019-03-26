using System;

namespace GCD.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 4598376;
            int b = 56789428;

            #region GCDs algs for two numbers
            Console.WriteLine("Euclidean algorithm performance:");
            int euclideanGcd = MyGCD.EuclideanGcd(a, b, out double time);
            Console.WriteLine($"a = {a}, b = {b}, GCD = {euclideanGcd}, time = {time}ms");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Binary GCD algorithm performance:");
            int binaryGcd = MyGCD.BinaryGcd(a, b, out time);
            Console.WriteLine($"a = {a}, b = {b}, GCD = {binaryGcd}, time = {time}ms");
            #endregion

            Console.WriteLine();
            Console.WriteLine();

            #region GCDs algs for multiply numbers
            Console.WriteLine("Euclidean algorithm(for multiply numbers) performance:");
            euclideanGcd = MyGCD.EuclideanGcd(out time, 85888, 94848, 73464, 42448, 98888);
            Console.WriteLine($"85888, 94848, 73464, 42448, 98888, GCD = {euclideanGcd}, time = {time}ms");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Binary GCD algorithm(for multiply numbers) performance:");
            binaryGcd = MyGCD.BinaryGcd(out time, 85888, 94848, 73464, 42448, 98888);
            Console.WriteLine($"85888, 94848, 73464, 42448, 98888, GCD = {binaryGcd}, time = {time}ms");
            #endregion

            Console.ReadLine();
        }
    }
}
