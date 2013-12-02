using System;
using System.Collections.Generic;
using System.Text;

namespace Finding
{
    partial class Program
    {
        /// <summary>
        /// Finds an index of a specified value in a specified array of integers
        /// </summary>
        /// <param name="array">Input array</param>
        /// <param name="x">A value to search within the array</param>
        /// <returns>An index at which a specified value is found, -1 if not found</returns>
        public static int BinarySearch(int[] array, int x)
        {
            // We start by looking at the *entire* input array, ranging from
            // 0 to length-1
            int begin = 0;
            int last = array.Length - 1;
            // This 0 is not significant. Just so that compiler won't complain
            // about uninitialized local variable.
            int mid = 0;

            // Check to see if we have an array with at least one element.
            // When input array is exhausted, then we quit looking for our
            // target element.
            while (begin <= last)
            {
                // Figure out an index that would cut the array into two
                // halves: left subarray and right subarray.
                // If the number of elements is odd, then it will be the "floor" value
                mid = (begin + last) / 2;

                // We now compare the value right at the middle against our target value.
                // One of the three relationships is possible:
                // 1. Our target is greater than the middle value. This means the right hand 
                //    hand side subarray would include the target value.
                // 2. Our target is less than the middle value. This means the left hand
                //    side subarray would include the target value.
                // 3. Neither subarrays include our value, then the middle value must be
                //    what we are looking for!
                if (array[mid] < x)
                {
                    // Proceed with the right subarray that ranges from mid + 1 to last
                    begin = mid + 1;
                }
                else if (array[mid] > x)
                {
                    // Proceed with the left subarray that ranges from being to mid - 1
                    last = mid - 1;
                }
                else
                {
                    // We found it.
                    return mid;
                }
            }

            // We reach here if we kept drilling down and subarray shrunk to nothing.
            return -1;
        }
    }
}
