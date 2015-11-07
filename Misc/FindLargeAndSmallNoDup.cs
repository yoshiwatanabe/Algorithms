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

        public static string ComputeFromArray2(int[] input)
        {
            // This one uses arbitrary length array.
            // TODO: it won't make sense to have large/small arrays larger than input.length

            int[] largeGroup = new int[] { int.MinValue, int.MinValue, int.MinValue };
            int[] smallGroup = new int[] { int.MaxValue, int.MaxValue, int.MaxValue };

            foreach (int value in input)
            {
                Debug.Assert(value >= 0, "Only zero or positive number is allowed.");

                if (largeGroup.Contains(value) || smallGroup.Contains(value))
                {
                    continue;
                }

                int pos = -1;
                for (int i = largeGroup.Length-1; i > -1; i--)
                {
                    if (value > largeGroup[i])
                    {
                        pos = i;
                        break;
                    }
                }

                if (pos != -1)
                {
                    //
                    // The new value has a position in the large group.
                    //

                    int evicted = largeGroup[0]; // This will be pushed out of the group.
                    
                    for (int i = 0; i < pos; i++) // Shift the values, below pos.
                    {
                        largeGroup[i] = largeGroup[i + 1];
                    }

                    largeGroup[pos] = value; // Finally overwrite to the new position

                    // Only consider the evicted for small element group if it is one of the inputs.
                    if (evicted != int.MinValue)
                    {
                        int smallPos = -1;
                        for (int i = 0; i < smallGroup.Length; i++)
                        {
                            if (evicted < smallGroup[i])
                            {
                                smallPos = i;
                                break;
                            }
                        }

                        if (smallPos != -1)
                        {
                            for (int i = smallPos; i < smallGroup.Length - 1; i++) // Shift to right, exept the last one. Let the last one disappear
                            {
                                smallGroup[i + 1] = smallGroup[i];
                            }

                            smallGroup[smallPos] = evicted;
                        }
                    }
                }
                else
                {
                    int smallPos = -1;
                    for (int i = 0; i < smallGroup.Length; i++)
                    {
                        if (value < smallGroup[i])
                        {
                            smallPos = i;
                            break;
                        }
                    }

                    if (smallPos != -1)
                    {
                        for (int i = smallPos; i < smallGroup.Length -1; i++)
                        {
                            smallGroup[i + 1] = smallGroup[i];
                        }
                        smallGroup[smallPos] = value;
                    }
                }
            }

            return string.Format("Largest numbers are 	{0}, {1}, {2}\nSmallest numbers are    {3}, {4}",
                largeGroup[0], largeGroup[1], largeGroup[2],
                smallGroup[0], smallGroup[1]);
        }
    }
}
