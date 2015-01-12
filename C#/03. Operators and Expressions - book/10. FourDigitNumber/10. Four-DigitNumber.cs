using System;

class FourDigitNumberSolution1
{
    static void Main()
    {
        Console.WriteLine("Write a number consisting of four digits:");
        string input = Console.ReadLine();
        char[] charArr = input.ToCharArray();
        int sum = 0;

        //Printing the sum of the digits
        for (int i = 0; i < charArr.Length; i++)
        {
            string strDigit = charArr[i].ToString();
            int digit = Convert.ToInt32(strDigit);    
            sum+= digit;
            if (i == charArr.Length - 1)
            {
                Console.WriteLine("The sum of the digits is: "+ sum);
            }
        }
        Console.WriteLine();

        //Printing the digits in reversed way
        Array.Reverse(charArr);
        Console.Write("The number with reversed digits is: ");
        Console.WriteLine(charArr);
        Console.WriteLine();

        ////Put the last digit in position 1
        Array.Reverse(charArr);
        char firstItem = charArr[0];
        char thirdItem = charArr[2];
        char secondItem = charArr[1];
        charArr[0] = charArr[3];
        charArr[1] = firstItem;
        charArr[2] = secondItem;
        charArr[3] = thirdItem;
        Console.Write("The number with the last digit on first position is: ");
        Console.WriteLine(charArr);
        Console.WriteLine();

        //Exchange the second and third digit
        charArr = input.ToCharArray();
        char second = charArr[1];
        char third = charArr[2];
        charArr[1] = third;
        charArr[2] = second;
        Console.Write("The number with second and third digits exchanged is:");
        Console.WriteLine(charArr);
    }
}

