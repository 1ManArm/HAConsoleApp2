using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAConsoleApp2
{
    internal class Program
    {

        static int[,] MultiplyMatrixByScalar(int[,] matrix, int scalar)
        {
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);
            int[,] resultMatrix = new int[rows, columns];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    resultMatrix[i, j] = matrix[i, j] * scalar;
                }
            }
            return resultMatrix;
        }

        static int[,] AddMatrices(int[,] matrixA, int[,] matrixB)
        {
            int rows = matrixA.GetLength(0);
            int columns = matrixA.GetLength(1);
            int[,] resultMatrix = new int[rows, columns];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    resultMatrix[i, j] = matrixA[i, j] + matrixB[i, j];
                }
            }
            return resultMatrix;
        }

        static int[,] MultiplyMatrices(int[,] matrixA, int[,] matrixB)
        {
            int rowsA = matrixA.GetLength(0);
            int columnsA = matrixA.GetLength(1);
            int rowsB = matrixB.GetLength(0);
            int columnsB = matrixB.GetLength(1);
            int[,] resultMatrix = new int[rowsA, columnsB];
            if (columnsA != rowsB)
            {
                Console.WriteLine("Умножение матриц невозможно.");
                return null;
            }
            else
            {
                for (int i = 0; i < rowsA; i++)
                {
                    for (int j = 0; j < columnsB; j++)
                    {
                        for (int k = 0; k < columnsA; k++)
                        {
                            resultMatrix[i, j] += matrixA[i, k] * matrixB[k, j];
                        }
                    }
                }
                return resultMatrix;
            }
        }

        static void PrintMatrix(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            //Задание 1
            double[] A1 = new double[5];
            double[,] B1 = new double[3, 4];
            double composAB1 = 1;
            double sumA1 = 0;
            double sumB1 = 0;
            Random rand = new Random();
            try
            {
                Console.WriteLine("Заполнение массива А");

                for (int i = 0; i < A1.Length; i++)
                {
                    Console.WriteLine($"Введите {i} элемент массива А");
                    A1[i] = Convert.ToDouble(Console.ReadLine());
                    composAB1 = composAB1 * A1[i];
                    if (i % 2 == 0)
                    {
                        sumA1 += A1[i];
                    }
                    Console.Clear();
                }
                for (int i = 0; i < B1.GetLength(0); i++)
                {
                    for (int j = 0; j < B1.GetLength(1); j++)
                    {
                        B1[i, j] = Math.Round(rand.NextDouble(), 2) + rand.Next(10);
                        composAB1 = composAB1 * B1[i, j];
                        if (j % 2 != 0)
                        {
                            sumB1 += B1[i, j];
                        }
                    }
                }
                Console.WriteLine("Массив А");
                for (int i = 0; i < A1.Length; i++)
                {
                    Console.Write($"{A1[i]}" + "\t");
                }
                Console.WriteLine();
                Console.WriteLine("Массив B");
                for (int i = 0; i < B1.GetLength(0); i++)
                {
                    for (int j = 0; j < B1.GetLength(1); j++)
                    {
                        Console.Write($"{B1[i, j]}" + "\t");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();

                Console.WriteLine("Максимальный элемент массива А = " + A1.Max());
                Console.WriteLine("Максимальный элемент массива B = " + B1.Cast<double>().Max());

                if (B1.Cast<double>().Contains(A1.Max()))
                {
                    Console.WriteLine("Максимальный общий элемент в массивах = " + A1.Max());
                }
                else
                {
                    Console.WriteLine("Общего максимального элемента в массивах нет ");
                }

                Console.WriteLine("Минимальный элемент массива А = " + A1.Min());
                Console.WriteLine("Минимальный элемент массива B = " + B1.Cast<double>().Min());

                if (A1.Min() == B1.Cast<double>().Min())
                {
                    Console.WriteLine("Минимальный общий элемент в массивах = " + A1.Min());
                }
                else
                {
                    Console.WriteLine("Общего минимального элемента в массивах нет ");
                }

                Console.WriteLine("Сумма элементов массивов = " + (A1.Sum() + B1.Cast<double>().Sum()));

                Console.WriteLine("Общее произведение элементов массивов = " + composAB1);

                Console.WriteLine("Cуммa четных элементов массива А = " + sumA1);

                Console.WriteLine("Cуммa нечетных столбцов массива В = " + sumB1);

            }
            catch (Exception)
            {
                Console.WriteLine("Завершение программы");
                Environment.Exit(0);
            }
            Console.WriteLine("////////////////////////////////////////");
            //Задание 2
            int[,] B2 = new int[5, 5];
            int sumB2 = 0, max = B2[0, 0], min = B2[0, 0];
            int ni = 0, mj = 0, ki = 0, lj = 0;
            bool count = false;

            try
            {
                Console.WriteLine("Заполнение массива А");
                Console.WriteLine("Массив B");
                for (int i = 0; i < B2.GetLength(0); i++)
                {
                    for (int j = 0; j < B2.GetLength(1); j++)
                    {
                        B2[i, j] = rand.Next(-100, 100);
                        if (max < B2[i, j])
                        {
                            max = B2[i, j];
                            ni = i;
                            mj = j;
                        }
                        if (min > B2[i, j])
                        {
                            min = B2[i, j];
                            ki = i;
                            lj = j;
                        }
                        Console.Write($"{B2[i, j]}\t");
                    }
                    Console.WriteLine();
                }

                for (int i = 0; i < B2.GetLength(0); i++)
                {
                    for (int j = 0; j < B2.GetLength(1); j++)
                    {
                        if ((i == ni && j == mj) || (i == ki && j == lj))
                        {
                            if (count)
                            {
                                count = false;
                                continue;
                            }
                            else
                            {
                                count = true;
                                continue;
                            }
                        }
                        if (count)
                        {
                            sumB2 += B2[i, j];
                        }
                    }
                }

                Console.WriteLine();

                Console.WriteLine("Максимальный элемент массива B = " + max);
                Console.WriteLine("Минимальный элемент массива B = " + min);

                Console.WriteLine($"Максимальный элемент {B2.Cast<int>().Max()} находится в массиве строка {ni + 1} столбец {mj + 1} позиции");
                Console.WriteLine($"Минимальный элемент {B2.Cast<int>().Min()} находится в массиве строка {ki + 1} столбец {lj + 1} позиции");

                Console.WriteLine("Cуммa элементов массива, расположенных между минимальным и максимальным элементами = " + sumB2);
            }
            catch (Exception)
            {
                Console.WriteLine("Завершение программы");
                Environment.Exit(0);
            }
            Console.WriteLine("////////////////////////////////////////");
            //Задание 4

            int rows = 3;
            int columns = 3;

            int[,] matrixA = new int[rows, columns];
            Console.WriteLine("Введите матрицу A:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matrixA[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }

            // Создание и инициализация матрицы B
            int[,] matrixB = new int[rows, columns];
            Console.WriteLine("Введите матрицу B:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matrixB[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }

            // Умножение матрицы на число
            int scalar = 2;
            int[,] resultMatrix1 = MultiplyMatrixByScalar(matrixA, scalar);

            // Сложение матриц
            int[,] resultMatrix2 = AddMatrices(matrixA, matrixB);

            // Произведение матриц
            int[,] resultMatrix3 = MultiplyMatrices(matrixA, matrixB);

            // Вывод результатов
            Console.WriteLine("Скалярное умножение матрицы А:");
            PrintMatrix(resultMatrix1);

            Console.WriteLine("Сложение матриц A и B:");
            PrintMatrix(resultMatrix2);

            Console.WriteLine("Умножение матриц A и B:");
            PrintMatrix(resultMatrix3);
        }
    }
}