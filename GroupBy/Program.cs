using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace GroupBy
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 4, 5, 2, 7, 13, 19, 13, 21 };
            OrderByModulo(array, 4);
            PrintArray(array, 4);
            Debug.Assert(OrderedInModule(array, 4));

            array = new int[] { 4, 5, 2, 7, 13, 19, 13, 21 };
            OrderByModulo(array, 3);
            PrintArray(array, 3);
            Debug.Assert(OrderedInModule(array, 3));
        }

        public static void OrderByModulo(int[] array, int moduloValue)
        {
            int pos = 0;
            int rem = 0;

            while (rem != moduloValue)
            {
                for (int i = pos; i < array.Length; i++)
                {
                    int remainder = array[i] % moduloValue;
                    if (remainder == rem)
                    {
                        int temp = array[pos];
                        array[pos] = array[i];
                        array[i] = temp;
                        pos++;

                        PrintArray(array);
                    }
                }

                rem++;
            }
        }

        public static void PrintArray(int[] array, int? moduloValue = null)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < array.Length; i++)
            {
                builder.AppendFormat("{0}", moduloValue.HasValue ? array[i] % moduloValue.Value : array[i]);
                if (i != array.Length - 1)
                {
                    builder.Append(",");
                }
            }

            Console.WriteLine(builder.ToString());
        }

        public static bool OrderedInModule(int[] array, int moduloValue)
        {
            // val =
            // 0, 1, 2, 3
            // %, %+1, %+2, %+4
            int rem = 0;

            for (int i = 0; i < array.Length; i++)
            {
                int remainder = array[i] % moduloValue;
                if (remainder == rem)
                {
                    continue;
                }
                else if (remainder > rem)
                {
                    rem = remainder;
                    continue;
                }

                return false;
            }                
         
            return true;
        }
    }
}
