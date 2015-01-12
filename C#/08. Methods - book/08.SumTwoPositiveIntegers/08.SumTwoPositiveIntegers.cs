using System;
using System.Numerics;

class SumTwoPositiveIntegers
{
    static void Main()
    {
        Test1();
        Test2();
    }

    //our method
    static BigInteger SumIntegers(int[] number1, int[] number2)
    {
        BigInteger result = 0;

        Array.Reverse(number1);
        Array.Reverse(number2);

        result = BigInteger.Parse(string.Join("", number1)) +
                BigInteger.Parse(string.Join("", number2));

        return result;
    }

    //test methods

    static void Test1()
    {
        int[] number1 = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1};
        int[] number2 = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 };

        Console.WriteLine("The numbers are: {0} and {1}\n\rand the result is: {2}",
            string.Join(",", number1), string.Join(",", number2), SumIntegers(number1, number2));
    }

    static void Test2()
    {
        int[] number1 = {4, 5, 6, 2, 6, 6, 7, 8, 9, 10, 11, 12};
        int[] number2 = { 0, 0, 0, 2, 6, 7, 8, 9, 10, 11, 12, 13};

        Console.WriteLine("The numbers are: {0} and {1}\n\rand the result is: {2}",
           string.Join(",", number1), string.Join(",", number2), SumIntegers(number1, number2));
    }
}
