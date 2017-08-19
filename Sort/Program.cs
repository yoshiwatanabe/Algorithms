using System;
using System.Diagnostics;

namespace Sort
{
    public class Program
    {
        static void Main(string[] args)
        {
            TestSelectionSort(new int[] { 34, 5, 38, 25, 51, 8, 33, 53, 21 });
            TestInsertionSort(new int[] { 34, 5, 38, 25, 51, 8, 33, 53, 21 });
            TestQuickSort(new int[] { 34, 5, 38, 25, 51, 8, 33, 53, 21 });
            TestMergeSort(new int[] { 34, 5, 38, 25, 51, 8, 33, 53, 21 });
        }

        public static void TestSelectionSort(int[] array)
        {            
            Debug.Assert(Utility.IsSorted((new SelectionSort()).Sort(array)));
        }

        public static void TestInsertionSort(int[] array)
        {
            (new InsertionSort()).Sort(array);
            Debug.Assert(Utility.IsSorted(array));
        }

        public static void TestQuickSort(int[] array)
        {
            (new QuickSort()).Sort(array);
            Debug.Assert(Utility.IsSorted(array));
        }

        public static void TestMergeSort(int[] array)
        {
            (new MergeSort()).Sort(array);
            Debug.Assert(Utility.IsSorted(array));

        }
    }
}
