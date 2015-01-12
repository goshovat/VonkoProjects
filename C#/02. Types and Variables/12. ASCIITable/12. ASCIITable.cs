using System;
using System.Text;

class ASCIITable
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        for (int i = 0; i <= 255; i++)
        {
            System.Console.WriteLine("{0} = {1}", i, (char)i);
        }
    }
}

