using System;
using System.Linq;

class SumMatrixElements
{
    static void Main()
    {
        int[] input = Console.ReadLine().Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        int row = input[0];
        int column = input[1];

        int[,] matrix = new int[row, column];
        int sum = 0;

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            int[] rowValues = Console.ReadLine().Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[i, j] = rowValues[j];
            }
        }

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                sum += matrix[i, j];
            }
        }

        Console.WriteLine(matrix.GetLength(0));
        Console.WriteLine(matrix.GetLength(1));
        Console.WriteLine(sum);
    }
}

