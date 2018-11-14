using System.Diagnostics;

namespace Sort
{
    public class InsertionSort
    {
        public int[] Sort(int[] array)
        {
            // [a]
            for (int i = 1; i < array.Length; i++)
            {
                // [b]
                int current = array[i];

                // [c]
                for (int j = 0; j < i; j++) // Scan from 0 to i-1 
                {
                    // [d]
                    if (current < array[j])
                    {
                        // [e]
                        for (int k = i; k > j; k--)
                        {
                            array[k] = array[k - 1]; // k receives k-1 value
                        }

                        // [f]
                        array[j] = current; // This is the actual insertion

                        // [g]
                        break; // Terminate the innner loop since we already process the 'i'. Move on to the next one.
                    }
                }
            }

            return array;
        }
    }
}
