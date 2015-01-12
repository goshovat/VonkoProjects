using System;

class SumN_Numbers
{
    static void Main()
    {
        Console.WriteLine("Write a whole number n: ");
        string number = Console.ReadLine();
        int numberInt;
        bool parseNumber = int.TryParse(number, out numberInt);
        Console.WriteLine();

        double sum = 0;

        if (parseNumber == true)
        {
            Console.WriteLine("Now enter {0} numbers to see their sum: ", numberInt);
            for (int i = 0; i < numberInt; i++)
            {
                string input = Console.ReadLine();
                double inputNumbers;
                bool parseInput = double.TryParse(input, out inputNumbers);

                if (parseInput == true)
                {
                    sum += inputNumbers;
                }
                else
                {
                    Console.WriteLine("Please enter valid numbers");
                    Console.WriteLine();
                    Main();
                }
                
            }
            Console.WriteLine("The sum is: {0}",sum);
        }
        else
        {
            Console.WriteLine("Please enter a proper whole number!");
            Console.WriteLine();
            Main();
        }
    }
}

