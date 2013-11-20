using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            { // Selection Sort
                int[] array = Sample.GetSample();
                SelectionSort(array);
                Debug.Assert(IsSorted(array));
            }

            { // Insersion sort
                // Imagein a cards on left hand
                // touch the [1] card, then see [0] card and see if I should swap.
                // touch the [2] card, then see [0] and [1] cards and see if I can insert [2] into somewhere in [0] and [1]
                // touch the [3] card, then see [0], [1], and [2] cards, see if we can insert..

                int[] array = Sample.GetSample();
                for (int i = 1; i < array.Length; i++)
                {
                    int valToCheck = array[i];
                    for (int j = 0; j < i; j++)
                    {
                        if (array[j] > valToCheck)
                        {
                            for (int k = i; k > j; k--)
                            {
                                array[k] = array[k-1];
                            }

                            array[j] = valToCheck;
                            break; // inseted. done
                        }
                    }
                }

                Debug.Assert(IsSorted(array));
            }
        }

        private static void SelectionSort(int[] array)
        {
            SelectionSort(array, 0);
        }

        public static void SelectionSort(int[] array, int index)
        {
            if (index == array.Length - 1)
            {
                return;
            }

            int smallerPos = index;
            for (int i = index +1; i < array.Length; i++)
            {
                if (array[i] < array[smallerPos])
                {
                    smallerPos = i;
                }
            }

            Swap(array, index, smallerPos);
            SelectionSort(array, index + 1);
        }

        public static void Swap(int[] array, int pos1, int pos2)
        {            
            if (pos1 != pos2)
            {
                int temp = array[pos1];
                array[pos1] = array[pos2];
                array[pos2] = temp;
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
