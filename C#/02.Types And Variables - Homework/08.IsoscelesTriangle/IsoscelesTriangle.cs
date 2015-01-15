using System;
using System.Text;

class IsoscelesTriangle
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        char copyRight = '\u00a9';
        int rows = 4;
        int innerSpaces = 1;
        for (int row = 1; row <= rows; row++)
        {
            //print the empty space aside
            for (int i = 0; i < rows - row; i++)
            {
                Console.Write(' ');
            }
            switch (row)
            {
                //the triangle top
                case 1:
                    Console.Write(copyRight);
                    break;
                case 4:
                    for (int i = 0; i < rows; i++)
                    {
                        Console.Write(copyRight);
                        Console.Write(' ');
                    }
                    break;
                default:
                    Console.Write(copyRight);
                    for (int i = 0; i < innerSpaces; i++)
                    {
                        Console.Write(' ');
                    }
                    innerSpaces += 2;
                    Console.Write(copyRight);
                    break;
            }
            Console.WriteLine();
        }
    }
}
