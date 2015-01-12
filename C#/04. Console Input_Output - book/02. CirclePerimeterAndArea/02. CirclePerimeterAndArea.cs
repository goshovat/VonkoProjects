using System;

    class CirclePerimeterAndArea
    {
        static void Main()
        {
            Console.WriteLine("Write down the radius R:");
            string input = Console.ReadLine();
            Console.WriteLine();
            double r;

            bool parseRadius = double.TryParse(input, out r);

            double perimeter = Math.PI * 2 * r;
            double area = Math.PI * r * r;

            if (parseRadius == true)
            {
                Console.WriteLine("The perimeter of the circle is: {0:F3}", perimeter);
                Console.WriteLine("The area of the circle is: {0:F3}", area);
            }
            else
            {
                Console.WriteLine("Please enter valid numbers type double (xxx,xxx)");
            }
        }
    }

