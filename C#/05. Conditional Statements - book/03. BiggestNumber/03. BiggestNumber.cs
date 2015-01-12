using System;

class BiggestNumber
{
    static void Main()
    {
        Console.WriteLine("Enter how many numbers we will check: ");
        int howMany = int.Parse(Console.ReadLine());
        Console.WriteLine();

        double[] arr = new double[howMany];

        double temp = 0;

        for (int i = 0; i < arr.Length; i++)
        {
            Console.WriteLine("Write first number: ");
            arr[i] = double.Parse(Console.ReadLine());
        }

        for (int i = 0; i < arr.Length; i++)
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

