using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Misc
{
    class FindLargeAndSmallNoDup
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

                if (value == largest || value == larger || value == large || value == smaller || value == smallest)
                {
                    continue;
                }

                if (value > largest)
                {
                    int evicted = large;
                    large = larger;
                    larger = largest;
                    largest = value;

                    if (evicted == int.MinValue)
                    {
                        // Our inital value is not part of the input. Let it disappear from the world.
                        continue;
                    }

                    if (evicted < smallest)
                    {
                        smaller = smallest;
                        smallest = evicted;
                    }
                    else if (evicted < smaller)
                    {
                        smaller = evicted;
                    }
                }                
                else if (value > larger)
                {
                    int evicted = large;
                    large = larger;
                    larger = value;

                    if (evicted == int.MinValue)
                    {
                        continue;
                    }

                    if (evicted < smallest)
                    {
                        smaller = smallest;
                        smallest = evicted;
                    }
                    else if (evicted < smaller)
                    {
                        smaller = evicted;
                    }
                }
                else if (value > large)
                {
                    int evicted = large;
                    large = value;

                    if (evicted == int.MinValue)
                    {
                        continue;
                    }

                    if (evicted < smallest)
                    {
                        smaller = smallest;
                        smallest = evicted;
                    }
                    else if (evicted < smaller)
                    {
                        smaller = evicted;
                    }
                }
                else if (value < smallest)
                {
                    smaller = smallest;
                    smallest = value;
                }
                else if (value < smaller)
                {
                    smaller = value;
                }       
            }

            return string.Format("Largest numbers are 	{0}, {1}, {2}\nSmallest numbers are    {3}, {4}",
                large, larger, largest,
                smallest, smaller);
        }
    }
}
