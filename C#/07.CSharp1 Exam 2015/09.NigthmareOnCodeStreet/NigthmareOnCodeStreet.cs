using System;

class NigthmareOnCodeStreet
{
    static void Main()
    {
        string text = Console.ReadLine();
        text = text.Trim('-');
        int digit = 0;
        decimal sum = 0;
        int count = 0;

        for (int i = 0; i < text.Length; i++)
        {
            if (i % 2 != 0 &&
                int.TryParse(text[i].ToString(), out digit))
            {
                sum += digit;
                count++;
            }
        }

        Console.WriteLine("{0} {1}", count, sum);
    }
}
