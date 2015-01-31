using System;
using System.Collections.Generic;

class XExpression
{
    static void Main()
    {
        string input = Console.ReadLine();
        List<string> finalOperands = new List<string>();

        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] == '(')
            {
                int closeBracketIndex = input.IndexOf(')', i);
                string nestedExpression = input.Substring(i + 1, closeBracketIndex - i - 1);
                decimal bracketsResult = CalculateBrackets(nestedExpression);
                finalOperands.Add(bracketsResult.ToString());
                i = closeBracketIndex;
            }
            else
            {
                finalOperands.Add(input[i].ToString());
            }
        }

        decimal finalResult = CalculateFinalResult(finalOperands);
        Console.WriteLine("{0:F2}", finalResult);
    }

    private static decimal CalculateBrackets(string nestedExpression)
    {
        decimal result = decimal.Parse(nestedExpression[0].ToString());
        for (int i = 2; i < nestedExpression.Length; i++)
        {
            switch (nestedExpression[i - 1])
            {
                case '+':
                    result += decimal.Parse(nestedExpression[i].ToString());
                    break;
                case '-':
                    result -= decimal.Parse(nestedExpression[i].ToString());
                    break;
                case '*':
                    result *= decimal.Parse(nestedExpression[i].ToString());
                    break;
                case '/':
                    result /= decimal.Parse(nestedExpression[i].ToString());
                    break;
            }
        }
        return result;
    }

    private static decimal CalculateFinalResult(List<string> finalOperands)
    {
        decimal finalResult = decimal.Parse(finalOperands[0]);
        for (int i = 2; i < finalOperands.Count - 1; i+=2)
        {
            switch (finalOperands[i - 1])
            {
                case "+":
                    finalResult += decimal.Parse(finalOperands[i]);
                    break;
                case "-":
                    finalResult -= decimal.Parse(finalOperands[i]);
                    break;
                case "*":
                    finalResult *= decimal.Parse(finalOperands[i]);
                    break;
                case "/":
                    finalResult /= decimal.Parse(finalOperands[i]);
                    break;
            }
        }
        return finalResult;
    }
}
