using System;

class ShowSignOfProduct
{
    static void Main()
    {
        Console.WriteLine("Enter first number :");
        string firstInput = Console.ReadLine();
        int a = int.Parse(firstInput);

        Console.WriteLine("Enter second number :");
        string secondInput = Console.ReadLine();
        int b = int.Parse(secondInput);

        Console.WriteLine("Enter first number :");
        string thirdInput = Console.ReadLine();
        int c = int.Parse(thirdInput);

        if ((a > 0 && b > 0 && c > 0) || (a > 0 && b < 0 && c < 0) ||
            (a < 0 && b < 0 && c > 0) || (a < 0 && b > 0 && c < 0))
        {
            Console.WriteLine("The sign will be +");
        }
        else if ((a < 0 && b < 0 && c < 0) || (a < 0 && b > 0 && c > 0)
            || (a > 0 && b < 0 && c > 0) || (a > 0 && b > 0 && c < 0))
        {
            Console.WriteLine("The sign will be -");
        }
        else if (a == 0 || b == 0 || c == 0)
        {
            Console.WriteLine("The product will be zero!");
        }
    }
}

