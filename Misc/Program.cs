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
            output = FindLargeAndSmallNoDup.ComputeFromArray(new int[] { 13, 13, 13, 0, 3, 5, 2, 0, 12, 11, 1 });
            Console.Write(output);
        }
    }
}
