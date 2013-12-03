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

            int smallerPos = index;
            for (int i = index + 1; i < array.Length; i++)
            {
                if (array[i] < array[smallerPos])
                {
                    smallerPos = i;
                }
            }

            Swap(array, index, smallerPos);
            SelectionSort(array, index + 1);
        }

        public static void TestSelectionSort()
        {
            // Selection Sort
            int[] array = new int[] { 34, 5, 38, 25, 51, 8, 33, 53, 21 };
            SelectionSort(array);
            Debug.Assert(IsSorted(array));
        }

    }
}
