using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Finding
{
    class Find21Take2
    {
        static Stack<string> stack = new Stack<string>();

        static void ClearStack()
        {
            stack.Clear();
        }

        static void PushToStack(object item)
        {
            stack.Push(item.ToString());
        }

        static void PopAndPush(object item)
        {
            if (stack.Count != 0)
            {
                stack.Pop();
            }
            stack.Push(item.ToString());
        }

        static void PopFromStack()
        {
            if (stack.Count != 0) // Protect over-popping
            {
                stack.Pop();
            }
        }

        static void ShowStack()
        {
            string[] items = stack.ToArray() as string[];
            Array.Reverse(items);
            Console.WriteLine(string.Join(" ", items));
        }

        static int[] Sort(int[] array)
        {
            Array.Sort(array);
            Array.Reverse(array);
            return array;
        }

        static int[] Deck = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };

        static void BuildLookupTable()
        {
            for (int term = 2; term <= Deck.Length; term++)
            {

            }
        }

        static bool Find21(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                int[] subarray = MakeSubArray(array, i);
                var current = array[i];
                ClearStack();
                PushToStack(current);
                if (Find21Internal(current, subarray))
                {
                    ShowStack();
                    return true;
                }
            }

            Console.WriteLine("21 not found.");
            return false;
        }

        static bool Find21Internal(int current, int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                PushToStack("x");
                PushToStack(array[i]);

                if (array[i] != 1) // Skip multipling 1. We know the product will be equal to the current
                {
                    var prod = current * array[i];
                    if (prod == 21)
                    {
                        return true;
                    }
                    else
                    {
                        int[] subarray = MakeSubArray(array, i);
                        if (Find21Internal(prod, subarray))
                        {
                            return true;
                        }
                    }
                }

                var sum = current + array[i];
                PopFromStack();
                PopAndPush("+");
                PushToStack(array[i]);
                if (sum == 21)
                {
                    return true;
                }
                else
                {
                    int[] subarray = MakeSubArray(array, i);
                    if (Find21Internal(sum, subarray))
                    {
                        return true;
                    }
                }

                var diff = current - array[i];
                PopFromStack();
                PopAndPush("-");
                PushToStack(array[i]);
                if (diff == 21)
                {
                    return true;
                }
                else
                {
                    int[] subarray = MakeSubArray(array, i);
                    if (Find21Internal(diff, subarray))
                    {
                        return true;
                    }
                }

                PopFromStack();
                PopFromStack();
            }

            return false;
        }

        static int[] MakeSubArray(int[] array, int index)
        {
            List<int> list = new List<int>(array);
            list.RemoveAt(index);
            return list.ToArray();
        }

        public static void TestFind21Take2()
        {
            Debug.Assert(Find21(new int[] { 7, 3 }));
            Debug.Assert(Find21(new int[] { 5, 1, 4 }));
            Debug.Assert(Find21(new int[] { 5, 2, 2, 1, 4 }));
            Debug.Assert(Find21(new int[] { 2, 1 }) == false);
            Debug.Assert(Find21(new int[] { 10, 3, 3 }));
            Debug.Assert(Find21(new int[] { 3, 3, 10 }));

            Debug.Assert(Find21(new int[] { 4, 7, 3 }));
            Debug.Assert(Find21(new int[] { 7, 3, 4 }));
            Debug.Assert(Find21(new int[] { 1, 1, 1, 7, 3, 4 }));


            // Let's sort them first
            Debug.Assert(Find21(Sort(new int[] { 7, 3 })));
            Debug.Assert(Find21(Sort(new int[] { 5, 1, 4 })));
            Debug.Assert(Find21(Sort(new int[] { 5, 2, 2, 1, 4 })));
            Debug.Assert(Find21(Sort(new int[] { 2, 1 })) == false);
            Debug.Assert(Find21(Sort(new int[] { 10, 3, 3 })));
            Debug.Assert(Find21(Sort(new int[] { 3, 3, 10 })));

            Debug.Assert(Find21(Sort(new int[] { 4, 7, 3 })));
            Debug.Assert(Find21(Sort(new int[] { 7, 3, 4 })));
            Debug.Assert(Find21(Sort(new int[] { 1, 1, 1, 7, 3, 4 })));
        }
    }
}
