using System;

namespace Task_5
{
    class Program
    {
        static void Main(string[] args)
        {
            double[,] a = {{1.5, 5, -1},
                          {12, 3, 4},
                          {6, 10, -11},
                          {1, 2, 3.5}};
            double[][] b = new double[a.GetLength(0)][];
            for (int i = 0; i < a.GetLength(0); i++)
            {
                int count = 0;
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    if (a[i, j] % 2 == 0)
                    {
                        count++;
                    }
                }
                b[i] = new double[count];
            }
            for (int i = 0; i < a.GetLength(0); i++)
            {
                int k = 0;
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    if (a[i, j] % 2 == 0)
                    {
                        b[i][k++] = a[i, j];
                    }
                }
            }
            for (int i = 0; i < b.Length; i++)
            {
                for (int j = 0; j < b[i].Length; j++)
                {
                    Console.Write(b[i][j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}