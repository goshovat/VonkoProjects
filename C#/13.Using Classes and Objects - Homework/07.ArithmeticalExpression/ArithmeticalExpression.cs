using System;
using System.Collections.Generic;

class ArithmeticalExpression
{
    static string[] operators = { "*", "/", "+", "-" };
    static int[] priorities = { 3, 3, 2, 2 };
    static string[] functionSymbols = { "l", "n", "s", "q", "r", "t", "p", "o", "w" };

    static List<string> operatorStack = new List<string>();

    static void Main()
    {
        string expression = "pow(2, 3.14) * (3 - (3 * sqrt(2) - 3.2) + 1.5*0.3) ";
        string polishNotation = TurnIntoPolishNotation(expression);

        Console.WriteLine(polishNotation);

        double result = CalculatePolishNotation(polishNotation);
        Console.WriteLine("{0:F2}", result);
    }

    //this method will turn the given algebric string into polish notation
    private static string TurnIntoPolishNotation(string expression)
    {
        string polishNotation = "";
        string currentNumber = "";
        int currentDigit = 0;
        bool inNumber = false;
        int operatorPriority = 0;

        for (int index = 0; index < expression.Length; index++)
        {
            string currentSymbol = expression[index].ToString();

            //recognize and form the rational numbers
            if ((currentSymbol == " " || currentSymbol == ")")
                && currentNumber != "" || Array.IndexOf(operators, currentSymbol) != -1)
            {
                polishNotation += currentNumber + " ";
                currentNumber = "";
                inNumber = false;
            }
            else if (int.TryParse(currentSymbol, out currentDigit))
            {
                currentNumber += currentSymbol;
                inNumber = true;
            }
            else if (currentSymbol == "." && inNumber)
            {
                currentNumber += currentSymbol;
            }
            //recognize and form the functions
            if (Array.IndexOf(functionSymbols, currentSymbol) != -1)
            {
                int indexOffset = 0;
                double functionResult = CalculateFunction(index, ref indexOffset, expression);
                polishNotation += functionResult + " ";
                index = indexOffset;
            }
            //if the current symbol is parenthesis
            if (currentSymbol == "(")
            {
                operatorPriority = 0;
                operatorStack.Insert(0, currentSymbol);
            }

            if (currentSymbol == ")")
            {
                while (operatorStack.Count > 0 && operatorStack[0] != "(")
                {
                    if (operatorStack.Count > 0)
                    {
                        polishNotation += operatorStack[0] + " ";
                        operatorStack.RemoveAt(0);
                    }
                }

                if (operatorStack.Count > 0 && operatorStack[0] == "(")
                    operatorStack.RemoveAt(0);
            }

            //if the current symbol is operator
            int operatorIndex = Array.IndexOf(operators, currentSymbol);
            if (operatorIndex != -1)
            {
                //if the priority of the operator is bigger than the priority of the last in the operatorStack
                if (priorities[operatorIndex] > operatorPriority)
                {
                    operatorStack.Insert(0, currentSymbol);
                    operatorPriority = priorities[operatorIndex];
                }
                else
                {
                    while (priorities[operatorIndex] <= operatorPriority && operatorStack.Count > 0)
                    {
                        if (operatorStack.Count > 0) 
                            polishNotation += operatorStack[0] + " ";
                        if (operatorStack.Count > 0 && operatorStack[0] != "(")
                            operatorStack.RemoveAt(0);
                        if (operatorStack.Count > 0)
                        {
                            if (operatorStack[0] == "(" || operatorStack[0] == ")")
                                operatorPriority = 0;
                            else
                                operatorPriority = priorities[Array.IndexOf(operators, operatorStack[0])];
                        }
                    }

                    operatorStack.Insert(0, currentSymbol);
                    operatorPriority = priorities[Array.IndexOf(operators, operatorStack[0])];
                }
            }
        }

        //now insert the remaining symbols in the stack
        for (int index = 0; index < operatorStack.Count; index++)
        {
            polishNotation += operatorStack[index] + " ";
        }
        return polishNotation;
    }

    //this mehtod will calculate the result of a function when such is met
    private static double CalculateFunction(int index, ref int indexOffset, string expression)
    {
        string currentSymbol = expression[index].ToString();

        double functionResult = 0;
        string functionName = "";
        string number1Str = "";
        string number2Str = "";
        bool inFunctionName = true;
        bool inFirstNumber = false;
        bool inSecondNumber = false;

        //extract the number and the name of the function
        while (currentSymbol != ")")
        {
            if (inFunctionName && currentSymbol != "(")
                functionName += currentSymbol;

            if (currentSymbol == "(")
            {
                inFunctionName = false;
                inFirstNumber = true;
            }
            if (inFirstNumber && currentSymbol != "," && currentSymbol != "(")
            {
                number1Str += currentSymbol;
            }
            if (inFirstNumber && currentSymbol == ",")
            {
                inFirstNumber = false;
                inSecondNumber = true;
            }
            if (inSecondNumber && currentSymbol != ",")
            {
                number2Str += currentSymbol;
            }

            index++;
            currentSymbol = expression[index].ToString();
        }

        //calclulate the value of the function
        double number1 = double.Parse(number1Str);
        double number2 = 0;

        if (number2Str != "")
            number2 = double.Parse(number2Str);

        switch (functionName)
        {
            case "ln":
                functionResult = Math.Log(number1);
                break;
            case "pow":
                functionResult = Math.Pow(number1, number2);
                break;
            case "sqrt":
                functionResult = Math.Sqrt(number1);
                break;
        }
        indexOffset = index;
        Console.WriteLine(functionResult);
        return functionResult;
    }

    //this method will calculate the value of the polish notation
    private static double CalculatePolishNotation(string polishNotation)
    {
        double result = 0;
        string[] polishNotationArray = polishNotation.Split(' ');

        List<double> values = new List<double>();
        double currentValue = 0;

        for (int i = 0; i < polishNotationArray.Length; i++)
        {
            string currentSymbol = polishNotationArray[i];

            //if the symbol is a number push it to the stack of values
            if (double.TryParse(currentSymbol, out currentValue))
            {
                values.Add(currentValue);
            }
            else
            {
                //if the symbol is an operator
                if (Array.IndexOf(operators, currentSymbol) != -1)
                {
                    values = CalculateOperation(currentSymbol, values);
                }
                else
                {
                    //the current symbol is space
                    continue;
                }
            }
        }

        if (values.Count == 1)
            result = values[0];

        return result;
    }

    //this method will calculate an operation between two values and stick the result into the list of values
    private static List<double> CalculateOperation(string currentSymbol, List<double> values)
    {
        if (values.Count >= 2)
        {
            double value1 = values[values.Count - 2];
            double value2 = values[values.Count - 1];
            double resultValue = 0;

            switch (currentSymbol)
            {
                case "+":
                    resultValue = value1 + value2;
                    break;
                case "-":
                    resultValue = value1 - value2;
                    break;
                case "*":
                    resultValue = value1 * value2;
                    break;
                case "/":
                    resultValue = value1 / value2;
                    break;
            }
            for (int i = 0; i < 2; i++)
                values.RemoveAt(values.Count - 1);

            values.Add(resultValue);
        }
        else
        {
            Console.WriteLine("Invalid Polish Notation!");
            values = new List<double>();
        }
        return values;
    }
}
