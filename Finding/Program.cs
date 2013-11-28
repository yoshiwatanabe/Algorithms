using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Finding
{
    partial class Program
    {
        static void Main(string[] args)
        {
            int index = PartitionMod(new int[] { 12, 7, 14, 9, 10, 11 }, 0, 5);

            int[] array = new int[] { 12, 7, 14, 9, 10, 11 };
            int result = QuickFindDup(array, 0, 5);
            Debug.Assert(result == 0);

            array = new int[] { 12, 7, 14, 9, 9, 11 };
            result = QuickFindDup(array, 0, 5); // -1 indicates duplicate found
            Debug.Assert(result == -1);
            
            array = new int[] { 1, 1, 1, 3, 4 };
            int found = FindMostOccur(array);
            Debug.Assert(found == 1);

            array = new int[] { 3, 4, 1, 1, 1 };
            found = FindMostOccur(array);
            Debug.Assert(found == 1);

            array = new int[] { 3, 4, 5, 1, 1, 1 };
            found = FindMostOccur(array);
            Debug.Assert(found == 1);

            array = new int[] { 4, 5, 6, 7 };
            int atIndex = BinarySearch(array, 4);
            Debug.Assert(atIndex == 0);

            atIndex = BinarySearch(array, 5);
            Debug.Assert(atIndex == 1);

            atIndex = BinarySearch(array, 6);
            Debug.Assert(atIndex == 2);

            atIndex = BinarySearch(array, 7);
            Debug.Assert(atIndex == 3);

            atIndex = BinarySearch(array, 100);
            Debug.Assert(atIndex == -1);
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
    }
}
