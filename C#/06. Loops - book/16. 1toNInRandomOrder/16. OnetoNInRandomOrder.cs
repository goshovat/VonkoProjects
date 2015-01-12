using System;
using System.Linq;

class OnetoNInRandomOrder
{
    static void Main()
    {
        Console.Write("Enter a positive number N: ");
        int n = 0;
        Random randomOrder = new Random();
        int randomPos1 = 0;
        int randomPos2 = 0;

        try
        {
            n = int.Parse(Console.ReadLine());
        }
        catch (FormatException)
        {
            Console.WriteLine("Enter a valid number!");
            return;
        }

        if (n > 0)
        {
            int[] arr = new int[n];
            int temp = 0;

            for (int i = 0, j = 1; i < n; i++, j++)
            {
                arr[i] = j;
            }

            for (int i = 0; i < n * n; i++)
            {
                randomPos1 = randomOrder.Next(0, n);
                randomPos2 = randomOrder.Next(0, n);
                temp = arr[randomPos1];
                arr[randomPos1] = arr[randomPos2];
                arr[randomPos2] = temp;
            }

            for (int i = 0; i < n; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("Enter a positive number!");
        }
    }
}

 