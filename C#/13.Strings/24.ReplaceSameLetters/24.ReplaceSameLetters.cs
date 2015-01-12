using System;
using System.Text;

class ReplaceSameLetters
{
    static void Main()
    {
        string text = "aaaaabbbbbcdddeeeedssaa";

        try
        {
            if (text == "")
            {
                Console.WriteLine("Error! You have given empty string.");
                return;
            }

            StringBuilder result = new StringBuilder();
            char prevLetter = text[0];
            result.Append(prevLetter);

            for (int i = 1; i < text.Length; i++)
            {
                if (text[i] != prevLetter)
                {
                    prevLetter = text[i];
                    result.Append(prevLetter);
                }
            }

            Console.WriteLine("The formatted text is:\n{0}", result.ToString());
        }
        catch (NullReferenceException nullRefExc)
        {
            Console.WriteLine("Error! The text you have given is with null value. Details:\n{0}",nullRefExc.StackTrace);
        }
        catch (Exception e)
        {
            Console.WriteLine("Error occured during program execution! Details:\n{0}", e.StackTrace);
        }
    }
}
