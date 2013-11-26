using System;
using System.Collections.Generic;
using System.Text;

namespace Finding
{
    partial class Program
    {
        /// <summary>
        /// This is Moor's voting algorithm. Note that this can detect up to n/2 element
        /// to figure out a "majority (which is > n/2, or >= n/2+1, you have to have phase two
        /// to count the occurrance of a given "candidate" and check >n/2
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static int FindMostOccur(int[] array)
        {
            // { 3, 3, 3, 4, 5, 6}
            //   2  3  4  3  2  1  <= not zero
            // { 4, 5, 6, 3, 3, 3 }
            //   0  0  0  2  3  4  <= not zero

            int index = 0;
            int count = 1;

            for (int i = 1; i < array.Length; i++)
            {
                if (array[index] == array[i])
                {
                    count++;
                }
                else
                {
                    count--;
                }

                if (count == 0)
                {
                    index = i;
                    count = 1;
                }
            }

            return array[index];
        }

    }
}
