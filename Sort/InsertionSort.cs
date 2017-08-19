using System.Diagnostics;

namespace Sort
{
    public class InsertionSort
    {
        // Insersion sort
        // Imagein a cards on left hand
        // touch the [1] card, then see [0] card and see if I should swap.
        // touch the [2] card, then see [0] and [1] cards and see if I can insert [2] into somewhere in [0] and [1]
        // touch the [3] card, then see [0], [1], and [2] cards, see if we can insert..

        public int[] Sort(int[] array)
        {
            int[] result = array.Clone() as int[];

            // The outer loop iterates n-1 elements using the index 'i' starting from 1.
            // The subarray left of 'i' is always sorted. The next element at 'i' is either inserted
            // somewhere, including inserted at the very beginning, or not inserted and stays where it were 
            // (this is because the element was bigger than any of the elements in the subarray.
            for (int i = 1; i < result.Length; i++) // Start from the 2nd element
            {
                // First, save the value being checked to a local variable. Its because if 
                // an insertion operation would take place later, it would involve shifting
                // all elements of subarray to the right, which overwrites the element at 'i'.                
                int valToCheck = result[i]; 
                
                // The inner loop is to iterate the sorted subarray to the left of 'i'. The very first
                // iteration will only iterate over a single-element subarray (this is why the code may
                // look a bit strange).
                for (int j = 0; j < i; j++) // Scan from 0 to i-1 
                {
                    // See if valToCheck is less than an element in the subarray.
                    if (result[j] > valToCheck)
                    {
                        // Found an element in the subarray that is bigger than the value checked. 
                        // This means we have to insert the value at the *left" of the element in the subarray.
                        // This requires shifting the elements, starting from the element, to the right.
                        // This way, it makes a room for the smaller element to be written in front.
                        for (int k = i; k > j; k--)
                        {
                            result[k] = result[k - 1]; // k receives k-1 value
                        }

                        result[j] = valToCheck; // This is the actual insertion
                        break; // Terminate the innner loop since we already process the 'i'. Move on to the next one.
                    }
                }
            }

            return result;
        }
    }
}
