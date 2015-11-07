using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Misc
{
    class FindLargeAndSmall
    {
        public static string ComputeFromArray(int[] input)
        {
            int largest, larger, large;
            largest = larger = large = 0;
            int smallest, smaller;
            smallest = smaller = int.MaxValue;

            foreach (int value in input)
            {
                if (value > large)
                {
                    int formerLarge = larger;
                    large = value;

                    if (formerLarge < smaller)
                    {
                        smaller = formerLarge; // we can discard the former smaller
                        if (smaller < smallest)
                        {
                            int formerSmallest = smallest;
                            smallest = smaller;
                            smaller = formerSmallest;
                        }
                    }

                    if (large > larger)
                    {
                        int temp = larger;
                        larger = large;
                        large = temp;

                        if (larger > largest)
                        {
                            temp = largest;
                            largest = larger;
                            larger = temp;
                        }
                    }

                    // note: don't forget to process the evicted one against small group
                }
                else if (value < smaller)
                {
                    // The value will take over either smaller or smallest
                    smaller = value;

                    if (smaller < smallest)
                    {
                        int temp = smallest;
                        smallest = smaller;
                        smaller = temp;
                    }
                }
                
                // The value fall in-between the small and large groups. Nothing to do.                
            }
            return "Todo";
        }
    }
}
