using System;

class KaspichaniaBoats
{
    static void Main()
    {
        int bottom = int.Parse(Console.ReadLine());
        int width = bottom * 2 + 1;
        int height = 6 + ((bottom - 3) / 2) * 3;
        int sails = (2 * height) / 3;
        int hull = height - sails;

        //print the sails
        int dots = bottom;
        for (int row = 0; row < sails; row++)
        {
            if (row == sails - 1)
                dots = 0;
            //print the left dots
            for (int dot = 0; dot < dots; dot++)
                Console.Write('.');

            //print the stars
            if (row == 0)
            {
                Console.Write('*');
            }
            else if (row == 1)
            {
                Console.Write(new string('*', 3));
            }
            //print the beam
            else if (row == sails - 1)
            {
                for (int i = 0; i < width; i++)
                    Console.Write('*');
            }
            else
            {
                int internalDots = (width - (2 * dots + 3)) / 2;
                Console.Write('*');
                for (int i = 0; i < internalDots; i++)
                    Console.Write('.');

                Console.Write('*');
                for (int i = 0; i < internalDots; i++)
                    Console.Write('.');

                Console.Write('*');
            }
            //print the right dots
            for (int dot = 0; dot < dots; dot++)
                Console.Write('.');

            dots--;
            Console.WriteLine();
        }
        //build the hull
        dots = 1;
        for (int row = 0; row < hull; row++)
        {
            //print the left dots
            for (int dot = 0; dot < dots; dot++)
                Console.Write('.');

            if (row == hull - 1)
            {
                for (int i = 0; i < bottom; i++)
                    Console.Write('*');
            }
            else
            {
                int internalDots = (width - (2 * dots + 3)) / 2;
                Console.Write('*');
                for (int i = 0; i < internalDots; i++)
                    Console.Write('.');

                Console.Write('*');
                for (int i = 0; i < internalDots; i++)
                    Console.Write('.');

                Console.Write('*');
            }

            //print the right dots
            for (int dot = 0; dot < dots; dot++)
                Console.Write('.');

            dots++;
            Console.WriteLine();
        }
    }
}
