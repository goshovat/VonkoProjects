using System;
using System.Collections.Generic;
using System.Numerics;

class NumberAsArray
{
    static void Main()
    {
        Test1();
        Test2();
    }

    //with these method we will test if our implementation works correct
    static BigInteger SumIntegersBigInt(int[] number1, int[] number2)
    {
        BigInteger result = 0;
        Array.Reverse(number1);
        Array.Reverse(number2);

        result = BigInteger.Parse(string.Join("", number1)) +
                BigInteger.Parse(string.Join("", number2));

        return result;
    }

    static List<int> SumIntegersOwnMethod(int[] number1, int[] number2)
    {
        List<int> result = new List<int>();
        int maxLen = number1.Length;
        int[] maxNumber = number1;

        if (number2.Length > maxLen)
        {
            maxLen = number2.Length;
            maxNumber = number2;
        }
        int minLen = number1.Length + number2.Length - maxLen;
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

    //test methods
    static void Test1()
    {
        int[] number1 = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 
                            8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 
                            8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8,
                            8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 9, 6, 7, 8};
        int[] number2 = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 
                            8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 
                            8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 
                            8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8 };

        Console.WriteLine("The sum calculated with our method is:  {0}",
                        string.Join("", SumIntegersOwnMethod(number1, number2)));

        Console.WriteLine("The sum calculated with big integer is: {0}",
          string.Join("", SumIntegersBigInt(number1, number2)));
    }

    static void Test2()
    {
        int[] number1 = { 4, 5, 6, 2, 6, 6, 7, 8, 9, 7, 4, 8 };
        int[] number2 = { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 5, 4, 3, 2, 1, 2 };

        Console.WriteLine("The sum calculated with our method is:  {0}",
                        string.Join("", SumIntegersOwnMethod(number1, number2)));

        Console.WriteLine("The sum calculated with big integer is: {0}",
          string.Join("", SumIntegersBigInt(number1, number2)));
    }
}
