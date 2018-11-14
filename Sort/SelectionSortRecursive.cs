namespace Sort
{
    public class SelectionSortRecursive
    {
        public int[] Sort(int[] array)
        {
            SelectMinimum(array, 0);
            return array;
        }

        public static void SelectMinimum(int[] array, int index)
        {
            if (index == array.Length - 1)
            {
                return;
            }

            // This block's goal is to obtain the position of the smallest element
            // by comparing to the "current smallest element" (pointed to by the smallerPos)
            // until the iterator index falls off of the end of the array.           
            int min = index;
            for (int i = index + 1; i < array.Length; i++)
            {
                if (array[i] < array[min])
                {
                    min = i;
                }
            }

            int temp = array[index];
            array[index] = array[min];
            array[min] = temp;

            SelectMinimum(array, index + 1); // Recursively process the array, one element less than we have
        }

        // Visualize. With a given set to be sorted, we do a series of comparison to choose the smallest
        // but the set becomes smaller progressively as we find the smallest from the entire set.
        // Imagine a recursive stack where closer it gets to the top of the stack, the comparison loop
        // becomes shorter.
    }
}
