using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Sort
{
    /// <summary>
    /// https://www.slideshare.net/ywatanabe/quicksort-illustrated-walkthrough-28687625
    /// </summary>
    public class QuickSort
    {
        /// <summary>
        /// This is top-level wrappper Quicksort that takes an input array.
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public int[] Sort(int[] array)
        {
            int[] result = array.Clone() as int[]; // Be nice and do not modify the input. (Alternatively, we can modify it)
            Sort(result, 0, result.Length - 1);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="array">An input array (the entire input array)</param>
        /// <param name="begin">The first element of the sub-array to be sorted</param>
        /// <param name="last">The last element of the sub-array to be sorted</param>
        public void Sort(int[] array, int begin, int last)
        {
            int pivotIndex = 0;

            if (begin < last)
            {
                pivotIndex = Partition(array, begin, last); // Hopefully, the pivotIndex is near the middle of the array
                Sort(array, begin, pivotIndex - 1);
                Sort(array, pivotIndex + 1, last);
            }
            else
            {
                return; // This is the base case to return from recursive function calls.
            }
        }

        /// <summary>
        /// Partition function that organizes the elements such that all elements smaller or equal to the pivot 
        /// is place to the left of a pivot location, and all the elements greater than the pivot are placed
        /// to the right of the pivot location. Return value is the index at which pivot element is located.
        /// Calling function can further sort the left and right subarray separately.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="begin"></param>
        /// <param name="last"></param>
        /// <returns></returns>
        public static int Partition(int[] array, int begin, int last)
        {
            // Upon return, this sotreIndex will be in-between "less than or equal to" partition and "greater than pivot" partition.
            // storeIndex will move forward only if it accepts a "less than or equal to" element.
            // At the end, values at storeIndex and pivot are swapped.
            int storeIndex = begin; 

            // We have to scan the entire array - this is O(n) component of the time complexity.
            for (int i = begin; i < last; i++) // Note. we do NOT evaluate the last element at [last] because it is a pivot location
            {
                // Tip: its less than *and* equal to (why include equal to? because we want a value same as pivot on the left handside (pivot-1) 
                if (array[i] <= array[last])
                {
                    Utility.Swap(array, i, storeIndex); // Tip: note that pivot is not involved in swap. Pivot value is just a reference point
                    storeIndex = storeIndex + 1; // Tip: those on the left of this index is "less than equal to pivot value" move on.
                }
            }

            // Why? Because we know at [storeIndex] is NOT "less than equal" (otherwise
            // it would been left of [storeIndex]). So whatever it is, its "greater than pivot.
            // So it is OK to swap it with pivot value.
            Utility.Swap(array, storeIndex, last);

            return storeIndex;
        }

        /// <summary>
        /// Another version of Partition. I don't particularly like this version as it is not intuitive to start with -1 as a insertion location.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="begin"></param>
        /// <param name="last"></param>
        /// <returns></returns>
        public static int Partition2(int[] array, int begin, int last)
        {
            int pivotValue = array[last]; //rand.Next(end - start + 1) + start;
            
            int storeIndex = begin - 1; // we start before the start because when we do a swap, the first thing is to adavance this by one
            // i is 1 before the appropriate insertion point.

            for (int i = begin; i < last; i++)
            {
                if (array[i] < pivotValue)
                {
                    ++storeIndex;
                    Utility.Swap(array, storeIndex, i);
                }
            }

            Utility.Swap(array, storeIndex + 1, last); // pivot value belongs to "left" group. we know storeIndex +1 contains larger value is must have been compared with pivotValue earilier when 'i' visited it.
            return storeIndex + 1; // because storeIndex is 1 before the appropriate insertion point, we must add one
        }

        static QuickSort()
        {
            QuickSort.Partition(new int[] { 12, 7, 14, 9, 10, 11 }, 0, 5);

            QuickSort.Partition2(new int[] { 12, 7, 14, 9, 10, 11 }, 0, 5);

            int[] array = new int[] { 12, 7, 14, 9, 10, 11 };
            (new QuickSort()).Sort(array, 0, 5);
            Debug.Assert(Utility.IsSorted(array));
        }


        // Visualize.
        // We partition the initial array using partition method. The partition method uses an arbitrarily
        // chosen value in the array as "pivot" value (I like using the "last" element, but some uses the "first"
        // element). The partition function returns the "pivot" index when its job is done. 
        // The partition function guarantees that the processed array is partitioned into two sections, those
        // on the left of the pivot index is smaller than those in the right of the pivot index. Note that it
        // does not says that elements in these two sections are sorted. Thus, we have to process more.
        // Each of the two partitions is independently processed again, and this continues recursively.
        // The base-condition when the array to be processed is just a single element (use begin and last indices to 
        // determine that). When base-condition is met, the stack of recursion start unwinding.
        // When a stack unwindes, it means that the array at that invocation is sorted. Unlike merge sort,
        // quicksort's unwinding is fast as there is no work left to do. When stack unwinding completes, the array
        // is sorted.
    }
}
