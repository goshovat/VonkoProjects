using System;

class ThirdSignSolution1
{
    static void Main()
    {
        string input = Console.ReadLine();
        char[] inputCharArr = input.ToCharArray();
        Array.Reverse(inputCharArr);
        string inputStr =new string(inputCharArr);
        if (inputStr[2] == '7')
        {
            Console.WriteLine(true);
        }
        else
        {
            Console.WriteLine(false);
        }
    }
}

