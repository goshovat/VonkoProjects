using System;

class BiggestAndSmallestNumber
{
    static void Main()
    {
        Console.Write("Enter how many numbers you like to check: ");
        int n = 0;
        
        try
        {
           n = int.Parse(Console.ReadLine());
        }
        catch (FormatException)
        {
            Console.WriteLine("Enter a valid number!");
        }

        if (n > 0)
        {
            int[] arr = new int[n];
            int smallest = int.MaxValue;
            int biggest = int.MinValue;
            Console.WriteLine();
            Console.WriteLine("Enter the numbers you like to check: ");

            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }

            foreach (int number in arr)
            {
                if (number < smallest)
                {
                    smallest = number;
                }
                if (number > biggest)
                {
                    biggest = number;
                }
            }

            Console.WriteLine("The smallest number is: {0}", smallest);
            Console.WriteLine("The biggest number is: {0}", biggest);
        }
        else
        {
            Console.WriteLine("Enter a valid number!");
        }
    }
}

