using System;

namespace Sort
{
    partial class Program
    {
        public static void DoMergeSort(int[] array, int begin, int last)
        {
            int[] helper = new int[array.Length];
            MergeSort(array, helper, begin, last);
        }

        public static void MergeSort(int[] array, int[] helper, int begin, int last)
        {
            if (begin >= last) {
                return;
            }

            int middle = (begin + last) / 2; // Earlier, I was doing "last-begin" which was wrong..
            MergeSort(array, helper, begin, middle);
            MergeSort(array, helper, middle + 1, last);            
            Merge(array, helper, begin, middle, last);            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="array">input array that has TWO subarrays (left and rigth) that are already sorted</param>
        /// <param name="helper">An extra array of int, size equals to that of 'array'</param>
        /// <param name="begin">begining of two-part subarrays</param>
        /// <param name="middle">the end of the left array, it devides left and right</param>
        /// <param name="last">the last element of the right array. from middle+1..end is the right array (already sorted)</param>
        /// <remarks>
        /// [2, 4, 5 || 3, 8, 9] (begin..middle) (middle+1..last)
        /// </remarks>
        public static void Merge(int[] array, int[] helper, int begin, int middle, int last)
        {
            // copy our two-part array elements to our helper.            
            for (int i = begin; i <= last; i++)
            {
                helper[i] = array[i];
            }

            // defines two pointers, each to track the next element to compare
            // the winner is copyed to the final location
            int leftIndex = begin;
            int rightIndex = middle + 1;

            // set up an index that point to the next slot to store the next smallest value
            // from either left or right subarray
            int storeIndex = begin;

            while (leftIndex <= middle && rightIndex <= last)
            {
                if (helper[leftIndex] <= helper[rightIndex])
                {
                    array[storeIndex] = helper[leftIndex];
                    leftIndex++;
                }
                else
	            {
                    array[storeIndex] = helper[rightIndex];
                    rightIndex++;
	            }

                storeIndex++;
            }

            // this block is needed to copy any remaining elements from left.
            // note that if there are remainders in right subarray, then we
            // don't need to do any extra copying as 'array' already contains correctly
            // ordered right subarray to begin with.
            int remeinder = middle - leftIndex;
            for (int i = 0; i <= remeinder; i++)
            {
                array[storeIndex + i] = helper[leftIndex + i];
            }
        }
    }
}
