using System;

class TheBiggestOf5Numbers
{
    static void Main()
    {
        Console.WriteLine("Enter five numbers to check which is the biggest: ");
        Console.WriteLine();

        double[] arr = new double[5];
        double temp = 0;

        for (int i = 0; i < 5; i++)
        {
            double n = double.Parse(Console.ReadLine());
            arr[i] = n;
        }

        for (int i = 0; i < 5; i++)
        {
            if (arr[0] < arr[i])
            {
                temp = arr[0];
                arr[0] = arr[i];
                arr[i] = temp;
            }
        }

        Console.WriteLine("The biggest number is: {0}", arr[0]);
    }
}

