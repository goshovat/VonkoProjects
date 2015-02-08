using System;

class CorrectBrackets
{
    static void Main()
    {
        string expression = ")(a+b))";
        bool isCorrect = ValidateParentheses(expression);

        Console.WriteLine("The parentheses are put correctly: {0}", isCorrect);
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
