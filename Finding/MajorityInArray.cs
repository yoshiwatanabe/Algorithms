using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Finding
{
    partial class Program
    {
        /// <summary>
        /// This is Moor's Voting algorithm. Note that this can detect up to n/2 element
        /// to figure out a "majority (which is > n/2, or >= n/2+1, you have to have phase two
        /// to count the occurrance of a given "candidate" and check >n/2 to determine real
        /// "majority" (by definition, it has to be more than half)
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static int FindMajorityCandidate(int[] array)
        {
            // { 3, 3, 3, 3, 4, 5, 6}
            //      2  3  4  3  2  1   <= not zero
            //   0  0  0  0  0  0  0 <= how index changes

            // { 4, 5, 6, 3, 3, 3 }
            //   0  0  0  2  3  4  <= not zero

            int index = 0; // Start off with 0th element
            int count = 1; // Moor's Voting algorithm counts with base 1

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
                    index = i; // 
                    count = 1; // Moor's Voting algorithm counts with base 1
                }
            }

            return array[index];
        }

        public static bool IsMajority(int[] array, int candidate)
        {
            int count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == candidate)
                {
                    count++;
                }
            }

            return count > array.Length / 2;
        }

        public static void TestFindMajority()
        {
            int[] array = new int[] { 3, 3, 3, 3, 4, 5, 6 };
            int candidate = FindMajorityCandidate(array);
            Debug.Assert(candidate == 3);
            Debug.Assert(IsMajority(array, candidate));

            array = new int[] { 3, 4, 1, 1, 1 };
            candidate = FindMajorityCandidate(array);
            Debug.Assert(candidate == 1);
            Debug.Assert(IsMajority(array, candidate));

            array = new int[] { 1, 4, 1, 3, 1 };
            candidate = FindMajorityCandidate(array);
            Debug.Assert(candidate == 1);
            Debug.Assert(IsMajority(array, candidate));

            array = new int[] { 3, 4, 5, 1, 1, 1 };
            candidate = FindMajorityCandidate(array);
            Debug.Assert(candidate == 1); // 1 is a candidate, but not a majority
            Debug.Assert(false == IsMajority(array, candidate));
        }
    }
}
