using System;
using System.Text;

class Tringale
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        char copyRight = '\u00A9';
        int rows = 3;
        int character = 1;
        for (int i = 0; i < rows; i++)
        {
            for (int blank = 0; blank < rows - i; blank++)
            {
                Console.Write(" ");
            }
            for (int symbol = 0; symbol < character; symbol++)
            {
                Console.Write(copyRight);
            }
            character += 2;
            Console.WriteLine();
        }
    }
}

