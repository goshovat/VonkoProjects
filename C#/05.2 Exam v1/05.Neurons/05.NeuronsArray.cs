using System;
using System.Collections.Generic;

class Neurons
{
    static void Main()
    {
        //define a list to store all input values like binary strings
        List<string> inputListStr = new List<string>();

        //define a list to store all outpute numbers like decimal integers
        List<int> outputNumbers = new List<int>();

        int rows = 0;

        //get and process the input integers
        while (true)
        {
            long currentNumber = long.Parse(Console.ReadLine());

            if (currentNumber == -1)
            {
                break;
            }

            rows++;

            //process and store the input number as a binary string
            string currentInputStr = Convert.ToString(currentNumber, 2).PadLeft(32, '0');
            inputListStr.Add(currentInputStr);
        }

        //initialize the char for the output number
        char[] outputRow = CreateOutputRow(32);

        //process the input numbers into the output numbers
        for (int row = 0; row < rows; row++)
        {
            int col = 0;
            string currentRowStr = inputListStr[row];

            //create a char array filled with zeroes to store the processed output numbers in binary
            outputRow = CreateOutputRow(32);

            while (col < 32)
            {
                if (currentRowStr[col] == '1')
                {
                    outputRow[col] = '0';
                    col++;
                    if (col > 31)
                    {
                        break;
                    }

                    if (currentRowStr[col] == '0')
                    {
                        int storeCol = col;
                        while (col < 32)
                        {
                            if (currentRowStr[col] == '1')
                            {
                                col = storeCol;
                                while (currentRowStr[col] == '0')
                                {
                                    outputRow[col] = '1';
                                    col++;
                                }
                                outputRow[col] = '0';
                                break;
                            }
                            col++;
                        }
                    }
                }
                else
                {
                    col++;
                }
            }

            string currentnewRow = new string(outputRow);
            int currentOutputNumber = Convert.ToInt32(currentnewRow, 2);
            outputNumbers.Add(currentOutputNumber);

        }

        //print the result
        for (int i = 0; i < outputNumbers.Count; i++)
        {
            Console.WriteLine(outputNumbers[i]);
        }
    }

    //define a method to create a new char array of zeroes on each row
    static char[] CreateOutputRow(int len)
    {
        char[] outputRow = new char[len];

        for (int i = 0; i < len; i++)
        {
            outputRow[i] = '0';
        }

        return outputRow;
    }

}

