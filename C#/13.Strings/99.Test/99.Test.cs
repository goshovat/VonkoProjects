using System;
using System.Collections.Generic;

namespace Test
{
    class Test
    {
        static void Main(string[] args)
        {
            string str1 = "1";
            Concat1(str1);
            Console.WriteLine(str1); // 1

            string str2 = "1";
            Concat2(str2);
            Console.WriteLine(str2); // 1

            string str3 = "1";
            Concat3(str3);
            Console.WriteLine(str3); // 1

            string str4 = "1";
            Concat4(ref str4);
            Console.WriteLine(str4); //11
        }

        static void Concat1(string inputString)
        {
            inputString += 1;
        }

        static void Concat2(string inputString)
        {
            string.Concat(inputString + 1);
        }

        static string Concat3(string inputString)
        {
            return inputString + 1;
        }

        static void Concat4(ref string inputString)
        {
            inputString += 1;
        }
    }
}
