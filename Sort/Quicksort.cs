using System;
using System.Collections.Generic;
using System.Text;

namespace Sort
{
    partial class Program
    {
        public static void QuickSort(int[] array, int begin, int last)
        {
            int pivotIndex = 0;

            if (begin < last) // it is critical that we have a base case where if begin == last or begin > last, we return (implicit)
            {
                pivotIndex = Partition(array, begin, last); // note. this can be the same as 'last'
                QuickSort(array, begin, pivotIndex - 1); // note. we could happ last that is equal to 'begin'
                QuickSort(array, pivotIndex + 1, last); // note. we could pass begin that is greater than last
            }
            else
            {
                return;
            }
        }

        public static int Partition(int[] array, int begin, int last)//, int pivotIndex)
        {
            //int pivotValue = array[last]; // Just use [last] as a pivot

            int storeIndex = begin; // this will be in-between "less than pivot" and "greater than pivot" groups

            for (int i = begin; i < last; i++) // This index scans from left to right all the way. Note. we do NOT evaluate the last element at [last] because it is a pivot location
            {
                if (array[i] <= array[last]) // Tip: its less than *and* equal to (why include equal to? because we want a value same as pivot on the left handside (pivot-1) 
                {
                    Swap(array, i, storeIndex); // Tip: not that pivot is not involved in swap. Pivot value is just a reference point
                    storeIndex = storeIndex + 1; // Tip: those on the left of this index is "less than equal to pivot value" move on.
                }
            }

            Swap(array, storeIndex, last); // Why this works? Because we know at [storeIndex] is NOT "less than equal" (otherwise
                                            // it would been left of [storeIndex]. So whatever it is, its "greater than pivot.
                                            // So it is OK to swap it with pivot value.

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
                    Swap(array, storeIndex, i);
                }
            }

            Swap(array, storeIndex + 1, last); // pivot value belongs to "left" group. we know storeIndex +1 contains larger value is must have been compared with pivotValue earilier when 'i' visited it.
            return storeIndex + 1; // because storeIndex is 1 before the appropriate insertion point, we must add one
        }
    }
}
