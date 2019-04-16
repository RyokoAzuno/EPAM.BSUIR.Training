using System;
using System.Diagnostics;

namespace GCD
{
    public class MyGCD
    {
        #region BinaryGcd
        /// <summary>
        /// Binary GCD(Stein's algorithm) algorithm: An alternative method of computing the gcd, method which uses only
        /// subtraction and division by 2 (gcd(a, b) = a * 2^d).
        /// BinaryGCD: https://en.wikipedia.org/wiki/Greatest_common_divisor
        /// </summary>
        /// <param name="a"> Number a </param>
        /// <param name="b"> Number b </param>
        /// <returns> Greatest common divisor </returns>
        public static int BinaryGcd(int a, int b)
        {
            if (a == 0 && b == 0)
                throw new ArgumentException();

            if (a == 0 && b > 0)
                return b;
            else if (b == 0 && a > 0)
                return a;

            if (a < 0)
            {
                a = Math.Abs(a);
                if (b == 0)
                    return a;
            }
            if (b < 0)
            {
                b = Math.Abs(b);
                if (a == 0)
                    return b;
            }

            var elts = Binary(a, b);
            int result = elts.Item1 * Convert.ToInt32(Math.Pow(2, elts.Item2));

            return result;
        }

        /// <summary>
        /// Binary GCD(Stein's algorithm) algorithm: An alternative method of computing the gcd, method which uses only
        /// subtraction and division by 2 (gcd(a, b) = a * 2^d).
        /// BinaryGCD: https://en.wikipedia.org/wiki/Greatest_common_divisor
        /// </summary>
        /// <param name="a"> Number a </param>
        /// <param name="b"> Number b </param>
        /// <param name="time"> Performance measurement time </param>
        /// <returns> Greatest common divisor </returns>
        public static int BinaryGcd(int a, int b, out double time) => InvokeGcd(BinaryGcd, out time, a, b);

        public static int BinaryGcd(out double time, params int[] numbers) => InvokeGcd(BinaryGcd, out time, numbers);

        /// <summary>
        /// Binary GCD(Stein's algorithm) algorithm: An alternative method of computing the gcd of MANY!! numbers,
        /// method which uses only subtraction and division by 2 (gcd(a, b) = a * 2^d).
        /// BinaryGCD: https://en.wikipedia.org/wiki/Greatest_common_divisor
        /// </summary>
        /// <param name="numbers"> Numbers for which we need to find GCD </param>
        /// <returns> Greatest common divisor </returns>
        public static int BinaryGcd(params int[] numbers) => InvokeGcd(BinaryGcd, numbers);

        // Main BinaryGcd algorithm implementation
        private static (int, int) Binary(int a, int b)
        {
            int g = 0;                      // keeper for the first number(a)
            int d = 0;                      // records the number of times that a and b have been both divided by 2
            if (a > 0 && b > 0)
            {
                // Both a and b are even.
                // In this case 2 is a common divisor. Divide both a and b by 2, increment d by 1
                // to record the number of times 2 is a common divisor and continue.
                while ((a % 2 == 0) && (b % 2 == 0))
                {
                    a = a / 2;
                    b = b / 2;
                    ++d;
                }
                while (a != b)
                {
                    if (a % 2 == 0)         // In this case 2 is not a common divisor. Divide a by 2 and continue.
                        a = a / 2;
                    else if (b % 2 == 0)    // As in the previous case 2 is not a common divisor. Divide b by 2 and continue.
                        b = b / 2;
                    else if (a > b)         // As gcd(a,b) = gcd(b,a) and consider that a = b, we may assume that a > b.
                        a = (a - b) / 2;    // Each of the above steps reduces at least one of a and b towards 0 and so can only 
                    else                    // be repeated a finite number of times. 
                        b = (b - a) / 2;    // Thus one must eventually reach the case a = b, which is the only stopping case.
                }
                g = a;
            }

            return (g, d);
        }
        #endregion

        #region EuclideanGcd
        /// <summary>
        ///  Euclidean algorithm, is a method for computing the greatest common divisor (GCD) of two numbers.
        ///  Euclidean algorithm: https://en.wikipedia.org/wiki/Euclidean_algorithm
        /// </summary>
        /// <param name="a"> Number a</param>
        /// <param name="b"> Number b</param>
        /// <returns> Greatest common divisor </returns>
        public static int EuclideanGcd(int a, int b)
        {
            if (a == 0 && b == 0)
                throw new ArgumentException();

            if (a == 0 && b > 0)
                return b;
            else if (b == 0 && a > 0)
                return a;

            if (a < 0)
            {
                a = Math.Abs(a);
                if (b == 0)
                    return a;
            }
            if (b < 0)
            {
                b = Math.Abs(b);
                if (a == 0)
                    return b;
            }

            // Euclidean Algorithm
            while (a != b)
            {
                if (a > b)
                    a -= b;
                else
                    b -= a;
            }

            return a;
        }

        /// <summary>
        ///  Euclidean algorithm, is a method for computing the greatest common divisor (GCD) of MANY!! numbers.
        ///  Euclidean algorithm: https://en.wikipedia.org/wiki/Euclidean_algorithm
        /// </summary>
        /// <param name="nums"> Numbers for which we need to find GCD </param>
        /// <returns> Greatest common divisor </returns>
        public static int EuclideanGcd(params int[] numbers) => InvokeGcd(EuclideanGcd, numbers);

        /// <summary>
        ///  Euclidean algorithm, is a method for computing the greatest common divisor (GCD) of two numbers.
        ///  Euclidean algorithm: https://en.wikipedia.org/wiki/Euclidean_algorithm
        /// </summary>
        /// <param name="a"> Number a</param>
        /// <param name="b"> Number b</param>
        /// <param name="time"> Performance measurement time </param>
        /// <returns> Greatest common divisor </returns>
        public static int EuclideanGcd(int a, int b, out double time) => InvokeGcd(EuclideanGcd, out time, a, b);

        public static int EuclideanGcd(out double time, params int[] numbers) => InvokeGcd(EuclideanGcd, out time, numbers);
        #endregion

        #region Gcd Invokers
        private static int InvokeGcd(Func<int, int, int> gcd, params int[] args)
        {
            if (gcd == null)
            {
                throw new ArgumentNullException();
            }

            if (args.Length < 2)
            {
                throw new ArgumentException();
            }

            int result = gcd(args[0], args[1]);

            if (args.Length > 2)
            {
                for (int i = 2; i < args.Length; i++)
                {
                    result = gcd(result, args[i]);
                }
            }

            return result;
        }

        private static int InvokeGcd(Func<int, int, int> gcd, out double time, params int[] args)
        {
            if (gcd == null)
            {
                throw new ArgumentNullException();
            }

            if (args.Length < 2)
            {
                throw new ArgumentException();
            }

            Stopwatch sw = Stopwatch.StartNew();
            int result = gcd(args[0], args[1]);

            if (args.Length > 2)
            {
                for (int i = 2; i < args.Length; i++)
                {
                    result = gcd(result, args[i]);
                }
            }

            sw.Stop();
            time = sw.Elapsed.TotalMilliseconds;

            return result;
        }
    #endregion
    }
}
