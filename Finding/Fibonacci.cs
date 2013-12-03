using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Finding
{
    partial class Program
    {
        /// <summary>
        /// This is a recursive, naive, fibonacchi function
        /// </summary>
        /// <param name="n"></param>
        /// <returns>Returns n-th fibonnach value</returns>
        public static long FindNthFibonacciRecursively(int n)
        {
            if (n <= 0) // Base case, F(0) is always 0
            {
                return 0;
            }

            if (n == 1) // Base case, F(1) is always 1
            {
                return 1;
            }

            // Recursively call for n-1 and n-2
            return FindNthFibonacciRecursively(n - 1) + FindNthFibonacciRecursively(n - 2);
        }

        /// <summary>
        /// Optimized version of. Still not as good as matrix based one.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static long FindNthFibonacciIterative(int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;

            long fibNMinusTwo = 0; // n-2
            long fibNMinusOne = 1; // n-1            
            long fibN = 0; // n

            for (int i = 2; i <= n; ++i) // Tip: start with 2 so that its n-1 is 1 and n-2 is 0
            // Loop terminate when it // 0 1 1 2 3 5 8
            {
                fibN = fibNMinusOne + fibNMinusTwo;

                fibNMinusTwo = fibNMinusOne;
                fibNMinusOne = fibN;
            }

            return fibN;
        }


        public static void TestFindFibonacci()
        {
            long result = FindNthFibonacciRecursively(6); // 0 1 1 2 3 5 8
            Debug.Assert(result == 8);

            result = FindNthFibonacciIterative(6);
            Debug.Assert(result == 8);
        }

        public static void Foo()
        {
        }
    }
}
