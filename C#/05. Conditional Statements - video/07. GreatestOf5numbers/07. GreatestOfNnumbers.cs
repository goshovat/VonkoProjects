using System;

class GreatestOfNnumbers
{
    static void Main()
    {
        Console.WriteLine("Enter how many numbers you like to check: ");

        double a = 0;
        double b = 0;
        double biggest = 0;

        try
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("Enter the numbers to see which is the biggest: ");

            a = int.Parse(Console.ReadLine());
            biggest = a;
            for (int i = 0; i < n-1; i++)
            {
                b = int.Parse(Console.ReadLine());
                if (b > biggest)
                {
                    biggest = b;
                }
            }
            Console.WriteLine();
            Console.WriteLine("The biggest number is {0}", biggest);
        }
        catch (FormatException)
        {
            Console.WriteLine("Please enter valid numbers!");
        }  
    }
}

