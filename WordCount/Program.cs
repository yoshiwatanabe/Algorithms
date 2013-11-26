using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace WordCount
{
    partial class Program
    {
        static void Main(string[] args)
        {
            Debug.Assert(CountWords("Hello world") == 2);
            Debug.Assert(CountWords("    Hello world") == 2);
            Debug.Assert(CountWords("Hello world    ") == 2);
            Debug.Assert(CountWords("Hello      world") == 2);

            char[] word = new char[] { 'a', 'b', 'c', 'd' };
            ReverseString(word);
            word = new char[] { 'a', 'b', 'c', 'd', 'e' };
            ReverseString(word);
        }

        public static void Swap<T>(T[] array, int pos1, int pos2)
        {
            if (pos1 != pos2)
            {
                T temp = array[pos1];
                array[pos1] = array[pos2];
                array[pos2] = temp;
            }
        }

        public static int CountWords(string test)
        {
            int count = 0;
            bool wasInWord = false;
            bool inWord = false;

            for (int i = 0; i < test.Length; i++)
            {
                if (inWord)
                {
                    wasInWord = true;
                }

                if (Char.IsWhiteSpace(test[i]))
                {
                    if (wasInWord)
                    {
                        count++;
                        wasInWord = false;
                    }
                    inWord = false;
                }
                else
                {
                    inWord = true;
                }
            }

            // Check to see if we got out with seeing a word
            if (wasInWord)
            {
                count++;
            }

            return count;
        }
    }
}
