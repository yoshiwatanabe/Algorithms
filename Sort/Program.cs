﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Sort
{
    partial class Program
    {
        static void Main(string[] args)
        {
            { // Selection Sort
                int[] array = Sample.GetSample();
                SelectionSort(array);
                Debug.Assert(IsSorted(array));
            }

            {
                int[] array = Sample.GetSample();
                RunInsertionSort(array);
                Debug.Assert(IsSorted(array));
            }

            {
                long result = FindNthFibonacciRecursively(6); // 0 1 1 2 3 5 8
                Debug.Assert(result == 8);

                result = FindNthFibonacciIterative(6);
                Debug.Assert(result == 8);
            }

            {
                Partition(new int[] { 12, 7, 14, 9, 10, 11 }, 0, 5);

                Partition2(new int[] { 12, 7, 14, 9, 10, 11 }, 0, 5);

                int[] array = new int[] { 12, 7, 14, 9, 10, 11 };
                QuickSort(array, 0, 5);
                Debug.Assert(IsSorted(array));
            }

            {
                int[] arrayReadyToBeMerged = new int[] { 2, 4, 5, 3, 8, 9};
                int[] helper = new int[arrayReadyToBeMerged.Length];
                Merge(arrayReadyToBeMerged, helper, 0, 2, 5);
                Debug.Assert(IsSorted(arrayReadyToBeMerged));

                int[] array = new int[] { 5, 7};// , 3, 2, 8, 1, 9, 6 };
                DoMergeSort(array, 0, array.Length - 1);
                Debug.Assert(IsSorted(array));

                array = new int[] { 7, 5 };// , 3, 2, 8, 1, 9, 6 };
                DoMergeSort(array, 0, array.Length - 1);
                Debug.Assert(IsSorted(array));

                array = new int[] { 7, 5, 3 };
                DoMergeSort(array, 0, array.Length - 1);
                Debug.Assert(IsSorted(array));

                array = new int[] { 5, 7, 3, 2};//, 8, 1, 9, 6 };
                DoMergeSort(array, 0, array.Length - 1);
                Debug.Assert(IsSorted(array));
            }

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

        private static bool IsSorted(int[] array)
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
