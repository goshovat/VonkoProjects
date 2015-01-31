using System;

class DiamondTrolls
{
    static void Main()
    {
        int topWidth = int.Parse(Console.ReadLine());
        int width = 2 * topWidth + 1;
        int height = (6 + ((topWidth - 3) / 2) * 3);

        int sideDots = (width - topWidth) / 2;
        while (sideDots > 0)
        {
            //the left dots
            for (int i = 0; i < sideDots; i++)
            {
                Console.Write('.');
            }
            if (sideDots == (width - topWidth) / 2)
            {
                for (int i = 0; i < topWidth; i++)
                    Console.Write('*');
            }
            else
            {
                Console.Write('*');
                int middleDots = (width - 2 * sideDots - 3) / 2;
                for (int i = 0; i < middleDots; i++)
                    Console.Write('.');

                Console.Write('*');
                for (int i = 0; i < middleDots; i++)
                    Console.Write('.');

                Console.Write('*');
            }
            //the right dots
            for (int i = 0; i < sideDots; i++)
            {
                Console.Write('.');
            }
            sideDots--;
            Console.WriteLine();
        }
        //build the middle
        for (int i = 0; i < width; i++)
        {
            Console.Write('*');
        }
        Console.WriteLine();
        sideDots = 1;
        while (sideDots <= (width - 1) / 2)
        {
            //the left dots
            for (int i = 0; i < sideDots; i++)
            {
                Console.Write('.');
            }
            if (sideDots == (width - 1) / 2 - 1)
            {
                for (int i = 0; i < width - 2 * sideDots; i++)
                    Console.Write('*');
            }
            else if (sideDots == (width - 1) / 2)
            {
                Console.Write('*');
            }
            else
            {
                Console.Write('*');
                int middleDots = (width - 2 * sideDots - 3) / 2;
                for (int i = 0; i < middleDots; i++)
                    Console.Write('.');

                Console.Write('*');
                for (int i = 0; i < middleDots; i++)
                    Console.Write('.');

                Console.Write('*');
            }
            //the right dots
            for (int i = 0; i < sideDots; i++)
            {
                Console.Write('.');
            }
            sideDots++;
            Console.WriteLine();
        }
    }
}
