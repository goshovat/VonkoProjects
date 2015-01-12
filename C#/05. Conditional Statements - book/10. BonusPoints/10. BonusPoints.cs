using System;

class BonusPoints
{
    static void Main()
    {
        Console.WriteLine("Write the number of your points(between 1 and 9):");
        int points = int.Parse(Console.ReadLine());

        switch (points)
        {
            case 1: 
            case 2:
            case 3:
                points *= 10;
                Console.WriteLine("The points are: {0}", points);
                break;
            case 4:
            case 5:
            case 6:
                points *= 100;
                Console.WriteLine("The points are: {0}", points);
                break;
            case 7:
            case 8:
            case 9:
                points *= 1000;
                Console.WriteLine("The points are: {0}", points);
                break;
            default: Console.WriteLine("Error"); break;
        }
    }
}

