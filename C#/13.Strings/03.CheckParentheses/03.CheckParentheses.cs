using System;
using System.Text;

class CheckParentheses
{
    static void Main()
    {
        string expression = "((a+b)/5-d)";

        try
        {
            bool isCorrect = ValidateParentheses(expression);

            Console.WriteLine("The parentheses are put correctly: {0}", isCorrect);
        }
        catch (NullReferenceException nullRefExc)
        {
            Console.WriteLine("Error! You gave a string with null value! Details:\n{0}", nullRefExc.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine("Error occured during program execution. Details:\n{0}", e.Message);
        }
    }

    static bool ValidateParentheses(string expression)
    {
        int len = expression.Length;
        int openingParentheses = 0;

        for (int i = 0; i < len; i++)
        {
            if (expression[i] == '(')
            {
                openingParentheses++;
            }

            else if (expression[i] == ')')
            {
                if (openingParentheses <= 0)
                {
                    return false;
                }
                openingParentheses--;
            }
        }

        if (openingParentheses == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
