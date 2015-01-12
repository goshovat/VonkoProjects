using System;
using System.Collections.Generic;

class SSystemToDSystem
{
    static void Main()
    {
        Console.WriteLine("Enter the base of the first system: ");
        int firstSystemBase = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter the base of the second system: ");
        int secondSystemBase = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter a number in the first system, too see it's representation in the second: ");
        int numberInFirstSystem = int.Parse(Console.ReadLine());

        string result = string.Join("", ConvertFirstSystemToSecond(numberInFirstSystem, firstSystemBase, secondSystemBase));

        Console.WriteLine("The number in the second system is: {0}", result);
    }

    static List<int> ConvertFirstSystemToSecond(int numberInFirstSystem, int firstSystemBase, int secondSystemBase)
    {
        List<int> result = new List<int>();

        string firstNumString = numberInFirstSystem.ToString();

        //first convert the number to decimal
        int numberInDecimal = 0;

        for (int len = firstNumString.Length, i = len - 1; i >= 0; i--)
        {
            numberInDecimal +=(int)Math.Pow((double)firstSystemBase, (double)(len - i - 1))*
                               int.Parse(firstNumString[i].ToString());
        }

        //now convert the number to the new system
        while (numberInDecimal != 0)
        {
            int currentDigit = numberInDecimal % secondSystemBase;

            result.Insert(0, (int)currentDigit);

            numberInDecimal /= secondSystemBase;
        }

        return result;
    }
}

