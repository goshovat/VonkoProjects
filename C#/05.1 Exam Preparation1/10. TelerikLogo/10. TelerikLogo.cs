using System;

class TelerikLogo
{
    static void Main()
    {
        int x = int.Parse(Console.ReadLine());
        int y = x;
        int z = x / 2 + 1;

        int rows = 2 * x + x - 2;
        int elementsOnLine = rows;
        int leftRightPointsTop = -1;
        int middlePointsTop = 2 * x - 3;

        //Top section of the figure(the rows <= z)
        for (int i = 1; i <= z; i++)
        {
            if (z - i > 0)
            {
                Console.Write(new string('.', z - i));
            }

            if (i <= z)
            {
                Console.Write('*');
            }

            if (i > 1)
            {
                Console.Write(new string('.', leftRightPointsTop));
            }

            if (i > 1)
            {
                Console.Write('*');
            }

            if (middlePointsTop > 0)
            {
                Console.Write(new string('.', middlePointsTop));
            }

            Console.Write('*');

            if (i > 1)
            {
                Console.Write(new string('.', leftRightPointsTop));
            }

            if (i > 1)
            {
                Console.Write('*');
            }

            if (z - i > 0)
            {
                Console.Write(new string('.', z - i));
            }

            leftRightPointsTop += 2;
            middlePointsTop -= 2;
            Console.WriteLine();
        }

        //Second-top-section(from y to z)
        int counter = 0;

        if (x % 2 != 0)
        {
            counter = x;
        }
        else
        {
            counter = x + 1;
        }

        for (int i = 1; i < y - z; i++)
        {
            Console.Write(new string('.', counter));

            Console.Write('*');

            Console.Write(new string('.', middlePointsTop));

            Console.Write('*');

            Console.Write(new string('.', counter));

            counter++;
            middlePointsTop -= 2;
            Console.WriteLine();
        }

        //Middle section
        int leftRightPointsMiddle = elementsOnLine / 2;
        int middlePointsMiddle = -1;

        for (int i = 1; i <= x; i++)
        {

            Console.Write(new string('.', leftRightPointsMiddle));


            Console.Write("*");

            if (i > 1)
            {
                Console.Write(new string('.', middlePointsMiddle));

                Console.Write("*");
            }

            Console.Write(new string('.', leftRightPointsMiddle));

            leftRightPointsMiddle--;
            middlePointsMiddle += 2;
            Console.WriteLine();
        }

        leftRightPointsMiddle += 2;
        middlePointsMiddle -= 4;

        //Bottom section
        for (int i = 2; i <= x; i++)
        {
            Console.Write(new string('.', leftRightPointsMiddle));

            Console.Write("*");

            if (i < x)
            {
                Console.Write(new string('.', middlePointsMiddle));

                Console.Write("*");
            }

            Console.Write(new string('.', leftRightPointsMiddle));

            leftRightPointsMiddle++;

            middlePointsMiddle -= 2;

            Console.WriteLine();
        }
    }
}

