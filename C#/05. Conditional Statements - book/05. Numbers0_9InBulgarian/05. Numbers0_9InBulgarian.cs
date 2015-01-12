using System;


class Numbers0_9InBulgarian
{
    static void Main()
    {
        Console.WriteLine("Write an integer from 1 to 9:");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine();

        switch (n)
        {
            case 0: Console.WriteLine("Нула"); break;
            case 1: Console.WriteLine("Едно"); break;
            case 2: Console.WriteLine("Две"); break;
            case 3: Console.WriteLine("Три"); break;
            case 4: Console.WriteLine("Четири"); break;
            case 5: Console.WriteLine("Пет"); break;
            case 6: Console.WriteLine("Шест"); break;
            case 7: Console.WriteLine("Седем"); break;
            case 8: Console.WriteLine("Осем"); break;
            case 9: Console.WriteLine("Девет"); break;
        }
    }
}

