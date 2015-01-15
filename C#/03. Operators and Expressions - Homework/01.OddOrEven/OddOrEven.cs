using System;
class OddOrEven
{
    static void Main()
    {
        //if the number is odd will displaye true, otherwise - false
        Console.WriteLine("Write the number:");
        string input = Console.ReadLine();
        int number = int.Parse(input);

        if (number % 2 == 0)
        {
            Console.WriteLine(false);
        }
        else
        {
            Console.WriteLine(true);
        }
    }
}
