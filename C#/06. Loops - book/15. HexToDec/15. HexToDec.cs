using System;

class HexToDec
{
    static void Main()
    {
        Console.Write("Enter a number in a hex numeric system: ");
        string hex = Console.ReadLine();
        int length = hex.Length;
        int result = 0;
        string multiplierString = "";
        int multiplier = 0;
        int counter = length - 1;

        foreach (char symbol in hex)
        {
            switch (symbol)
            {
                case 'A':
                case 'a':
                    multiplier = 10;
                    break;
                case 'B':
                case 'b':
                    multiplier = 11;
                    break;
                case 'C':
                case 'c':
                    multiplier = 12;
                    break;
                case 'D':
                case 'd':
                    multiplier = 13;
                    break;
                case 'E':
                case 'e':
                    multiplier = 14;
                    break;
                case 'F':
                case 'f':
                    multiplier = 15;
                    break;

                case '0':
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                    multiplierString = symbol.ToString();
                    multiplier = int.Parse(multiplierString);
                    break;

                default:
                    Console.WriteLine("Enter a valid number!");
                    return;
            }

            result = multiplier * (int)Math.Pow(16, counter) + result;
            counter--;
        }

        Console.WriteLine("The number in Decimal system is: {0}", result);
    }
}

