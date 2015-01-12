using System;
using System.Collections.Generic;

namespace PrintPosIntsReverseOrder
{
    class PrintPosIntsReverseOrder
    {
        static void Main()
        {
            Console.WriteLine("Input N: ");
            Stack<uint> stack = new Stack<uint>();

            try
            {
                int n = int.Parse(Console.ReadLine());

                Console.WriteLine("Input {0} positive integers: ", n);

                for (int i = 0; i < n; i++)
                {
                    stack.Push(uint.Parse(Console.ReadLine()));
                }
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

            Console.WriteLine("The numbers in reversed order are:");
            while (stack.Count > 0)
            {
                Console.Write(stack.Pop() + " ");
            }
        }
    }
}
