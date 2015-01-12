using System;

class SumOfNNumbers
{
    static void Main()
    {
        Console.WriteLine("Write a random integer n: ");
        string input = Console.ReadLine();
        Console.WriteLine();
        int n;

        if ((int.TryParse(input, out n)))
        {
            Console.WriteLine("Write {0} numbers to see their sum: ", n);
            double temp = 0;
            double sum = 0;

            for (int i = 0; i < n; i++)
            {
                string inputN = Console.ReadLine();
               
                if (double.TryParse(inputN, out temp)) 
                {
                    sum += temp;              
                }
                else
                {
                    Console.WriteLine("Please enter valid numbers!");   
                    Console.WriteLine();
                    Main();
                }
                
            }
            Console.WriteLine("The sum of the numbers is: {0}", sum);
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("Please enter a valid number!");
            Console.WriteLine();
            Main();
        }
    }
}

