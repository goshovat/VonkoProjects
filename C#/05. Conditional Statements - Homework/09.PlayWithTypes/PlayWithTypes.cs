using System;

class PlayWithTypes
{
    static void Main()
    {
        Console.WriteLine("Choose an input type 'int', 'double' or 'string':");
        string choice = Console.ReadLine();
        dynamic variable = 0;

        switch (choice)
        {
            case "int":
            case "double":
                variable = double.Parse(Console.ReadLine());
                variable += 1;
                Console.WriteLine(variable);
                break;

            case "string":
                variable = Console.ReadLine();
                variable += '*';
                Console.WriteLine(variable);
                break;
        }
    }
}
