using System;

class FirTree
{
    static void Main()
    {
        int rows = int.Parse(Console.ReadLine());
        int elementsOnLine = rows * 2 - 3;
        int center = elementsOnLine / 2;

        //Here we build the body of the tree
        for (int i = 1; i < rows; i++)
        {
            for (int j = 1; j <= elementsOnLine; j++)
            {
                if ((j <= center - i + 1) || (j > center + i))
                {
                    Console.Write('.');
                }
                else
                {
                    Console.Write('*');
                }
            }

            Console.WriteLine();
        }

        //Here we build the base of the tree(the final row)
        for (int j = 1; j <= elementsOnLine; j++)
        {
            if (j <= center)
            {
                Console.Write(".");
            }
            else if (j == center + 1)
            {
                Console.Write("*");
            }
            else
            {
                Console.Write(".");
            }
        }
        Console.WriteLine();

    }
}

