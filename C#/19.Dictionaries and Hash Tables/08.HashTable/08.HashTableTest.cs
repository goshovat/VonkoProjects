using System;
using System.Collections.Generic;

namespace HashTable
{
    class HashTableTest
    {
        static void Main()
        {
            HashTable<string, int> testTable = new HashTable<string, int>();
            testTable["vonko"] = 5;
            testTable["goshko"] = 6;

            Console.WriteLine(testTable["goshko"]);
            testTable["goshko"] = 4;
            Console.WriteLine(testTable["goshko"]);
            Console.WriteLine(testTable.Get("goshko"));

            testTable.Remove("goshko");
            Console.WriteLine(testTable.Count);

            //test the expand method
            for (int i = 0; i < 1000; i++)
            {
                testTable["test" + i] = 2;
            }

            Console.WriteLine(testTable.Count);
        }
    }
}
