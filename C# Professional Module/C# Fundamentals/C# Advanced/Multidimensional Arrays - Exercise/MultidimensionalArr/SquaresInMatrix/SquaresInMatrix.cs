using System;
using System.Linq;

class SquaresInMatrix
{
    static void Main()
    {
        char[,] matrix = ReadMatrix();

        int count = FindSquare(matrix);

        Console.WriteLine(count);
    }

    private static int FindSquare(char[,] matrix)
    {
        int count = 0;

        for (int i = 0; i < matrix.GetLength(0) - 1; i++)
        {
            for (int j = 0; j < matrix.GetLength(1) - 1; j++)
            {
                if (matrix[i, j] == matrix[i, j + 1]
                    && matrix[i, j] == matrix[i + 1, j]
                    && matrix[i, j] == matrix[i + 1, j + 1])
                {
                    count++;
                }
            }
        }

        return count;
    }

    private static char[,] ReadMatrix()
    {
        int[] size = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int row = size[0];
        int column = size[1];

        char[,] matrix = new char[row, column];


        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            char[] rowValues = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[i, j] = rowValues[j];
            }
        }

        return matrix;
    }
}

