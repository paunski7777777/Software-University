using System;
using System.Collections.Generic;
using System.Linq;

class RubiksMatrix
{
    static void Main()
    {
        int[] rowsAndColumns = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int rows = rowsAndColumns[0];
        int columns = rowsAndColumns[1];

        var matrix = new int[rows][];

        int count = 1;

        for (int i = 0; i < rows; i++)
        {
            matrix[i] = new int[columns];

            for (int j = 0; j < matrix[0].Length; j++)
            {
                matrix[i][j] = count;
                count++;
            }
        }

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string[] commands = Console.ReadLine().Split();

            int index = int.Parse(commands[0]);
            string direction = commands[1];
            int moves = int.Parse(commands[2]);

            if (direction == "up")
            {
                MoveColumn(matrix, index, moves);
            }

            else if (direction == "down")
            {
                MoveColumn(matrix, index, columns - moves % columns);
            }

            else if (direction == "left")
            {
                MoveRow(matrix, index, moves);
            }

            else if (direction == "right")
            {
                MoveRow(matrix, index, rows - moves % rows);
            }
        }

        int element = 1;

        for (int row = 0; row < matrix.Length; row++)
        {
            for (int col = 0; col < matrix[0].Length; col++)
            {
                if (matrix[row][col] == element)
                {
                    Console.WriteLine("No swap required");
                }

                else
                {
                    for (int r = 0; r < matrix.Length; r++)
                    {
                        for (int c = 0; c < matrix[0].Length; c++)
                        {
                            if (matrix[r][c] == element)
                            {
                                int currentElement = matrix[row][col];
                                matrix[row][col] = element;
                                matrix[r][c] = currentElement;

                                Console.WriteLine($"Swap ({row}, {col}) with ({r}, {c})");
                                break;
                            }
                        }
                    }
                }

                element++;
            }
        }
    }

    private static void MoveRow(int[][] matrix, int index, int moves)
    {
        int[] tempArray = new int[matrix[0].Length];

        for (int col = 0; col < matrix[0].Length; col++)
        {
            tempArray[col] = matrix[index][(col + moves) % matrix[0].Length];
        }

        matrix[index] = tempArray;
    }

    private static void MoveColumn(int[][] matrix, int index, int moves)
    {
        int[] tempArray = new int[matrix.Length];

        for (int row = 0; row < matrix.Length; row++)
        {
            tempArray[row] = matrix[(row + moves) % matrix.Length][index];
        }

        for (int row = 0; row < matrix.Length; row++)
        {
            matrix[row][index] = tempArray[row];
        }
    }
}

