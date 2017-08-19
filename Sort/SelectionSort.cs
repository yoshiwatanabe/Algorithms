using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Sort
{
    public class SelectionSort
    {
        public int[] Sort(int[] array)
        {
            int[] result = array.Clone() as int[];
            SelectSmallest(result, 0);
            return result;
        }

        public static void SelectSmallest(int[] array, int index)
        {
            if (index == array.Length - 1)
            {
                return;
            }

            // This block's goal is to obtain the position of the smallest element
            // by comparing to the "current smallest element" (pointed to by the smallerPos)
            // until the iterator index falls off of the end of the array.           
            int smallerPos = index;
            for (int i = index + 1; i < array.Length; i++)
            {
                if (array[i] < array[smallerPos])
                {
                    smallerPos = i;
                }
            }

            Utility.Swap(array, index, smallerPos); // We found the smallest one in this sub-array
            SelectSmallest(array, index + 1); // Recursively process the array, one element less than we have
        }

        // Visualize. With a given set to be sorted, we do a series of comparison to choose the smallest
        // but the set becomes smaller progressively as we find the smallest from the entire set.
        // Imagine a recursive stack where closer it gets to the top of the stack, the comparison loop
        // becomes shorter.
    }
}
