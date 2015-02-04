using System;

class WeAllLoveBits
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int currentNumber;
        int newNumber;
        int reversedNumber;

        int[] newNumbers = new int[n];

        for (int i = 0; i < n; i++)
        {
            currentNumber = int.Parse(Console.ReadLine());

            //convert the number into a string of its binary representation
            string inputString = Convert.ToString(currentNumber, 2);

            //make this string into a char array so we can reverse it
            char[] inputCharArray = inputString.ToCharArray();
            Array.Reverse(inputCharArray);

            //make the reversed char array into string
            string reversedString = new string(inputCharArray);

            //transform the string of bits into a number in decimal representation
            reversedNumber = Convert.ToInt32(reversedString, 2);

            //use the newly acquired number into the given formula so we can get the final result
            newNumber = reversedNumber;

            newNumbers[i] = newNumber;
        }

        //print the new numbers
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine(newNumbers[i]);
        }
    }
}

