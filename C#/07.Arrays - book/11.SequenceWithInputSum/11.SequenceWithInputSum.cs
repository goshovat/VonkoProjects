using System;

class SequenceWithInputSum
{
    static void Main()
    {
        //////Initialize the array
        //Console.WriteLine("Enter the length of the array: ");
        //int arrLen = int.Parse(Console.ReadLine());
        //int[] myArr = new int[arrLen];

        ////set the values of the array
        //for (int i = 0; i < arrLen; i++)
        //{
        //    Console.WriteLine("Enter element No {0} of the array: ", i);
        //    myArr[i] = int.Parse(Console.ReadLine());
        //}

        Console.WriteLine("Enter the sum: ");
        int sum = int.Parse(Console.ReadLine());

        //int[] myArr = { 4, 3, 1, 4, 2, 5, 8};
        int[] myArr = { 5, 4, 3, 1, 4, 2, 1, 5, 8 };
        int arrLen = myArr.Length;

        //find the sum
        int tempStartIndex = 0;
        int startIdex = 0;
        int endIndex = 0;
        int currentSum = int.MinValue;

        for (int i = 0; i < arrLen; i++)
        {
            currentSum = myArr[i];
            tempStartIndex = i;

            for (int j = i + 1; j < arrLen; j++)
            {
                currentSum += myArr[j];

                if (currentSum > sum)
                {
                    break;
                }
                else if (currentSum == sum)
                {
                    startIdex = tempStartIndex;
                    endIndex = j;
                    break;
                }
            }

            if (currentSum == sum)
            {
                break;
            }
        }

        //print the elements
        if (currentSum != sum)
        {
            Console.WriteLine("There is no such sequence!");
        }
        else
        {
            Console.WriteLine("The sequence with the given sum is: ");
            for (int i = startIdex; i <= endIndex; i++)
            {
                Console.Write(myArr[i] + " ");
            }
            Console.WriteLine();
        }
    }
}

