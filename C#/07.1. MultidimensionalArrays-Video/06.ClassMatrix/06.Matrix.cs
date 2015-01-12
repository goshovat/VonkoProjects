using System;

class Matrix
{
    private int[,] matrix;

    //constructor of the class
    public Matrix(int rows, int cols)
    {
        this.matrix = new int[rows, cols];   
    }

    //define property for rows
    public int Rows
    {
        get
        {
            return this.matrix.GetLength(0);
        }
    }

    //define property for columns
    public int Columns
    {
        get
        {
            return this.matrix.GetLength(1);
        }
    }

    //redefine the operators
    public static Matrix operator + (Matrix first, Matrix second) 
    {
        //check if the two matrixes hav the same sizes
        if (first.Rows != second.Rows || first.Columns != second.Columns)
        {
            Console.WriteLine("The matrixes are of different sizes!");

            //if they are different sizes the operator will return the first matrix
            return first;
        }

        Matrix result = new Matrix(first.Rows, first.Columns);

        for (int row = 0; row < first.Rows; row++)
        {
            for (int col = 0; col < first.Columns; col++)
            {
                result[row, col] = first[row, col] + second[row, col];
            }
        }

        return result;
    }

    public static Matrix operator -(Matrix first, Matrix second)
    {
        //check if the two matrixes have the same sizes
        if (first.Rows != second.Rows || first.Columns != second.Columns)
        {
            Console.WriteLine("The matrixes are of different sizes!");

            //if they are different sizes the operator will return the first matrix
            return first;
        }

        Matrix result = new Matrix(first.Rows, first.Columns);

        for (int row = 0; row < first.Rows; row++)
        {
            for (int col = 0; col < first.Columns; col++)
            {
                result[row, col] = first[row, col] - second[row, col];
            }
        }

        return result;
    }

    public static Matrix operator *(Matrix first, Matrix second) 
    {
        //check if the two matrixes hav the same sizes
        if (first.Rows != second.Rows || first.Columns != second.Columns)
        {
            Console.WriteLine("The matrixes are of different sizes!");

            //if they are different sizes the operator will return the first matrix
            return first;
        }

        Matrix result = new Matrix(first.Rows, first.Columns);

        for (int row = 0; row < first.Rows; row++)
        {
            for (int col = 0; col < first.Columns; col++)
            {
                result[row, col] = first[row, col] * second[row, col];
            }
        }

        return result;
    }

    //define indexator
    public int this[int row, int col]
    {
        get
        {
            return this.matrix[row, col];
        }

        set
        {
            this.matrix[row, col] = value;
        }
    }

    //override the string method
    public override string ToString()
    {
        string result = null;

        for (int row = 0; row < this.Rows; row++)
        {
            for (int col = 0; col < this.Columns; col++)
            {
                result += this[row, col] + " ";
            }

            result += Environment.NewLine;
        }

        return result;
    }
}
