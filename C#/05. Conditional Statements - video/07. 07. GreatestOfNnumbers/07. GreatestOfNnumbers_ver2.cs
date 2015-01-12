using System;

class GreatestOfNnumbers
{
    static void Main()
    {
        Console.WriteLine("Write how many numbers you like to check:");

        try
        {
            int n = int.Parse(Console.ReadLine());
            double[] arr = new double[n];
            Console.WriteLine();
           
            Console.WriteLine("Enter {0} real numbers to see which is the biggest: ", n);
            for (int i = 0; i < n; i++)
            {
                double input = double.Parse(Console.ReadLine());
                arr[i] = input;
            }

            for (int i = 0; i < n; i++)
            {
                if (arr[0] < arr[i])
                {
                    double temp = 0;
                    temp = arr[0];
                    arr[0] = arr[i];
                    arr[i] = temp;
                }
            }

            Console.WriteLine("The biggest number is: {0}",arr[0]);
            Console.WriteLine();
        }
        catch (FormatException)
        {
            Console.WriteLine("Please enter valid numbers!");
        }
    }
}

