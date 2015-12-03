using System;
using System.Collections.Generic;
using System.Text;

namespace WordCount
{
    partial class Program
    {
        public static void ReverseString(char[] array)
        {
            ReverseString(array, 0, array.Length - 1);
        }

        public static void ReverseString(char[] array, int i, int j)
        {
            if (i < j)
            {
                Swap(array, i, j);
                ReverseString(array, ++i, --j);
            }
        }

        // Visualize.
        // Recursively swap the two ends of an input array - working on the same
        // array at each recursion, but the provided indices define the range.
        // The stack's heght will be n/2
    }
}
