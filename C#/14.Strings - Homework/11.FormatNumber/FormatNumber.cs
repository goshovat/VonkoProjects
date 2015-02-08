using System;

class FormatNumber
{
    static void Main()
    {
        int number = 0;
        Console.WriteLine("Enter an integer to see it displayed in different formatting:");

        if (!int.TryParse(Console.ReadLine(), out number))
        {
            Console.WriteLine("Incorrect number!");
            return;
        }
        PrintFormattedNumber(number);
    }

    static void PrintFormattedNumber(int number)
    {
        Console.WriteLine(string.Format("{0:F2}", number).PadLeft(15, '*'));
        Console.WriteLine(string.Format("{0:X4}", number).PadLeft(15, '*'));
        Console.WriteLine(string.Format("{0:P0}", number).PadLeft(15, '*'));
        Console.WriteLine(string.Format("{0:C0}", number).PadLeft(15, '*'));
        Console.WriteLine(string.Format("{0:E4}", number).PadLeft(15, '*'));
    }
}

