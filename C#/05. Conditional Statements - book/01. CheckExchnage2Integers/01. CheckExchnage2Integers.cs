using System;


class CheckExchnage2Integers
{
    static void Main()
    {
        Console.WriteLine("Write first integer: ");
        string firstInput = Console.ReadLine();
        int a = int.Parse(firstInput);

        Console.WriteLine("Write second integer: ");
        string secondInput = Console.ReadLine();
        int b = int.Parse(secondInput);

        if (a > b)
        {
            a = a + b;
            b = a - b;
        }

        Console.WriteLine("The second integer is: {0}", b);
    }
}
