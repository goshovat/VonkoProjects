using System;

class DivideBy5and7
{
    static void Main()
    {
        string input = Console.ReadLine();
        int number = Convert.ToInt32(input);
        if ((number % 5 == 0) && (number % 7 == 0))
        {
            Console.WriteLine("The number is can be divided by 5 and 7 at the same time");
        }
        else
        {
            Console.WriteLine("The number CANNOT be divided by 5 and 7 at the same time");
        }
    }
}

