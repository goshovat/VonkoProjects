using System;

class FirTree
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int numberCols = 2 * n - 3;
        int numberStars = 1;

        for (int rows = 0; rows < n; rows++)
        {
            
            //draw the stars
            if (rows == 0 || rows == n - 1)
            {
                //draw the left dots
                for (int i = 0; i < numberCols / 2; i++)
                {
                    Console.Write('.');
                }
                Console.Write('*');
                //draw the left dots
                for (int i = 0; i < numberCols / 2; i++)
                {
                    Console.Write('.');
                }
            }
            else
            {
                //draw the left dots
                for (int i = 0; i < numberCols / 2 - rows; i++)
                {
                    Console.Write('.');
                }
                for (int i = 0; i < numberStars; i++)
                {
                    Console.Write("*");
                }
                //draw the right dots
                for (int i = 0; i < numberCols / 2 - rows; i++)
                {
                    Console.Write('.');
                }
            }
          
            Console.WriteLine();
            numberStars+= 2;
        }
    }
}
