using System;
using System.Collections.Generic;
using System.Numerics;

class OddNumber
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        //the key is the number, the value - how many times is contained
        Dictionary<BigInteger, int> numbers = new Dictionary<BigInteger, int>();

        for (int i = 0; i < n; i++)
        {
            BigInteger currentNumber = BigInteger.Parse(Console.ReadLine());
            if (!numbers.ContainsKey(currentNumber))
                numbers.Add(currentNumber, 1);
            else
                numbers[currentNumber]++;
        }

        foreach(int number in numbers.Keys) 
        {
            if ((numbers[number] % 2 != 0))
            {
                Console.WriteLine(number);
                break;
            }
        }        
    }
}