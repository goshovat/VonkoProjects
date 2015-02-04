using System;
using System.Numerics;

class Secrets
{
    static void Main()
    {
        BigInteger inputNumber = BigInteger.Parse(Console.ReadLine());

         if (inputNumber < 1) 
         {
             inputNumber *= -1;
         }

        string inputStr = inputNumber.ToString();

        char[] inputArr = inputStr.ToCharArray();

        Array.Reverse(inputArr);

        //first find the special sum
        long specialSum = 0;

        for (int i = 1; i <= inputArr.Length; i++)
        {
            int currentDigit = int.Parse(inputArr[i - 1].ToString());
            if (i % 2 != 0)
            {
                specialSum += currentDigit * i * i;
            }
            else
            {
                specialSum += currentDigit * currentDigit * i;
            }
        }

        Console.WriteLine(specialSum);

        //now get the special sequence
        char[] specialSumArr = specialSum.ToString().ToCharArray();

        if (specialSumArr[specialSumArr.Length - 1] == '0')
        {
            Console.WriteLine(inputStr + " has no secret alpha-sequence");
        }
        else
        {
            char[] lettersArray = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'Í', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

            int sequeceLength = int.Parse(specialSumArr[specialSumArr.Length - 1].ToString());
            long r = specialSum % 26;
            long firstLetterPos = r;
            if (firstLetterPos > 26)
            {
                firstLetterPos = 1;
            }

            long currentLetterPosition = firstLetterPos;

            for (int i = 0; i < sequeceLength; i++)
            {
                if (currentLetterPosition > 25)
                {
                    currentLetterPosition = currentLetterPosition - 25 - 1;
                }

                Console.Write(lettersArray[currentLetterPosition]);
                currentLetterPosition++;
            }
            Console.WriteLine();
        }
    }
}