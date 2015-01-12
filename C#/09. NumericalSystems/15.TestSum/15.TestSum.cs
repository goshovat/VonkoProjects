using System;

class TestSum
{
    static void Main()
    {
        float numberInFloat = 0.000001f;

        double numberInDouble = 0.000001;

        decimal numberInDecimal = 0.000001m;

        float floatResult = 0f;
        double doubleResult = 0d;
        decimal decimalResult = 0m;
        
        //first sum with float
        for (int i = 0; i < 50000000; i++) 
        {
            floatResult += numberInFloat;
            doubleResult += numberInDouble;
        }

        Console.WriteLine("The result in float is: {0}", floatResult);
        Console.WriteLine("The result in double is: {0}", doubleResult);

        Console.WriteLine("To see the result in double, type 'yes': ");
        string command = Console.ReadLine();

        if (command == "yes")
        {
            for (int i = 0; i < 50000000; i++)
            {
                decimalResult += numberInDecimal;
            }
        }

        Console.WriteLine("The result in decima is: {0}", decimalResult);
    }
}
