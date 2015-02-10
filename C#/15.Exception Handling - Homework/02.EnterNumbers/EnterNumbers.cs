using System;
using System.Collections.Generic;

class EnterNumbers
{
    static void Main()
    {
        int start = 1;
        int end = 100;
        Console.WriteLine("The program will create a sequence form {0} to {1}", start, end);

        try
        {
            List<int> sequence = new List<int>();
            sequence = GetSequence(start, end);
            Console.WriteLine("The sequence of numbers is:\r\n{0}",
            string.Join(",", sequence));
        }
        catch (FormatException fmExc)
        {
            Console.WriteLine("Number cannot be parsed to integer! Details:\r\n{0}",
                fmExc.Message);
        }
        catch (ArgumentOutOfRangeException argOutOfRng)
        {
            Console.WriteLine("The argument is out of range! Details:\r\n{0}",
                argOutOfRng.Message);
        }
        catch (ApplicationException applExc)
        {
            Console.WriteLine("No more room for additional integer! Details:\r\n{0}",
                applExc.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine("Error occured during program execution. Details:\r\n{0}",
                e.Message);
        }
    }

    //the method that reads a single integer from console
    static int ReadInteger(int start, int end)
    {
        Console.WriteLine("Enter an integer between [{0}, {1}]", start, end);
        int number = 0;
        number = int.Parse(Console.ReadLine());

        if (number < start || number > end)
        {
            throw new ArgumentOutOfRangeException("Number is out of range! It should be between"
                + start + " and " + end);
        }
        return number;
    }

    //this method will create the sequence of the numbers
    static List<int> GetSequence(int start, int end)
    {
        List<int> sequence = new List<int>();
        //we do not want numbers equal to 1 or 100
        start++;
        end--;

        for (int i = 0; i < 10; i++)
        {
            int currentNumber = ReadInteger(start, end);
            sequence.Add(currentNumber);
            start = currentNumber + 1;

            if (i < 9 && start == 99)
                throw new ApplicationException("We cannot put another integer between "
                    + start + " and " + (int)(end + 1));
            if (start == 100)
                throw new ApplicationException("We cannot put another integer between "
                    + start + " and " + (int)(end + 1));
        }

        return sequence;
    }
}
