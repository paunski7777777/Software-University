using System;
using System.Linq;

class MaximalSum
{
    static void Main()
    {
        int[] size = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int row = size[0];
        int column = size[1];


        int[,] matrix = new int[row, column];

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            int[] rowValues = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[i, j] = rowValues[j];
            }
        }

        int sum = 0;
        int rowIndex = 0;
        int columnIndex = 0;

        for (int i = 0; i < matrix.GetLength(0) - 2; i++)
        {
            for (int j = 0; j < matrix.GetLength(1) - 2; j++)
            {
                int tempSum = matrix[i, j] + matrix[i, j + 1] + matrix[i, j + 2] + 
                    matrix[i + 1, j] + matrix[i + 1, j + 1] + matrix[i + 1, j + 2] +
                    matrix[i + 2, j] + matrix[i + 2, j + 1] + matrix[i + 2, j + 2];

                if (tempSum > sum)
                {
                    sum = tempSum;
                    rowIndex = i;
                    columnIndex = j;
                }
            }
        }

        Console.WriteLine($"Sum = {sum}");

        Console.WriteLine($"{matrix[rowIndex, columnIndex]} {matrix[rowIndex, columnIndex + 1]} {matrix[rowIndex, columnIndex + 2]}");
        Console.WriteLine($"{matrix[rowIndex + 1, columnIndex]} {matrix[rowIndex + 1, columnIndex + 1]} {matrix[rowIndex + 1, columnIndex + 2]}");
        Console.WriteLine($"{matrix[rowIndex + 2, columnIndex]} {matrix[rowIndex + 2, columnIndex + 1]} {matrix[rowIndex + 2, columnIndex + 2]}");
    }
}

