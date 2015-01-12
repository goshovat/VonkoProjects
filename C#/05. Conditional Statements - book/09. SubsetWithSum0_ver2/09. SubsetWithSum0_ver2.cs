using System;

class SubsetWithSum0_ver2
{
    static void Main()
    {
        Console.WriteLine("Enter five numbers: ");
        Console.WriteLine();
        int count = 5;
        double[] arr = new double[count];
        bool subsetFound = false;

        try
        {
            Console.WriteLine("Enter number a: ");
            arr[0] = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter number b: ");
            arr[1] = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter number c: ");
            arr[2] = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter number d: ");
            arr[3] = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter number e: ");
            arr[4] = double.Parse(Console.ReadLine());
            Console.WriteLine();
        }
        catch (FormatException)
        {
            Console.WriteLine("Please enter valid numbers!");
            return;
        }

        for (int startPos = 0; startPos < count; startPos++)
        {
            double sum = 0;

            for (int endPos = startPos; endPos < count; endPos++)
            {
                sum += arr[endPos];

                if (sum == 0)
                {
                    subsetFound = true;

                    for (int i = startPos; i <= endPos; i++)
                    {
                        Console.WriteLine("{0}", arr[i]);
                    }
                }
            }
        }
        if (subsetFound == false)
        {
            Console.WriteLine("No such subset found!");
        }
    }
}

