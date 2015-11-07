using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Misc
{
    class FindLargeAndSmall
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <remarks>
        /// Assumptions:
        /// Input does not include negative numbers.
        /// </remarks>
        public static string ComputeFromArray(int[] input)
        {
            int largest, larger, large;
            largest = larger = large = int.MinValue;
            int smallest, smaller;
            smallest = smaller = int.MaxValue;

            foreach (int value in input)
            {
                Debug.Assert(value >= 0, "Only zero or positive number is allowed.");

                if (value > large)
                {
                    int formerLarge = larger;
                    large = value;

                    if (formerLarge != int.MinValue && // Initial values of int.MinValue (negative number) must not get into small group.
                        formerLarge < smaller)
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
