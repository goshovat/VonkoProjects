using System;
using System.Collections;
using System.Collections.Generic;

class Enigmanation
{
    static void Main()
    {
        string entry = Console.ReadLine();
        char[] input = entry.ToCharArray();
        List<string> list = new List<string>();

        double result = 0;
        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] == '(')
            {
                int endBracketIndex = entry.IndexOf(')', i);
                string insideBrackets = entry.Substring(i + 1, endBracketIndex - i - 1);
                list.Add(CalcBracketsExpression(insideBrackets).ToString());
                i = endBracketIndex;
            }
            if (input[i] == ')')
                i += 1;

            list.Add(input[i].ToString());
        }

        result = double.Parse(list[0]);
        for (int i = 2; i < list.Count; i++)
        {
            switch (list[i - 1])
            {
                case "+":
                    result += double.Parse(list[i]);
                    break;
                case "-":
                    result -= double.Parse(list[i]);
                    break;
                case "%":
                    result %= double.Parse(list[i]);
                    break;
                case "*":
                    result *= double.Parse(list[i]);
                    break;
            }
        }
        Console.WriteLine("{0:f3}", result);
    }

    static double CalcBracketsExpression(string expr)
    {
        char[] expression = expr.ToCharArray();
        double result = expression[0] - '0';

        for (int i = 2; i < expression.Length; i ++)
        {
            switch (expression[i - 1])
            {
                case '+':
                    result += (expression[i] - '0');
                    break;
                case '-':
                    result -= (expression[i] - '0');
                    break;
                case '%':
                    result %= (expression[i] - '0');
                    break;
                case '*':
                    result *= (expression[i] - '0');
                    break;
            }
        }
        return result;
    }
}
