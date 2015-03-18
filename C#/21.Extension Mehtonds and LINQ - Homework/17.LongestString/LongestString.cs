using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestString
{
    class LongestString
    {
        static void Main()
        {
            string[] arr = new string[] { "gosho", "ivan", "stanimir", "pesho", "mika" };

            var longestString = (from str in arr
                                orderby str.Length descending
                                select str).FirstOrDefault();

            Console.WriteLine(longestString);
        }
    }
}
