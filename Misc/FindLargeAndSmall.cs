using System;
using System.Diagnostics;
using System.Linq;

namespace Misc
{
    class FindLargeAndSmall
    {
        public void Run()
        {
            string output;

            output = FindLargeAndSmall.ComputeFromArray(new int[] { 13, 0, 3, 5, 2, 0, 12, 11, 1 });
            Console.Write(output);

            // Test with duplicates. Duplicate should be removed.
            output = FindLargeAndSmall.ComputeFromArray(new int[] { 13, 13, 13, 0, 3, 5, 2, 0, 12, 11, 1 });
            Console.Write(output);

            // Test with duplicates. Duplicates should be allowed to be included.
            output = FindLargeAndSmall.ComputeFromArray(new int[] { 13, 13, 13, 0, 3, 5, 2, 0, 12, 11, 1 }, allowDuplicate: true);
            Console.Write(output);

            // Test a case where the number of input values is smaller than the total of small and large groups.
            output = FindLargeAndSmall.ComputeFromArray(new int[] { 13, 0, 4, 5 });
            Console.Write(output);
        }

        /// <summary>
        /// Detect large and small values in an input array.
        /// </summary>
        /// <param name="input">Input array of integer values. Negative values are not permitted.</param>
        /// <param name="largeGroupSize">Optional size of elements for "large" group</param>
        /// <param name="smallGroupSize">Optional size of elements for "small" group</param>
        /// <param name="allowDuplicate">Indicates whether duplicates may be included in the result groups</param>
        /// <returns>A formatted string of summary.</returns>
        /// <exception cref="Exception">A negative number is not allowed.</exception>
        public static string ComputeFromArray(int[] input, int largeGroupSize = 3, int smallGroupSize = 2, bool allowDuplicate = false)
        {
            int[] largeGroup = Enumerable.Repeat(int.MinValue, largeGroupSize).ToArray();
            int[] smallGroup = Enumerable.Repeat(int.MaxValue, smallGroupSize).ToArray();

            foreach (int value in input)
            {
                if (value < 0)
                {
                    throw new Exception("A negative number is not allowed.");
                }
                
                if (!allowDuplicate)
                {
                    if (largeGroup.Contains(value) || smallGroup.Contains(value))
                    {
                        continue;
                    }
                }

                // Check to see if it should be part of the large group.
                int posInLarge = -1;
                for (int i = largeGroup.Length - 1; i > -1; i--)
                {
                    if (value > largeGroup[i])
                    {
                        posInLarge = i;
                        break;
                    }
                }

                if (posInLarge != -1)
                {
                    int evicted = largeGroup[0]; // This will be pushed out of the group, but may be part of the small group.

                    // Shif to the left at the position where a new value is to be set.
                    for (int i = 0; i < posInLarge; i++)
                    {
                        largeGroup[i] = largeGroup[i + 1];
                    }

                    // The new value is now part of the large group at appropriate location.
                    largeGroup[posInLarge] = value;

                    // The value fall off of the large group may still be part of the small group.
                    // Make sure not to process our internal initial values.
                    if (evicted != int.MinValue)
                    {
                        // Check to see if it should be part of the small group.
                        int posInSmall = -1;
                        for (int i = 0; i < smallGroup.Length; i++)
                        {
                            if (evicted < smallGroup[i])
                            {
                                posInSmall = i;
                                break;
                            }
                        }

                        if (posInSmall != -1)
                        {
                            // Shift elements to the right of the position where a new value will be set.
                            for (int i = posInSmall; i < smallGroup.Length - 1; i++)
                            {
                                smallGroup[i + 1] = smallGroup[i];
                            }

                            smallGroup[posInSmall] = evicted;
                        }
                    }
                }
                else
                {
                    // Check to see if it should be part of the small group.
                    int posInSmall = -1;
                    for (int i = 0; i < smallGroup.Length; i++)
                    {
                        if (value < smallGroup[i])
                        {
                            posInSmall = i;
                            break;
                        }
                    }

                    if (posInSmall != -1)
                    {
                        // Shift elements to the right of the position where a new value will be set.
                        for (int i = posInSmall; i < smallGroup.Length - 1; i++)
                        {
                            smallGroup[i + 1] = smallGroup[i];
                        }
                        smallGroup[posInSmall] = value;
                    }
                }
            }

            return string.Format("\nLargest numbers are 	{0}\nSmallest numbers are    {1}",
                string.Join(", ", largeGroup.SkipWhile(v => v == int.MinValue).ToArray()),
                string.Join(", ", smallGroup.TakeWhile(v => v != int.MaxValue).ToArray()));
        }

        public static string ComputeFromArrayNaive(int[] input)
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

            return string.Format("\nLargest numbers are 	{0}, {1}, {2}\nSmallest numbers are    {3}, {4}",
                large, larger, largest,
                smallest, smaller);
        }
    }
}

