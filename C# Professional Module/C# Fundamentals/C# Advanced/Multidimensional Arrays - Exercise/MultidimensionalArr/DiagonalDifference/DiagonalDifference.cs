using System;
using System.Linq;

class DiagonalDifference
{
    static void Main()
    {
        int size = int.Parse(Console.ReadLine());
        int[,] matrix = new int[size, size];

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            int[] rowValues = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[i, j] = rowValues[j];
            }
        }

        int primaryDiagonal = 0;
        int secondaryDiagonal = 0;

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (i == j)
                {
                    primaryDiagonal += matrix[i, j];
                }
                if (i + j == size - 1)
                {
                    secondaryDiagonal += matrix[i, j];
                }
            }
        }

        Console.WriteLine(Math.Abs(primaryDiagonal - secondaryDiagonal));
    }
}

