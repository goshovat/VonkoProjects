namespace NumbersMatrix
{
    using System;
    using System.Reflection;

    public class Matrix<T>
    {
        private T[,] innerMatrix;

        public Matrix(int height, int width)
        {
            if (typeof(T) != typeof(Int16) &&
                typeof(T) != typeof(Int32) &&
                typeof(T) != typeof(Int64) &&
                typeof(T) != typeof(UInt16) &&
                typeof(T) != typeof(UInt32) &&
                typeof(T) != typeof(UInt64) &&
                typeof(T) != typeof(float) &&
                typeof(T) != typeof(Double) &&
                typeof(T) != typeof(Decimal))
            {
                throw new ArgumentException(
                  string.Format("Type '{0}' is not valid.", typeof(T).ToString()));
            }
            this.innerMatrix = new T[height, width];
        }

        public int Height { get { return this.innerMatrix.GetLength(0); } }
        public int Width { get { return this.innerMatrix.GetLength(1); } }
        public int Count { get { return this.Height * this.Width; } }

        public T this[int row, int col]
        {
            get { return this.innerMatrix[row, col]; }
            set { this.innerMatrix[row, col] = value; }
        }

        public void Clear()
        {
            for (int row = 0; row < this.Height; row++)
            {
                for (int col = 0; col < this.Width; col++)
                {
                    this[row, col] = default(T);
                }
            }
        }

        public static Matrix<T> operator +(Matrix<T> matrix1, Matrix<T> matrix2)
        {
            if (matrix1.Height != matrix2.Height
                || matrix1.Width != matrix2.Width)
                throw new ApplicationException("Cannot sum matrixes of different size.");

            Matrix<T> resultMatrix = new Matrix<T>(
                matrix1.Height, matrix1.Width);

            for (int row = 0; row < matrix1.Height; row++)
            {
                for (int col = 0; col < matrix1.Width; col++)
                {
                    resultMatrix[row, col] = (T)(object)
                        ((decimal)((object)matrix1[row, col]) +
                        (decimal)(object)matrix2[row, col]);
                }
            }
            return resultMatrix;
        }

        public static Matrix<T> operator -(Matrix<T> matrix1, Matrix<T> matrix2)
        {
            if (matrix1.Height != matrix2.Height
                || matrix1.Width != matrix2.Width)
                throw new ApplicationException("Cannot sum matrixes of different size.");

            Matrix<T> resultMatrix = new Matrix<T>(
                matrix1.Height, matrix1.Width);

            for (int row = 0; row < matrix1.Height; row++)
            {
                for (int col = 0; col < matrix1.Width; col++)
                {
                    resultMatrix[row, col] = (T)(object)
                        ((decimal)((object)matrix1[row, col]) -
                        (decimal)(object)matrix2[row, col]);
                }
            }
            return resultMatrix;
        }

        public static Matrix<T> operator *(Matrix<T> matrix1, Matrix<T> matrix2)
        {
            if (matrix1.Height != matrix2.Height
                || matrix1.Width != matrix2.Width)
                throw new ApplicationException("Cannot sum matrixes of different size.");

            Matrix<T> resultMatrix = new Matrix<T>(
                matrix1.Height, matrix1.Width);

            for (int row = 0; row < matrix1.Height; row++)
            {
                for (int col = 0; col < matrix1.Width; col++)
                {
                    resultMatrix[row, col] = (T)(object)
                        ((decimal)((object)matrix1[row, col]) *
                        (decimal)(object)matrix2[row, col]);
                }
            }
            return resultMatrix;
        }

        public static bool operator true(Matrix<T> matrix)
        {
            for (int row = 0; row < matrix.Height; row++)
            {
                for (int col = 0; col < matrix.Width; col++)
                {
                    if (!matrix[row, col].Equals(default(T)))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool operator false(Matrix<T> matrix)
        {
            bool isEmpty = true;

            for (int row = 0; row < matrix.Height; row++)
            {
                for (int col = 0; col < matrix.Width; col++)
                {
                    if (!matrix[row, col].Equals(default(T)))
                    {
                        isEmpty = false;
                    }
                }
            }

            return isEmpty;
        }
    }
}
