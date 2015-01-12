using System;

class PrintNumbers1toN
{
    static void Main()
    {
        Console.WriteLine("Please enter a number: ");
        string number = Console.ReadLine();
        int numberInt;
        bool parseNumber = int.TryParse(number, out numberInt);
        Console.WriteLine();

        if (parseNumber)
        {
            Console.WriteLine("The numbers from 1 to n are: ");
            
            for (int i = 1; i <= numberInt; i++)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("Please enter a valid number!");
            Console.WriteLine();
            Main();
        }
    }
}

