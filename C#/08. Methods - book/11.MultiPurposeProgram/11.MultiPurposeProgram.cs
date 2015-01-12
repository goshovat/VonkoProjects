using System;
using System.Collections.Generic;

class MultiPurposeProgram
{
    static void Main()
    {
        Console.WriteLine("Choose wheather to solve:\n\rProblem 1: Enter 1\n\rProblem 2: Enter 2\n\rProblem 3: Enter 3");
        int choice = int.Parse(Console.ReadLine());

        PickProblem(choice);
    }

    //the first method
    static string ReverseNumber(decimal number)
    {
        string result = null;

        if (number < 0)
        {
            return result;
        }

        string numberToString = number.ToString();

        char[] numberToArray = numberToString.ToCharArray();

        Array.Reverse(numberToArray);

        result = string.Join("", numberToArray);

        return result; 
    }

    //the second method
    static double MeanValue(double[] myArray) 
    {
        int len = myArray.Length;

        double totalSum = 0;

        if (len == 0)
        {
            return totalSum; 
        }

        for (int i = 0; i < len; i++)
        {
            totalSum += myArray[i];
        }

        double meanValue = totalSum / len;

        return meanValue;
    }

    //the third method
    static List<double> QuadraticEquation(double a, double b, double c)
    {
        List<double> result = new List<double>();

        if (a == 0)
        {
            result.Add(double.MinValue);
            return result;
        }

        double d = b * b - 4 * a * c;

        if (d > 0)
        {
            double x1 = (-b + Math.Sqrt(d)) / 2 * a;
            double x2 = (-b - Math.Sqrt(d)) / 2 * a;
            result.Add(x1);
            result.Add(x2);
        }
        else if (d == 0)
        {
            double x = -b / (2 * a);
            result.Add(x);
        }
        //if the descriminant is negative again an empty list will be returned

        return result;
    }

    //this method will let us choose which problem to solve

    static void PickProblem(int choice)
    {
        switch (choice)
        {
            case 1:
                Console.WriteLine("Enter a decimal number which digits you like to see reversed: ");
                decimal number = decimal.Parse(Console.ReadLine());

                string output = ReverseNumber(number);

                if (output != null)
                {
                    Console.WriteLine("The number with it's digits reversed is: {0}", output);
                }
                else
                {
                    Console.WriteLine("The number cannot be negative");
                }

                Console.WriteLine();
                break;

            case 2:
                Console.WriteLine("Enter for how many numbers you will find mean value: ");
                int n = int.Parse(Console.ReadLine());

                double[] myArray = new double[n];

                if (n != 0)
                {
                    Console.WriteLine("Now enter the numbers one by one: ");

                    for (int i = 0; i < myArray.Length; i++)
                    {
                        myArray[i] = double.Parse(Console.ReadLine());
                    }
                }

                Console.WriteLine("The mean value of these numbers is: {0}", MeanValue(myArray));
                
                break;

            case 3:
                Console.WriteLine("Enter the coefficents a, b, and c of the quadratic equation ax2 + bx+ c = 0: ");
                Console.Write("a= ");
                double a = double.Parse(Console.ReadLine());
                Console.Write("b= ");
                double b = double.Parse(Console.ReadLine());
                Console.Write("c= ");
                double c = double.Parse(Console.ReadLine());

                List<double> result = QuadraticEquation(a, b, c);

                if (result.Count == 0)
                {
                    Console.WriteLine("Your equation does not have solutions");
                    return;
                }
                else if (result.Count == 1 && result[0] == double.MinValue)
                {
                    Console.WriteLine("Your equation is not quadratic");
                    return;
                }

                Console.WriteLine("The result is: {0}", string.Join(",", result));
                break;
        }
    }
}

