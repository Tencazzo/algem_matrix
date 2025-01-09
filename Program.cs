using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algem_matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите размерность системы уравнений (n):");
            int n = int.Parse(Console.ReadLine());

            double[,] A = new double[n, n];
            double[] B = new double[n];

            Console.WriteLine("Введите матрицу коэффициентов (A):");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Введите строку {i + 1} (через пробел):");
                string[] input = Console.ReadLine().Split(' ');
                for (int j = 0; j < n; j++)
                {
                    A[i, j] = double.Parse(input[j]);
                }
            }

            Console.WriteLine("Введите  свободные члены (B):");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Введите элемент {i + 1}:");
                B[i] = double.Parse(Console.ReadLine());
            }

            double[] solution = Gauss(A, B);

            Console.WriteLine("Решение системы уравнений:");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"x{i + 1} = {solution[i]}");
            }
        }

        static double[] Gauss(double[,] a, double[] b)
        {
            int n = b.Length;

            // Прямой ход
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (a[j, i] == 0)
                        continue;

                    double ratio = a[j, i] / a[i, i];
                    for (int k = i; k < n; k++)
                    {
                        a[j, k] -= ratio * a[i, k];
                    }
                    b[j] -= ratio * b[i];
                }
            }

            // Обратный ход
            double[] x = new double[n];
            for (int i = n - 1; i >= 0; i--)
            {
                x[i] = b[i];
                for (int j = i + 1; j < n; j++)
                {
                    x[i] -= a[i, j] * x[j];
                }
                x[i] /= a[i, i];
            }

            return x;
        }
    }
}
