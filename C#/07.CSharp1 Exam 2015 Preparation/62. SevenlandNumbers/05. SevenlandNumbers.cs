using System;

class SevenlandNumbers
{
    static void Main()
    {
        string input = Console.ReadLine();
        int number = int.Parse(input);
        int n = number / 100;
        int n1 = (number / 10) % 10;
        int n2 = number % 10;

        int nextNumber = 0;

        int length = input.Length;

        switch (length)
        {
            case 1:
                if (number < 6)
                {
                    nextNumber = number + 1;
                }
                else if (number == 6)
                {
                    nextNumber = 10;
                }
                break;

            case 2:
                if (number < 66)
                {
                    if (n2 < 6)
                    {
                        nextNumber = number + 1; ;
                    }
                    else if (n2 == 6)
                    {
                        nextNumber = int.Parse((n1 + 1) + "" + 0);
                    }
                }
                else if (number == 66)
                {
                    nextNumber = 100;
                }
                break;

            case 3:
                if (number < 666)
                {
                    if (n1 <= 6 && n2 < 6)
                    {
                        nextNumber = number + 1;
                    }
                    else if (n1 < 6 && n2 == 6)
                    {
                        nextNumber = int.Parse(n + "" + (n1 + 1) + "" + 0);
                    }
                    else if (n1 == 6 && n2 == 6)
                    {
                        nextNumber = int.Parse((n + 1) + "" + 0 + "" + 0);
                    }
                }
                else if (number == 666)
                {
                    nextNumber = 1000;
                }
                break;

            default:
                Console.WriteLine("Please enter 3 digit number");
                break;
        }

        Console.WriteLine(nextNumber);
    }
}

