using System;
using System.Linq;

class SquareWithMaximumSum
{
    static void Main()
    {
        int[,] matrix = ReadMatrix();

        int sum = 0;
        int rowIndex = 0;
        int columnIndex = 0;

        for (int i = 0; i < matrix.GetLength(0) - 1; i++)
        {
            for (int j = 0; j < matrix.GetLength(1) - 1; j++)
            {
                int tempSum = matrix[i, j] + matrix[i, j + 1] + matrix[i + 1, j] + matrix[i + 1, j + 1];

                if (tempSum > sum)
                {
                    sum = tempSum;
                    rowIndex = i;
                    columnIndex = j;
                }
            }
        }

        Console.WriteLine($"{matrix[rowIndex, columnIndex]} {matrix[rowIndex, columnIndex + 1]}");
        Console.WriteLine($"{matrix[rowIndex + 1, columnIndex]} {matrix[rowIndex + 1, columnIndex + 1]}");
        Console.WriteLine(sum);
    }

    private static int[,] ReadMatrix()
    {
        int[] input = Console.ReadLine().Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        int row = input[0];
        int column = input[1];

        int[,] matrix = new int[row, column];

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            int[] rowValues = Console.ReadLine().Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[i, j] = rowValues[j];
            }
        }

        return matrix;
    }
}

