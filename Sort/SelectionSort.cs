using System;
using System.Collections.Generic;
using System.Text;

namespace Sort
{
    partial class Program
    {
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
            for (int i = index + 1; i < array.Length; i++)
            {
                if (array[i] < array[smallerPos])
                {
                    smallerPos = i;
                }
            }

            Swap(array, index, smallerPos);
            SelectionSort(array, index + 1);
        }


    }
}
