using System;
using System.Collections.Generic;

namespace FixBookCode
{
    class FixBookCode
    {
        public static int fCharCode = (int)'f';

        static void Main()
        {
            int param = 1;
            int value1 = 5;
            int value2 = 0;

            switch (param)
            {
                case 10: 
                    value2 = 5; 
                    Console.WriteLine(value2); 
                    break;
                case 9:
                    value1 = 0;
                    Console.WriteLine("Value 1: {0}", value1);
                    break;
                case 8: 
                    Console.WriteLine("Param: {0}", param); 
                    break;
                default: 
                    Console.WriteLine("Default case, baby!");
                    for (int i = 0; i < value1; i++)
                    {
                        Console.WriteLine("Index - fCharCode: {0}", i - fCharCode);
                    }
                    break;                 
            }
        }
    }
}
