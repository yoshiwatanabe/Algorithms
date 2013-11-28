using System;
using System.Collections.Generic;
using System.Text;

namespace Finding
{
    partial class Program
    {
        public static int BinarySearch(int[] array, int x) // 2, 4, 5, 6  x = 7
        {
            int begin = 0; // 2
            int last = array.Length - 1; // 3
            int mid = 0; // 2

            while (begin <= last) // 2 <= 3
            {
                mid = (begin + last) / 2; // 2 + 3 / 2 = 2
                if (array[mid] < x) // 5 < 5
                {
                    begin = mid + 1; // 1 + 1 = 2
                }
                else if (array[mid] > x) // 5 > 5
                {
                    last = mid - 1; // 1 - 1 = 0
                }
                else
                {
                    return mid;
                }
            }

            return -1;
        }
    }
}
