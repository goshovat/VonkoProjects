using System;

class ReverseNumber
{
    static void Main()
    {
        Test1();
        Test2();
    }

    //our method
    static decimal ReversNumber(decimal number)
    {
        string result = "";
        char[] numberArray = number.ToString().ToCharArray();
        Array.Reverse(numberArray);
        result = string.Join("", numberArray);
        return decimal.Parse(result);
    }

    //testing our method
    static void Test1()
    {
        decimal number = 576;
        Console.WriteLine("The original number is: {0}\r\nThe reversed number is: {1}",
                            number, ReversNumber(number));
        Console.WriteLine();
    }

    static void Test2()
    {
        decimal number = 576.98m;
        Console.WriteLine("The original number is: {0}\r\nThe reversed number is: {1}",
                            number, ReversNumber(number));
        Console.WriteLine();
    }
}
