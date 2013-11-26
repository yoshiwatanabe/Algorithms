using System;
using System.Collections.Generic;
using System.Text;

namespace Finding
{
    partial class Program
    {
        // Find a value that appear more than half of an array
        // what is the input? an array of integers
        // what is the timing? at once
        // is input mutalbe? probbaly don't want to change. just scanning.
        
        // what is the output? a single integer value
        
        // Come up with sample input
        // { 2, 3, 4, 4, 4}
        // { 3, 3, 3, 3, 3}
        // { 5 }
        // { 5, 1 } <= which is majority? We say, no majority?

        // one way to do it is to have a dictionary<int, int> wherre
        // key is a certain value in the array and dictionary value is
        // the number of occurrances. 
        // In worst case { 1, 2, 3, 4} all distinct values, we allocate
        // n ke-value pair in the dictionary

        int FindMajority(int[] array, int begin, int end)
        {
            // find a mid-point
            int mid = end - begin / 2;

            for (int i = 0; i < mid; i++)
            {
                if (array[i] > mid)
                {
                }
            }

            return 0;
        }

    }
}
