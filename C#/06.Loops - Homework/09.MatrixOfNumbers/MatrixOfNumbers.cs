using System;

class MatrixOfNumbers
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter an integer:");
        int n = int.Parse(Console.ReadLine());
        for (int row = 1; row <= n; row++)
        {
            for (int col = row; col < row + n; col++)
            {
                Console.Write(col + " ");
            }
            Console.WriteLine();
        }
    }
}

