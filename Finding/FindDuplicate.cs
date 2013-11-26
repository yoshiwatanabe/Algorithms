using System;
using System.Collections.Generic;
using System.Text;

namespace Finding
{
    partial class Program
    {
        public static bool IsDuplicateExist(int[] array)
        {

            return false;
        }

        /// <summary>
        /// This is based on QuickSort, but uses a special partition method that returns -1 if
        /// it encounters a duplicate. When -1 is encountered, we stop everything and return -1
        /// </summary>
        /// <param name="array"></param>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static int QuickFindDup(int[] array, int begin, int end)
        {
            if (begin < end)
            {
                int pivotIndex = PartitionMod(array, begin, end);
                if (pivotIndex == -1)
                {
                    return - 1;
                }
                if (-1 == QuickFindDup(array, begin, pivotIndex - 1))
                {
                    return -1;
                }
                if (-1 == QuickFindDup(array, pivotIndex + 1, end))
                {
                    return -1;
                }
            }

            return 0;
        }

        /// <summary>
        /// This is a special partititon method that detect equal value to pivot (ordinarily it is OK operation)
        /// and returns -1.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static int PartitionMod(int[] array, int begin, int end)
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
                    return -1;
                }
            }

            Swap(array, insertLoc, end);
            return insertLoc;
        }
    }
}
