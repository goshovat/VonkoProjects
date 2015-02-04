using System;

class MatrixClass
{
    static void Main()
    {
        Matrix matrix1 = new Matrix(5, 5);
        Matrix matrix2 = new Matrix(5, 5);

        int rows = matrix1.Rows;
        Console.WriteLine(rows);

        matrix1[1, 0] = 5;
        matrix2[1, 0] = 6;

        Matrix resultAddition = matrix1 + matrix2;
        Matrix resultSubstraction = matrix1 - matrix2;
        Matrix resultMultiplication = matrix1 * matrix2;

        //test the operators and methods we overrided
        Console.WriteLine("Addition matrix \r\n {0}", resultAddition.ToString());
        Console.WriteLine("Substraction matrix \r\n {0}", resultSubstraction.ToString());
        //even if we don't write ToString() Console.WriteLine() secretely calls it
        Console.WriteLine("Multiplied matrix \r\n {0}", resultMultiplication);
    }
}
