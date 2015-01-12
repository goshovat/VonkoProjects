using System;
class OddOrEven
{
    static void Main()
    {
        Console.WriteLine("Write the number, bitch!");
        string input = Console.ReadLine();
        int n = Convert.ToInt32(input);
        
        if (n == 0)
        {
            Console.WriteLine("The number is zero");
        }
        else
        {
            if (n % 2 == 0)
            {
                Console.WriteLine("The number is even :)");
            }
            else
            {
                Console.WriteLine("The number is odd, bitch!");
            }
        }
    }
}
