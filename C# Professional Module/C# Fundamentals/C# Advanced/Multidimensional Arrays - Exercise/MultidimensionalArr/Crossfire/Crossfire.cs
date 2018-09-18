using System;
using System.Collections.Generic;
using System.Linq;

class Crossfire
{
    static void Main()
    {
        int[] dimensons = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int rows = dimensons[0];
        int columns = dimensons[1];

        var matrix = FillMatrix(rows, columns);

        string input = Console.ReadLine();

        while (input != "Nuke it from orbit")
        {
            int[] commands = input.Split().Select(int.Parse).ToArray();
            int rowImpact = commands[0];
            int colImpact = commands[1];
            int radius = commands[2];

            for (int row = rowImpact - radius; row <= rowImpact + radius; row++)
            {
                if (IsInMatrix(row, colImpact, matrix))
                {
                    matrix[row][colImpact] = -1;
                }
            }

            for (int col = colImpact - radius; col <= colImpact + radius; col++)
            {
                if (IsInMatrix(rowImpact, col, matrix))
                {
                    matrix[rowImpact][col] = -1;
                }
            }

            FilterMatrix(matrix);

            input = Console.ReadLine();
        }

        PrintMatrix(matrix);
    }

    private static void FilterMatrix(List<List<int>> matrix)
    {
        for (int row = matrix.Count - 1; row >= 0; row--)
        {
            for (int col = matrix[row].Count - 1; col >= 0; col--)
            {
                if (matrix[row][col] == -1)
                {
                    matrix[row].RemoveAt(col);
                }
            }

            if (matrix[row].Count == 0)
            {
                matrix.RemoveAt(row);
            }
        }
    }

    private static void PrintMatrix(List<List<int>> matrix)
    {
        for (int row = 0; row < matrix.Count; row++)
        {
            Console.WriteLine($"{string.Join(" ", matrix[row])}");
        }
    }

    private static bool IsInMatrix(int row, int col, List<List<int>> matrix)
    {
        if (row >= 0 && row < matrix.Count && col >= 0 && col < matrix[row].Count)
        {
            return true;
        }

        return false;
    }

    private static List<List<int>> FillMatrix(int rows, int columns)
    {
        var matrix = new List<List<int>>();
        int count = 1;

        for (int row = 0; row < rows; row++)
        {
            matrix.Add(new List<int>());

            for (int col = 0; col < columns; col++)
            {
                matrix[row].Add(count);
                count++;
            }
        }

        return matrix;
    }
}

