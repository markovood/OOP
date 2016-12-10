using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExtensions
{
    public static class MyStringReverse
    {
        public static string MyReverse(this string someString)
        {
            StringBuilder result = new StringBuilder();
            for (int i = someString.Length - 1; i >= 0; i--)
            {
                result.Append(someString[i]);
            }

            return result.ToString();
        }
    }
}
