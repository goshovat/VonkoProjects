using System;

class CompareCharArrays
{
    static void Main()
    {
        //get the input data
        Console.WriteLine("Enter the length of the first char array: ");
        int len1 = int.Parse(Console.ReadLine());
        char[] myArray1 = new char[len1];

        for (int i = 0; i < len1; i++)
        {
            Console.WriteLine("Enter element {0} of the first array: ", i);
            myArray1[i] = char.Parse(Console.ReadLine());
        }

        Console.WriteLine("Enter the length of the second char array:");
        int len2 = int.Parse(Console.ReadLine());
        char[] myArray2 = new char[len2];

        for (int i = 0; i < len2; i++)
        {
            Console.WriteLine("Enter element {0} of the second array: ", i);
            myArray2[i] = char.Parse(Console.ReadLine());
        }

        //compare the arrays
        int lowerLen = len1;
        if (len2 < len1)
        {
            lowerLen = len2;
        }

        //check if they have different elements
        for (int i = 0; i < lowerLen; i++)
        {
            if (myArray1[i] < myArray2[i])
            {
                Console.WriteLine("Array 1 is lexicographically earlier");
                return;
            }
            else if (myArray2[i] < myArray1[i])
            {
                Console.WriteLine("Array 2 is lexicographycally earlier");
                return; ;
            }
        }

        //if no different elements are found compare the lengths
        if (len1 == len2)
        {
            Console.WriteLine("The two arrays are lexicographycally equal");
        }
        else if (len1 < len2)
        {
            Console.WriteLine("Array 1 is lexicographically earlier");
        }
        else
        {
            Console.WriteLine("Array 2 is lexicographycally earlier");
        }
    }
}
