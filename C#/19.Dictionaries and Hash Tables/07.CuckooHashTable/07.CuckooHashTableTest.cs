using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuckooHashTable
{
    class CuckooHashTableTest
    {
        static void Main()
        {
            CuckooHashTable<string, int> testTable = new CuckooHashTable<string, int>();
            testTable["vonko"] = 5;
            testTable["goshko"] = 6;

            Console.WriteLine(testTable["goshko"]);
            testTable["goshko"] = 4;
            Console.WriteLine(testTable["goshko"]);

            Console.WriteLine(DateTime.Now);
            //test the expand method
            for (int i = 0; i < 1000; i++)
            {
                testTable["test" + i] = 2;
            }

            Console.WriteLine(testTable.Count);
            Console.WriteLine(DateTime.Now);
        }
    }
}
