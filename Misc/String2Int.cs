using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Misc
{
    public class String2Int
    {
        public static int TestAToI(string str = "2017")
        {
            int acm = 0;

            for (int i = 0; i < str.Length; i++)
            {
                acm = acm * 10 + int.Parse(str.Substring(i, 1));
            }

            return acm;
        }
    }
}
