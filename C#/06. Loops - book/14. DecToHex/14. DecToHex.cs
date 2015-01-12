using System;

class DecToHex
{
    static void Main()
    {
        Console.Write("Enter a number in a decimal numeric system: ");
        int dec = 0;
        int lastDigit = 0;
        char letter = 'A';
        string result = "";


        try
        {
            dec = int.Parse(Console.ReadLine());
        }
        catch (FormatException)
        {
            Console.WriteLine("Enter valid number!");
        }

        if (dec > 0)
        {
            while (dec > 0)
            {
                lastDigit = dec % 16;

                if (lastDigit > 9)
                {
                    switch (lastDigit)
                    {
                        case 10:
                            letter = 'A';
                            break;
                        case 11:
                            letter = 'B';
                            break;
                        case 12:
                            letter = 'C';
                            break;
                        case 13:
                            letter = 'D';
                            break;
                        case 14:
                            letter = 'E';
                            break;
                        case 15:
                            letter = 'F';
                            break;
                    }

                    result = letter + result;
                }

                else
                {
                    result = lastDigit + result;
                }
                dec /= 16;
            }

            Console.WriteLine("Result: {0}", result);
        }
        else
        {
            Console.WriteLine("Enter valid number!");
        }
    }
}

