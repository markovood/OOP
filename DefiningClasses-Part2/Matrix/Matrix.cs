namespace Matrix
{
    using System;
    using System.Text;
    using CustomAttributes;

    [Version(2, 11)]
    public class Matrix<T> where T : struct, IConvertible, IComparable, IFormattable, IComparable<T>, IEquatable<T>
    {
        // fields
        private T[,] matrix;

        private int rows;
        private int cols;

        // constructors
        public Matrix(int rows, int cols)
        {
            this.Rows = rows;
            this.Cols = cols;
            this.matrix = new T[this.Rows, this.Cols];
        }

        // properties
        public int Rows
        {
            get
            {
                return this.rows;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Matrix does not accept negative number of rows!!!");
                }

                this.rows = value;
            }
        }

        public int Cols
        {
            get
            {
                return this.cols;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Matrix does not accept negative number of columns!!!");
                }

                this.cols = value;
            }
        }

        // indexer
        public T this[int rowIndex, int colIndex]
        {
            get { return this.matrix[rowIndex, colIndex]; }
            set { this.matrix[rowIndex, colIndex] = value; }
        }

        // methods
        public static Matrix<T> operator +(Matrix<T> m1, Matrix<T> m2)
        {
            if ((m1.Rows != m2.Rows) || (m1.Cols != m2.Cols))
            {
                throw new ArgumentException("Adding matrices of different size is UNDEFINED!!!");
            }

            var result = new Matrix<T>(m1.Rows, m1.Cols);
            for (int i = 0; i < m1.Rows; i++)
            {
                for (int j = 0; j < m1.Cols; j++)
                {
                    result[i, j] = (dynamic)m1[i, j] + (dynamic)m2[i, j];
                }
            }

            return result;
        }

        public static Matrix<T> operator -(Matrix<T> m1, Matrix<T> m2)
        {
            if ((m1.Rows != m2.Rows) || (m1.Cols != m2.Cols))
            {
                throw new ArgumentException("Subtracting matrices of different size is UNDEFINED!!!");
            }

            var result = new Matrix<T>(m1.Rows, m2.Cols);
            for (int i = 0; i < m1.Rows; i++)
            {
                for (int j = 0; j < m1.Cols; j++)
                {
                    result[i, j] = (dynamic)m1[i, j] - (dynamic)m2[i, j];
                }
            }

            return result;
        }

        public static Matrix<T> operator *(Matrix<T> m1, Matrix<T> m2)
        {
            if (m1.Cols != m2.Rows)
            {
                throw new ArgumentException("Columns of the first matrix are not equal to the rows of the second one!!!");
            }

            var resultMatrix = new Matrix<T>(m1.Rows, m2.Cols);
            for (int i = 0; i < resultMatrix.Rows; i++)
            {
                for (int j = 0; j < resultMatrix.Cols; j++)
                {
                    T resultCalculation = default(T);
                    for (int k = 0; k < m1.Cols; k++)
                    {
                        resultCalculation += (dynamic)m1[i, k] * (dynamic)m2[k, j];
                    }

                    resultMatrix[i, j] = resultCalculation;
                }
            }

            return resultMatrix;
        }

        public static bool operator true(Matrix<T> m1)
        {
            for (int i = 0; i < m1.Rows; i++)
            {
                for (int j = 0; j < m1.Cols; j++)
                {
                    if ((dynamic)m1[i, j] == 0)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public static bool operator false(Matrix<T> m1)
        {
            for (int i = 0; i < m1.Rows; i++)
            {
                for (int j = 0; j < m1.Cols; j++)
                {
                    if ((dynamic)m1[i, j] == 0)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            for (int i = 0; i < this.Rows; i++)
            {
                for (int j = 0; j < this.Cols; j++)
                {
                    output.AppendFormat("{0,-11}", this.matrix[i, j]);
                }

                output.AppendLine();
            }

            return output.ToString();
        }
    }
}