using System;

class TextToNumber
{
    static void Main()
    {
        long m = long.Parse(Console.ReadLine());
        string text = Console.ReadLine();

        long result = 0;

        for (int i = 0; i < text.Length; i++) 
        {
            if (text[i] == '@')
            {
                Console.WriteLine(result);
                break;
            }
            else if (char.IsDigit(text[i]))
            {
                result *= int.Parse(text[i].ToString());
            }
            else if (char.IsLetter(text[i]))
            {
                int letterCode = char.ToUpper(text[i]) - 65;
                result += letterCode;
            }
            else
            {
                result = result % m;
            }
        }
    }
}
