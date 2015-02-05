using System;
using System.Collections.Generic;
using System.Numerics;

class NFactorial
{
    static void Main()
    {
        Test1();
    }

    static List<int> CalculateNFactorialOwnMethod(int n)
    {
        List<int> result = new List<int>() { 1 };

        for (int i = 1; i <= n; i++)
        {
            result = Multiply(i, result);
        }

        return result;
    }

    //this method will multiply a two-digit number with our big integer represented as a list
    private static List<int> Multiply(int multiplier, List<int> numberInList)
    {
        List<int> result = new List<int>();

        numberInList.Reverse();

        if (multiplier < 10)
        {
            result = MultiplyWithCarry(multiplier, numberInList);
        }
        else
        {
            int firstMultiplier = multiplier % 10;
            int secondMultiplier = multiplier / 10;

            List<int> firstResult = MultiplyWithCarry(firstMultiplier, numberInList);
            List<int> secondResult = MultiplyWithCarry(secondMultiplier, numberInList);

            firstResult.Reverse();
            secondResult.Reverse();

            secondResult.Insert(0, 0);

            result = SumIntegersOwnMethod(firstResult, secondResult);
        }

        return result;
    }

    //this method will multiply a one digit number with a big integer represented as a list
    private static List<int> MultiplyWithCarry(int multiplier, List<int> numberInList)
    {
        List<int> result = new List<int>();
        int digitToAdd = 0;
        int multiCarry = 0;

        for (int i = 0; i < numberInList.Count; i++)
        {
            int currentProduct = multiplier * numberInList[i];
            int lastDigit = currentProduct % 10;

            if (multiCarry != 0)
            {
                if (currentProduct + multiCarry > 9)
                {
                    digitToAdd = (currentProduct + multiCarry) % 10;
                    multiCarry = (currentProduct + multiCarry) / 10;
                }
                else
                {
                    digitToAdd = currentProduct + multiCarry;
                    multiCarry = 0;
                }
            }
            else
            {
                if (currentProduct > 9)
                {
                    multiCarry = currentProduct / 10;
                    digitToAdd = lastDigit;
                }
                else
                {
                    digitToAdd = lastDigit;
                }
            }

            result.Insert(0, digitToAdd);
        }
        if (multiCarry != 0)
        {
            result.Insert(0, multiCarry);
        }
        return result;
    }

    //this method will sum two big integers as lists to help our multiplying method
    static List<int> SumIntegersOwnMethod(List<int> number1, List<int> number2)
    {
        List<int> result = new List<int>();

        int maxLen = number1.Count;
        List<int> maxNumber = number1;

        if (number2.Count > maxLen)
        {
            maxLen = number2.Count;
            maxNumber = number2;
        }
        int minLen = number1.Count + number2.Count - maxLen;
        bool carry = false;

        for (int i = 0; i < maxLen; i++)
        {
            int currentDigit = 0;
            int currenSum = 0;

            if (i < minLen)
            {
                currenSum = number1[i] + number2[i];
                currentDigit = SumWithCarry(currenSum, ref carry);
            }
            else if (i == minLen)
            {
                currenSum = maxNumber[i];
                currentDigit = SumWithCarry(currenSum, ref carry);
            }
            else
            {
                currenSum = maxNumber[i];

                if (carry)
                    currentDigit = SumWithCarry(currenSum, ref carry);
                else
                    currentDigit = currenSum;
            }
            result.Insert(0, currentDigit);
        }
        if (carry)
        {
            result.Insert(0, 1);
        }
        return result;
    }

    //this method will return the last digit of the sum between any two digits
    static int SumWithCarry(int currenSum, ref bool carry)
    {
        int result = 0;

        if (carry)
        {
            if (currenSum + 1 > 9)
            {
                result = (currenSum + 1) % 10;
            }
            else
            {
                result = currenSum + 1;
                carry = false;
            }
        }
        else
        {
            if (currenSum > 9)
            {
                result = currenSum % 10;
                carry = true;
            }
            else
            {
                result = currenSum;
            }
        }
        return result;
    }

    //with this method we will test our implementation if work correctly
    static BigInteger CalculateNFactorial(int n)
    {
        BigInteger result = 1;

        for (int i = 1; i <= n; i++)
        {
            result *= i;
        }
        return result;
    }

    //test method
    static void Test1()
    {
        int n = 100;

        Console.WriteLine("The result of {0} factorial with big integers is: {1}",
            n, CalculateNFactorial(n));

        Console.WriteLine("The result of {0} factorial with our method is:   {1}",
            n, string.Join("", CalculateNFactorialOwnMethod(n)));
    }
}
