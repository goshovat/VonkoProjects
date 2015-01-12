using System;

class SubsetWithSum0
{
    static void Main()
    {
        Console.WriteLine("Write how many numbers we will check: ");
        int n = 0;
        bool subsetFound = false;

        try
        {
            n = int.Parse(Console.ReadLine());
        }
        catch (FormatException)
        {
            Console.WriteLine("Please enter valid integer!");
            return;
        }
        Console.WriteLine();
        double[] arr = new double[n];

        Console.WriteLine("Enter {0} numbers", n);

        for (int i = 0; i < n; i++)
        {
            double input = double.Parse(Console.ReadLine());
            arr[i] = input;
        }

        for (int i = 0; i < n; i++)
        {
            double sum = 0;

            for (int j = i; j < n; j++)
            {   
                sum += arr[j];

                if (sum == 0)
                {
                    subsetFound = true;
                    Console.Write("Subset with sum zero is: ");
                    for (int counter = i; counter <= j; counter++)
                    {
                        Console.Write(arr[counter] + " ");
                    }
                    Console.WriteLine();
                }
            }
        }

        if (subsetFound == false)
        {
            Console.WriteLine("No subset with sum 0 found!");
        }
    }
}

