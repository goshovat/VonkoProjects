using System;
using System.IO;
using System.Text;

class SquareMatrix
{
    static void Main()
    {
        string filePathName = @"..\..\matrix.txt";
        string sumFileName = @"..\..\GreatestSumInTheMatrix.txt";

        try
        {
            int biggestSum = FindBiggestSum(filePathName);

            File.WriteAllText(sumFileName, "Biggest sum: " + biggestSum);
        }
        catch (FileNotFoundException fileNotFoundExc)
        {
            Console.WriteLine("Error! The source files was not found. Details:\n{0}", fileNotFoundExc.StackTrace);
        }
        catch (FormatException formExc)
        {
            Console.WriteLine("Error! Invalid number in the matrix file. Details:\n{0}", formExc.StackTrace);
        }
        catch (IOException ioExc)
        {
            Console.WriteLine("Error occured during operations with the files. Details:\n{0}", ioExc.StackTrace);
        }
        catch (IndexOutOfRangeException indexOutRangeExc)
        {
            Console.WriteLine("Error! The index was outside the bounders of the matrix. Details:\n{0}", indexOutRangeExc.StackTrace);
        }
        catch (Exception e)
        {
            Console.WriteLine("Something fucked up happened! Details:\n{0}", e.StackTrace);
        }
    }

    //this method will read the matrix from a source file and return the biggest sum
    private static int FindBiggestSum(string filePathName)
    {
        StreamReader reader = new StreamReader(filePathName);
        int matrixSize = int.Parse(reader.ReadLine());

        int[,] matrix = new int[matrixSize, matrixSize];

        //save the numbers from the file in a matrix in the dynamic memory
        for (int row = 0; row < matrixSize; row++)
        {
            string line = reader.ReadLine();

            string[] numbersStr = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            for (int col = 0; col < matrixSize; col++)
            {
                matrix[row, col] = int.Parse(numbersStr[col]);
            }
        }

        //now find the biggest sum
        int biggestSum = 0;
        int currentSum = 0;

        for (int row = 0; row < matrixSize - 1; row++)
        {
            for (int col = 0; col < matrixSize - 1; col++)
            {
                currentSum = matrix[row, col] + matrix[row, col + 1]
                    + matrix[row + 1, col] + matrix[row + 1, col + 1];

                if (currentSum > biggestSum)
                    biggestSum = currentSum;
            }
        }

        return biggestSum;
    }
}

