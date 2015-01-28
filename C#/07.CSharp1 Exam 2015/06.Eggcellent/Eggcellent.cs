using System;

class Eggcellent
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int eggWidth = 3 * n - 1;
        int drawingWidth = 3 * n + 1;
        int topBottom = n - 1;
        int startDots = (drawingWidth - topBottom) / 2;
        int currentDots = startDots;
        int offset = 0;
        //draw top half
        for (int row = 0; row < n; row++)
        {
            //draw the dots on the left
            for (int dot = 0; dot < currentDots; dot++)
            {
                Console.Write('.');
            }
            //draw the middle portion
            if (row == 0)
            {
                for (int i = 0; i < topBottom; i++)
                    Console.Write('*');
            }
            else if (row == n - 1)
            {
                Console.Write('*');
                for (int cracks = 0; cracks < eggWidth - 2; cracks++)
                {
                    if (cracks % 2 == 0)
                        Console.Write('@');
                    else
                        Console.Write('.');
                }
                Console.Write('*');
            }
            else
            {
                Console.Write('*');
                int middleDots = drawingWidth - (2 * currentDots + 2);
                if (middleDots > eggWidth - 2) middleDots = eggWidth - 2;
                for (int dot = 0; dot < middleDots; dot++)
                {
                    Console.Write('.');
                }
                Console.Write('*');
            }
            //draw the dots on the right
            for (int dot = 0; dot < currentDots; dot++)
            {
                Console.Write('.');
            }
            currentDots -= 2;
            if (currentDots < 1)
            {
                currentDots = 1;
                offset++;
            }
            Console.WriteLine();
        }
        //draw the bottom half
        for (int row = 0; row < n; row++)
        {
            //draw the dots on the left
            for (int dot = 0; dot < currentDots; dot++)
            {
                Console.Write('.');
            }
            //draw the middle portion
            if (row == 0)
            {
                Console.Write('*');
                for (int cracks = 0; cracks < eggWidth - 2; cracks++)
                {
                    if (cracks % 2 == 0)
                        Console.Write('.');
                    else
                        Console.Write('@');
                }
                Console.Write('*');             
            }
            else if (row == n - 1)
            {
                for (int i = 0; i < topBottom; i++)
                    Console.Write('*');
            }
            else
            {
                Console.Write('*');
                int middleDots = drawingWidth - (2 * currentDots + 2);
                //if (middleDots > eggWidth - 2) middleDots = eggWidth - 2;
                for (int dot = 0; dot < middleDots; dot++)
                {
                    Console.Write('.');
                }
                Console.Write('*');
            }
            //draw the dots on the right
            for (int dot = 0; dot < currentDots; dot++)
            {
                Console.Write('.');
            }
            if (row > offset - 2) currentDots += 2;
            //if (currentDots < 1) currentDots = 1;
            Console.WriteLine();
        }
    }
}
