using System;

class CompareCharArrays
{
    static void Main()
    {
        //get the length and initialize the arrays
        Console.WriteLine("Enter the length of the first char arrays: ");
        int firstArrLen = int.Parse(Console.ReadLine());
        char[] firstArr = new char[firstArrLen];

        Console.WriteLine("Enter the length of the second char arrays: ");
        int secondArrLen = int.Parse(Console.ReadLine());
        char[] secondArr = new char[secondArrLen];

        //set the values of the two arrays
        for (int i = 0; i < firstArrLen; i++)
        {
            Console.WriteLine("Enter symbol No {0} of the first array: ", i);
            firstArr[i] = char.Parse(Console.ReadLine());
        }

        Console.WriteLine(new string('-', 10));

        for (int i = 0; i < secondArrLen; i++)
        {
            Console.WriteLine("Enter symbol No {0} of the second array: ", i);
            secondArr[i] = char.Parse(Console.ReadLine());
        }

        //iritate a loop until the end of the smaller array and compare the two letter by letter
        int smallestLen = firstArrLen;

        if (secondArrLen < firstArrLen)
        {
            smallestLen = secondArrLen;
        }

        for (int i = 0; i < smallestLen; i++)
        {
            if (firstArr[i] < secondArr[i])
            {
                Console.WriteLine("The first char array is lexicographycally smaller");
                return;
            }
            else if(secondArr[i] < firstArr[i]) 
            {
                Console.WriteLine("The second char array is lexicographycally smaller");
                return;
            }
        }

        //if they have the same symbols, but one of them is bigger this is the lexicographycally 
        //bigger array. if they have the same symbols and the same length, they are equal
        if (firstArrLen < secondArrLen)
        {
            Console.WriteLine("The first char array is lexicographycally smaller");
        }
        else if (secondArrLen < firstArrLen)
        {
            Console.WriteLine("The second char array is lexicographycally smaller");
        }
        else
        {
            Console.WriteLine("The two arrays are equal");
        }
    }
}
