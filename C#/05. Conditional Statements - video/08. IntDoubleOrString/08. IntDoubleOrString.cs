using System;

class IntDoubleOrString
{
    static void Main()
    {
        Console.WriteLine("Please enter the type of the variable - 'int', 'double' or 'string': ");
        string type = Console.ReadLine();
        Console.WriteLine();

        Console.WriteLine("Please enter the value of this variable: ");
        string value = Console.ReadLine();
        Console.WriteLine();
        

        switch (type)
        {
            case "int":
                try
                {
                    int n = int.Parse(value);
                    Console.WriteLine(n+1);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter valid int type!");
                    return;
                }
                break;

            case "double":
                try
                {
                    double d = double.Parse(value);
                    Console.WriteLine(d + 1);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter valid double type!");
                    return;
                } 
                break;

            case "string":
                Console.WriteLine(value + "*");
                break;
        }
    }
}

