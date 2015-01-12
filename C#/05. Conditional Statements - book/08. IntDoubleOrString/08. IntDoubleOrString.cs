using System;

class IntDoubleOrString
{
    static void Main()
    {
        Console.WriteLine("Enter 1 for int, 2 for double and 3 for string:");
        int checker = int.Parse(Console.ReadLine());

        
        switch(checker) 
        {
            case 1:
            Console.WriteLine("Write your integer:");
            int inputInt = int.Parse(Console.ReadLine());
            inputInt++;
            Console.WriteLine("The input value is {0}", inputInt);
            break;

            case 2:
            Console.WriteLine("Write your double:");
            double inputDouble = double.Parse(Console.ReadLine());
            inputDouble++;
            Console.WriteLine("The input value is {0}", inputDouble);
            break;

            case 3:
            Console.WriteLine("Write your string:");
            string input = Console.ReadLine();
            input +="*";
            Console.WriteLine("The input value is {0}", input);
            break;
        }
    }
}

