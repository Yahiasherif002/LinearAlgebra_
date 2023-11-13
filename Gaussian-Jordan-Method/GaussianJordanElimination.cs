using System;
using System.Text;

namespace ConsoleApplication6
{
    class GaussianJordanElimination
    {
        double[,] a;
        int rows;
        int cols;

        public GaussianJordanElimination()
        {
        }

        public void setArray(double[,] arr)
        {
            this.a = arr;
            this.rows = arr.GetLength(0);
            this.cols = arr.GetLength(1);
        }

        public void printMatrix(double[,] mat)
        {
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    Console.Write(mat[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        public void swapRows(int row1, int row2)
        {
            if (a == null)
            {
                Console.WriteLine("Array is null.");
                return;
            }

            if (row1 < 0 || row1 >= rows || row2 < 0 || row2 >= rows)
            {
                Console.WriteLine("Invalid row indices.");
                return;
            }

            for (int col = 0; col < cols; col++)
            {
                double temp = a[row1, col];
                a[row1, col] = a[row2, col];
                a[row2, col] = temp;
            }

            Console.WriteLine("Swapping row " + row1 + " with row " + row2);
        }

        public string matToString(double[,] mat)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    sb.Append(mat[i, j] + "  ");
                }
                Console.WriteLine();
                sb.Append("\n");
            }
            sb.Append("\n");
            return sb.ToString();
        }

        public string solve()
        {
            StringBuilder sb = new StringBuilder();

            Console.WriteLine("Displaying input Matrix");
            printMatrix(a);
            sb.Append("Displaying input Matrix \n");
            sb.Append(matToString(a));

            for (int i = 0; i < rows; i++)
            {
                if (a[i, i] == 0)
                {
                    for (int k = i + 1; k < rows; k++)
                    {
                        if (a[k, i] != 0)
                        {
                            swapRows(i, k);

                            Console.WriteLine("Swapping row " + i + " with row " + k);
                            sb.Append("Swapping row " + i + " with row " + k + "\n");

                            break;
                        }
                    }

                    if (a[i, i] == 0)
                    {
                        Console.WriteLine("Matrix is singular. Unable to continue.");
                        sb.Append("Matrix is singular. Unable to continue.\n");
                        return sb.ToString();
                    }
                }

                double temp = a[i, i];

                for (int j = 0; j < cols; j++)
                {
                    a[i, j] = a[i, j] / temp;
                }

                Console.WriteLine("Row operation is row" + i + " is divided by " + temp);
                printMatrix(a);
                sb.Append("Row operation is row" + i + " is divided by " + temp + " \n");
                sb.Append(matToString(a));

                for (int k = 0; k < rows; k++)
                {
                    if (i != k)
                    {
                        temp = a[k, i];
                        for (int j = 0; j < cols; j++)
                        {
                            a[k, j] = a[k, j] - (temp * a[i, j]);
                        }
                        Console.WriteLine("Row operation is row" + i + " is multiplied by " + temp +
                                          " and then subtracted from row" + k);
                        printMatrix(a);
                        sb.Append("Row operation is row" + i + " is multiplied by " + temp +
                                  " and then subtracted from row" + k + " \n");
                        sb.Append(matToString(a));
                    }
                }
            }

            Console.WriteLine("Solved matrix");
            printMatrix(a);
            sb.Append("Solved matrix \n");
            sb.Append(matToString(a));

            return sb.ToString();
        }

        public static double DET(int n, double[,] Mat)
        {
            double d = 0;
            int k, i, j, subi, subj;
            double[,] SUBMat = new double[n, n];

            if (n == 2)
            {
                return ((Mat[0, 0] * Mat[1, 1]) - (Mat[1, 0] * Mat[0, 1]));
            }
            else
            {
                for (k = 0; k < n; k++)
                {
                    subi = 0;
                    for (i = 1; i < n; i++)
                    {
                        subj = 0;
                        for (j = 0; j < n; j++)
                        {
                            if (j == k)
                            {
                                continue;
                            }
                            SUBMat[subi, subj] = Mat[i, j];
                            subj++;
                        }
                        subi++;
                    }
                    d = d + (Math.Pow(-1, k) * Mat[0, k] * DET(n - 1, SUBMat));
                }
            }
            return d;
        }
    }
}
