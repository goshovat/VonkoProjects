using System;

class Carpets
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int dots = n / 2 - 1;
        //draw the top half
        for (int row = 0; row < n / 2; row++)
        {
            //draw the left dots
            for (int dot = 0; dot < dots; dot++)
            {
                Console.Write('.');
            }
            //draw the carpet
            char lastChar = 'x';
            for (int carpet = 0; carpet < (n - 2 * dots) / 2; carpet++)
            {
                if (carpet % 2 == 0)
                {
                    lastChar = '/';
                    Console.Write(lastChar);
                }
                else
                {
                    lastChar = ' ';
                    Console.Write(lastChar);
                }
            }
            for (int carpet = 0; carpet < (n - 2 * dots) / 2; carpet++)
            {
                if (carpet % 2 == 0)
                {
                    if (lastChar == ' ')
                        Console.Write(lastChar);
                    else
                        Console.Write('\\');
                }
                else
                {
                    if (lastChar == '/')
                        Console.Write(' ');
                    else
                        Console.Write('\\');
                }
            }
            //draw the right dots
            for (int dot = 0; dot < dots; dot++)
            {
                Console.Write('.');
            }
            dots--;
            Console.WriteLine();
        }
        //draw the bottom half
        dots = 0;
        for (int row = 0; row < n / 2; row++)
        {
            //draw the left dots
            for (int dot = 0; dot < dots; dot++)
            {
                Console.Write('.');
            }
            //draw the carpet
            char lastChar = 'x';
            for (int carpet = 0; carpet < (n - 2 * dots) / 2; carpet++)
            {
                if (carpet % 2 == 0)
                {
                    lastChar = '\\';
                    Console.Write(lastChar);
                }
                else
                {
                    lastChar = ' ';
                    Console.Write(lastChar);
                }
            }
            for (int carpet = 0; carpet < (n - 2 * dots) / 2; carpet++)
            {
                if (carpet % 2 == 0)
                {
                    if (lastChar == ' ')
                        Console.Write(lastChar);
                    else
                        Console.Write('/');
                }
                else
                {
                    if (lastChar == '\\')
                        Console.Write(' ');
                    else
                        Console.Write('/');
                }
            }
            //draw the right dots
            for (int dot = 0; dot < dots; dot++)
            {
                Console.Write('.');
            }
            dots++;
            Console.WriteLine();
        }
    }
}
