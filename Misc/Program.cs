using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Misc
{
    class Program
    {
        static void Main(string[] args)
        {
            string output;
            
            output = FindLargeAndSmall.ComputeFromArray(new int[] { 13, 0, 3, 5, 2, 0, 12, 11, 1 });
            Console.Write(output);

            // Test with duplicates. Duplicate should be removed.
            output = FindLargeAndSmall.ComputeFromArray(new int[] { 13, 13, 13, 0, 3, 5, 2, 0, 12, 11, 1 });
            Console.Write(output);

            // Test with duplicates. Duplicates should be allowed to be included.
            output = FindLargeAndSmall.ComputeFromArray(new int[] { 13, 13, 13, 0, 3, 5, 2, 0, 12, 11, 1 }, allowDuplicate:true);
            Console.Write(output);

            // Test a case where the number of input values is smaller than the total of small and large groups.
            output = FindLargeAndSmall.ComputeFromArray(new int[] { 13, 0, 4, 5});
            Console.Write(output);
        }
    }
}
