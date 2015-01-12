using System;

class ThreeDescendingNumbers
{
    static void Main()
    {
        Console.WriteLine("Enter three numbers: ");

        double a = double.Parse(Console.ReadLine());
        double b = double.Parse(Console.ReadLine());
        double c = double.Parse(Console.ReadLine());

        double firstNumber = 0;
        double secondNumber = 0;
        double thirdNumber = 0;

        if (a >= b && a >= c)
        {
            if (a == b && a == c)
            {
                Console.WriteLine("The three numbers are equal!");
                return;
            }

            else if (a == b && a > c)
            {
                Console.WriteLine("The numbers {0} and {1} are the biggest and the number {2} is smaller", a, b, c);
                return;
            }

            else if (a == c && a > b)
            {
                Console.WriteLine("The numbers {0} and {1} are the biggest and the number {2} is smaller", a, c, b);
                return;
            }

            else if (a > b && a > c)
            {
                firstNumber = a;

                if (b == c)
                {
                    Console.WriteLine("The biggest number is {0} and {1} and {2} are smaller", a, b, c);
                    return;
                }

                else if (b > c)
                {
                    secondNumber = b;
                    thirdNumber = c;
                }
                else if (b < c)
                {
                    secondNumber = c;
                    thirdNumber = b;
                }
            }
        }

        if (a >= b && a <= c)
        {
            if (a == b && a < c)
            {
                Console.WriteLine("The biggest numbers are {0} and {1} and {2} is smaller", c,a,b);
                return;
            }

            else if (a > b && a < c)
            {
                firstNumber = c;
                secondNumber = a;
                thirdNumber = b;
            }
        }

        if (a <= b && a <= c)
        {
            thirdNumber = a;

            if (a < b && a == c)
            {
                Console.WriteLine("The biggest number is {0} and {1} and {2} are smaller", b, a,c);
                return;
            }

            else if (a < b && a < c)
            {
                thirdNumber = a;

                if (b == c)
                {
                    Console.WriteLine("The numbers {0} and {1} are bigger and {2} is smaller", b,c,a);
                    return;
                }
                else if (b > c)
                {
                    firstNumber = b;
                    secondNumber = c;
                }
                else if (b < c)
                {
                    firstNumber = c;
                    secondNumber = b;
                }
            }
        }

        else if (a < b && a > c)
        {
            Console.WriteLine("The numbers in descending order are: {0},{1},{2}", b, a, c);
            return;
        }

        Console.WriteLine("The numbers in descending order are: {0},{1},{2}", firstNumber, secondNumber, thirdNumber);

    }  
}

