using System;
using System.Collections.Generic;

namespace SortIntegerSeq
{
    class SortIntegerSeq
    {
        static void Main()
        {
            Console.WriteLine("Input a sequence of positive integers to see them sort. Stop the input by inputting empty row:");
            string input = Console.ReadLine();

            List<uint> integerList = new List<uint>();

            try
            {
                while (input != "")
                {
                    integerList.Add(uint.Parse(input));
                    input = Console.ReadLine();
                }

                integerList.Sort();
            }
            catch (FormatException formatExc)
            {
                Console.WriteLine(formatExc.Message);
                Console.WriteLine(formatExc.StackTrace);
            }
            catch (OverflowException overflowExc)
            {
                Console.WriteLine(overflowExc.Message);
                Console.WriteLine(overflowExc.StackTrace);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }

            foreach (uint number in integerList)
            {
                Console.Write(number + " ");
            }
        }
    }
}
