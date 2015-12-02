using System.Diagnostics;

namespace Sort
{
    partial class Program
    {
        // Insersion sort
        // Imagein a cards on left hand
        // touch the [1] card, then see [0] card and see if I should swap.
        // touch the [2] card, then see [0] and [1] cards and see if I can insert [2] into somewhere in [0] and [1]
        // touch the [3] card, then see [0], [1], and [2] cards, see if we can insert..


        public static void RunInsertionSort(int[] array)
        {
            for (int i = 1; i < array.Length; i++) // Tip: start the 2nd element
            {
                int valToCheck = array[i]; // Tip: why save to local? If insertion opration to take place, 
                // shifting to right would overwrite this value.
                for (int j = 0; j < i; j++) // Tip: we scan from 0 to i-1 to see if valToCheck has a place
                // to be "inserted"
                {
                    if (array[j] > valToCheck)
                    {
                        for (int k = i; k > j; k--) // Tip: why? making a room so we can insert valToCheck
                        {
                            array[k] = array[k - 1]; // Tip: k receives k-1 value
                        }

                        array[j] = valToCheck; // Tip: this is the insertion
                        break; // inseted. done
                    }
                }
            }

        }


        public static void TestInsertionSort()
        {
            int[] array = new int[] { 34, 5, 38, 25, 51, 8, 33, 53, 21 };
            RunInsertionSort(array);
            Debug.Assert(IsSorted(array));
        }

    }
}
