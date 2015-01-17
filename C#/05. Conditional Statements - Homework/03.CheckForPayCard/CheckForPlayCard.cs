using System;


class CheckForPayCard
{
    static void Main()
    {
        Console.WriteLine("Enter a playing card symbol: ");
        string input = Console.ReadLine();

        if (input == "2" || input == "3" || input == "4" || input == "5"
            || input == "6" || input == "7" || input == "8" || input == "9"
            || input == "10" || input == "J" || input == "Q" || input == "K" || input == "A")
        {
            Console.WriteLine("yes");
        }
        else
        {
            Console.WriteLine("No");
        }
    }
}
