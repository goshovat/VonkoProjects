using System;

class IsItDividableBy5and7
{
    static void Main()
    {
        Console.WriteLine("Write the number, bitch");
        string input = Console.ReadLine();
        int n = Convert.ToInt32(input);

        if ((n % 5 == 0) && (n % 7 == 0))
        {
            Console.WriteLine("The number can be divided by 5 and 7 at the same time");
        }
        else
        {
            Console.WriteLine("The number CANNOT be divided by 5 and 7 at the same time");
        }
    }
}

