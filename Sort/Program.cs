using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Sort
{
    partial class Program
    {
        static void Main(string[] args)
        {
            { // Selection Sort
                int[] array = Sample.GetSample();
                SelectionSort(array);
                Debug.Assert(IsSorted(array));
            }

            {                 
                int[] array = Sample.GetSample();
                RunInsertionSort(array);
                Debug.Assert(IsSorted(array));
            }

            {
                long result = SlowFibonacchi(6); // 0 1 1 2 3 5 8
                Debug.Assert(result == 8);

                result = BetterFibonacchi(6);
                Debug.Assert(result == 8);
            }
        }     

        private static bool IsSorted(int[] array)
        {
            if (array.Length == 0)
            {
                throw new Exception("array must not be null");
            }
            else if (array.Length == 1)
            {
                return true; // I can't say its not un-sorted, so its sorted
            }

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i - 1] > array[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
