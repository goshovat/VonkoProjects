using System;

class UKFlag
{
    static void Main()
    {
        int input = int.Parse(Console.ReadLine());
        int center = input/2+1;
        int dotsLeftRight = 0;
        int dotsMiddle = 0;

        //Top part of the flag

        for (int i = 1; i <center ; i++)
        {
            dotsLeftRight = i-1;
            Console.Write(new string('.', dotsLeftRight));

            Console.Write('\\');

            dotsMiddle = center - 2 - dotsLeftRight;
            Console.Write(new string('.', dotsMiddle));

            Console.Write('|');

            Console.Write(new string('.', dotsMiddle));

            Console.Write('/');

            Console.Write(new string('.', dotsLeftRight));

            Console.WriteLine();
        }

        //Printing the middle part

        Console.Write(new string('-', center - 1));

        Console.Write('*');

        Console.Write(new string('-', center - 1));

        Console.WriteLine();

        //Printing the bottom part

        for (int i = 1; i < center; i++)
        {
            dotsLeftRight = center - i - 1;
            Console.Write(new string('.', dotsLeftRight));

            Console.Write('/');

            dotsMiddle = center - 2 - dotsLeftRight;
            Console.Write(new string('.', dotsMiddle));

            Console.Write('|');

            Console.Write(new string('.', dotsMiddle));

            Console.Write('\\');

            Console.Write(new string('.', dotsLeftRight));

            Console.WriteLine();
        }
    }
}

