using System;
using System.Linq;

class RadioactiveBunnies
{
    static char[,] board;
    static int playerRow;
    static int playerColumn;
    static int rows;
    static int columns;
    static void Main()
    {
        int[] dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();

        board = ReadAndFillMatrix(dimensions);

        char[] movements = Console.ReadLine().ToCharArray();

        foreach (var move in movements)
        {
            int[] lastPosition = MovePlayer(move);
            MoveBunnies();

            if (IsPlayerOnBoard())
            {
                if (board[playerRow, playerColumn] == 'B')
                {
                    PlayerDies();
                }

                continue;
            }

            PlayerWins(lastPosition);
        }
    }

    private static void PlayerDies()
    {
        PrintMatrix();

        Console.WriteLine($"dead: {playerRow} {playerColumn}");

        Environment.Exit(0);
    }

    private static void PlayerWins(int[] lastPosition)
    {
        PrintMatrix();

        int row = lastPosition[0];
        int column = lastPosition[1];

        Console.WriteLine($"won: {row} {column}");

        Environment.Exit(0);
    }

    private static bool IsPlayerOnBoard()
    {
        bool validRow = playerRow >= 0 && playerRow < rows;
        bool validColumn = playerColumn >= 0 && playerColumn < columns;

        if (validRow && validColumn)
        {
            return true;
        }

        return false;
    }

    private static void PrintMatrix()
    {
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                Console.Write(board[row, col]);
            }
            Console.WriteLine();
        }
    }

    private static void MoveBunnies()
    {
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                if (board[row, col] == 'B')
                {
                    if (row > 0)
                    {
                        NewBunny(row - 1, col);
                    }

                    if (row < rows - 1)
                    {
                        NewBunny(row + 1, col);
                    }

                    if (col > 0)
                    {
                        NewBunny(row, col - 1);
                    }

                    if (col < columns - 1)
                    {
                        NewBunny(row, col + 1);
                    }
                }
            }
        }

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                if (board[row, col] == 'X')
                {
                    board[row, col] = 'B';
                }
            }
        }
    }

    private static void NewBunny(int row, int col)
    {
        if (board[row, col] != 'B')
        {
            board[row, col] = 'X';
        }
    }

    private static int[] MovePlayer(char move)
    {
        int[] lastPosition = { playerRow, playerColumn};

        switch (move)
        {
            case 'U':
                playerRow--;
                break;
            case 'D':
                playerRow++;
                break;
            case 'L':
                playerColumn--;
                break;
            case 'R':
                playerColumn++;
                break;
        }

        if (IsPlayerOnBoard() && board[playerRow, playerColumn] != 'B')
        {
            board[playerRow, playerColumn] = 'P';
        }

        int oldRow = lastPosition[0];
        int oldColumn = lastPosition[1];

        board[oldRow, oldColumn] = '.';

        return lastPosition;
    }

    private static char[,] ReadAndFillMatrix(int[] dimensions)
    {
        rows = dimensions[0];
        columns = dimensions[1];

        char[,] matrix = new char[rows, columns];

        for (int row = 0; row < rows; row++)
        {
            char[] rowValue = Console.ReadLine().ToCharArray();

            for (int col = 0; col < columns; col++)
            {
                matrix[row, col] = rowValue[col];

                if (rowValue[col] == 'P')
                {
                    playerRow = row;
                    playerColumn = col;
                }
            }
        }

        return matrix;
    }
}
