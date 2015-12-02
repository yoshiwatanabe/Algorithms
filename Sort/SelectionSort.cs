using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Sort
{
    partial class Program
    {
        private static void SelectionSort(int[] array)
        {
            SelectionSort(array, 0);
        }

        public static void SelectionSort(int[] array, int index)
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

            Swap(array, index, smallerPos); // We found the smallest one in this sub-array
            SelectionSort(array, index + 1); // Recursively process the array, one element less than we have
        }

        public static void TestSelectionSort()
        {
            // Selection Sort
            int[] array = new int[] { 34, 5, 38, 25, 51, 8, 33, 53, 21 };
            SelectionSort(array);
            Debug.Assert(IsSorted(array));
        }

        // Visualize. With a given set to be sorted, we do a series of comparison to choose the smallest
        // but the set becomes smaller progressively as we find the smallest from the entire set.
        // Imagine a recursive stack where closer it gets to the top of the stack, the comparison loop
        // becomes shorter.
    }
}
