using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Finding
{
    partial class Program
    {
        public static bool HasDuplicate(int[] array)
        {
            int result = FindDuplicateBySorting(array, 0, array.Length - 1);
            return result == -1;
        }

        /// <summary>
        /// This is based on QuickSort, but uses a special partition method that returns -1 if
        /// it encounters a duplicate. The idea is that when we try to sort, the duplicate
        /// will be detected when a comparison between a given pair is made.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static int FindDuplicateBySorting(int[] array, int begin, int end)
        {
            if (begin < end)
            {
                int pivotIndex = DuplicateDetectingPartition(array, begin, end);
                if (pivotIndex == -1)
                {
                    // Partition found a duplicate. No need to sort anymore.
                    return - 1;
                }

                // Proceed to the left subarray
                if (-1 == FindDuplicateBySorting(array, begin, pivotIndex - 1))
                {
                    // Duplicate is found in the child (or its descendant) function
                    return -1;
                }

                // Proceed to the right subarray
                if (-1 == FindDuplicateBySorting(array, pivotIndex + 1, end))
                {
                    // Duplicate is found in the child (or its descendant) function
                    return -1;
                }
            }

            return 0;
        }

        /// <summary>
        /// This is a special partititon method based on a common partition method using 
        /// 'pivot' but unlike an ordinary partition, it will return a special value, -1,
        /// when it finds a duplicate value (when a value equal to a given pivoit value is
        /// found.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static int DuplicateDetectingPartition(int[] array, int begin, int end)
        {
            int pivotValue = array[end];

            int insertLoc = begin;

            for (int i = begin; i < end; i++)
            {
                if (array[i] < pivotValue)
                {
                    Swap(array, i, insertLoc);
                    insertLoc++;
                }
                else if (array[i] == pivotValue)
                {
                    // We found a duplicate of a pivot!
                    return -1;
                }
            }

            Swap(array, insertLoc, end);
            return insertLoc;
        }

        public static void Swap<T>(T[] array, int pos1, int pos2)
        {
            if (pos1 != pos2)
            {
                T temp = array[pos1];
                array[pos1] = array[pos2];
                array[pos2] = temp;
            }
        }

        public static void TestFindDuplicate()
        {
            int[] array = new int[] { 12, 7, 14, 9, 10, 11 };
            Debug.Assert(HasDuplicate(array) == false);

            array = new int[] { 12, 7, 14, 9, 9, 11 };
            Debug.Assert(HasDuplicate(array) == true);
        }
    }
}
