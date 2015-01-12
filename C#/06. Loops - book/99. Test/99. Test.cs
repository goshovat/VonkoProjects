using System;
using System.Windows.Forms;

public class Example
{

    static void Main()
    {

        ulong sum = 0;

        Console.WriteLine(DateTime.Now);

        for (ulong i = 0; i < 300000000; i++)
        {
            sum += i;
        }

        Console.WriteLine(sum);

        Console.WriteLine(DateTime.Now);
    }
}