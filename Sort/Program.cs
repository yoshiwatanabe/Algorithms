using System;
using System.Diagnostics;

namespace Sort
{
    public class Program
    {
        static void Main(string[] args)
        {
            Debug.Assert(Utility.IsSorted((new SelectionSort()).Sort(new int[] { 34, 5, 38, 25, 51, 8, 33, 53, 21 })));
            Debug.Assert(Utility.IsSorted((new InsertionSort()).Sort(new int[] { 34, 5, 38, 25, 51, 8, 33, 53, 21 })));
            Debug.Assert(Utility.IsSorted((new QuickSort()).Sort(new int[] { 34, 5, 38, 25, 51, 8, 33, 53, 21 })));
            Debug.Assert(Utility.IsSorted((new MergeSort()).Sort(new int[] { 34, 5, 38, 25, 51, 8, 33, 53, 21 })));
        }
    }
}
