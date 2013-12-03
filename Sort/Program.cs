using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Sort
{
    partial class Program
    {
        static void Main(string[] args)
        {
            TestSelectionSort();
            TestInsertionSort();
            TestQuickSort();
            TestMergeSort();
        }

        public static void Swap(int[] array, int pos1, int pos2)
        {
            if (pos1 != pos2)
            {
                int temp = array[pos1];
                array[pos1] = array[pos2];
                array[pos2] = temp;
            }
        }

        public static bool IsSorted(int[] array)
        {
            if (array.Length == 0)
            {
                throw new Exception("array must not be null");
            }
            else if (array.Length == 1)
            {
                return true; // I can't say its not un-sorted, so its sorted
            }

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i - 1] > array[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
