using System;
using System.Linq;

class MatrixOfPalindromes
{
    static void Main()
    {
        int[] rowsAndColumns = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int row = rowsAndColumns[0];
        int column = rowsAndColumns[1];

        char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
        string[,] matrix = new string[row, column];

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                char first = alphabet[i];
                char second = alphabet[i + j];
                var element = $"{first}{second}{first}";
                matrix[i, j] = element;
            }
        }

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}

