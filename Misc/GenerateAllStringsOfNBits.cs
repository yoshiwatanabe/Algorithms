using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Misc
{
    class GenerateAllStringsOfNBits
    {
        static int[] A;

        public static void Run(int n)
        {
            A = new int[n];
            Binary(n);
        }

        public static void Binary(int n)
        {
            if (n < 1)
            {
                for (int i = A.Length-1; i >= 0; i--) // We flip the order to make it look like 0001, 00010, 0010
                {
                    Console.Write(A[i]);
                }
                Console.WriteLine();
            }
            else
            {
                A[n - 1] = 0;
                Binary(n - 1); // [1]
                A[n - 1] = 1;  // [2]
                Binary(n - 1); // [3]
            }
        }

        // [1] causes depth=n recursive stack at first, then start "unwiding (backtracking)
        // Unwinding of the stack takes longer as the younger stack would recusively builds the
        // call stack, at [3], with its level's bit being 1.
        //
        // Note that the stack depth is equal to the number of bit, so you can build a mental
        // picture of stack directly mapped to "digits" (e.g. 0010) where (0-0-1-0 are call record)
    }
}
