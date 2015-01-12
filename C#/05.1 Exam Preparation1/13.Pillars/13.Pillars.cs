using System;

class Pillars
{
    static void Main()
    {
        int[,] matrix = new int[8, 8];

        for (int rows = 0; rows < 8; rows++)
        {
            int input = int.Parse(Console.ReadLine());

            for (int cols = 0; cols <8; cols++)
            {
                int bit = (input >> cols) & 1;

                matrix[rows,7-cols] = bit;
            }
        }

        ////print the matrix
        //for (int i = 0; i < 8; i++)
        //{
        //    for (int j = 0; j < 8; j++)
        //    {
        //        Console.Write(matrix[i, j]);
        //    }
        //    Console.WriteLine();
        //}

        bool suchPillarsExist = false;
        int counter1 = 0;
        int counter2 = 0;
        int rotation = 0;

        for (rotation = 0; rotation < 8; rotation++)
        {
            counter1 = 0;
            counter2 = 0;

            for (int colLeft = 0; colLeft <=rotation-1 ; colLeft++)
            {
                for (int row = 0; row <8; row++)
                {
                    if (matrix[row,colLeft] == 1)
                    {
                        counter1++;
                    }
                }
            }

            for (int colRight = rotation+1; colRight < 8; colRight++)
            {
                for (int row = 0; row <8; row++)
                {
                    if (matrix[row, colRight] == 1)
                    {
                        counter2++;
                    }
                }
            }

            if (counter1 == counter2)
            {
                suchPillarsExist = true;              
                break;
            }
        }

        if (suchPillarsExist)
        {
            Console.WriteLine(7-rotation);
            Console.WriteLine(counter1);
        }
        else
        {
            Console.WriteLine("No");
        }
    }
}

