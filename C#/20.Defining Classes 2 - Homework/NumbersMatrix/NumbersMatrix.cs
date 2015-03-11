namespace NumbersMatrix
{
    using System;

    public static class NumbersMatrixMain
    {
        static void Main()
        {
            Matrix<decimal> matrix1 = new Matrix<decimal>(3, 4);
            for (int i = 0; i < matrix1.Height; i++)
            {
                for (int j = 0; j < matrix1.Width; j++)
                {
                    matrix1[i, j] = 2;
                }
            }

            Matrix<decimal> matrix2 = new Matrix<decimal>(3, 4);
            for (int i = 0; i < matrix2.Height; i++)
            {
                for (int j = 0; j < matrix2.Width; j++)
                {
                    matrix2[i, j] = 3;
                }
            }

            //test the operators
            Matrix<decimal> sumMatrix = matrix1 + matrix2;
            Matrix<decimal> substractionMatrix = matrix1 - matrix2;
            Matrix<decimal> multiplyMatrix = matrix1 * matrix2;

            //test the true operator
            if (matrix1)
                Console.WriteLine(true);
            else
                Console.WriteLine(false);

            matrix1.Clear();

            if (matrix1)
                Console.WriteLine(true);
            else
                Console.WriteLine(false);
        }
    }
}
