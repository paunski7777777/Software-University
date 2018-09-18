using System;
using System.Linq;

class KnightGame
{
    static void Main()
    {
        int dimension = int.Parse(Console.ReadLine());
        char[][] board = new char[dimension][];

        for (int row = 0; row < dimension; row++)
        {
            board[row] = Console.ReadLine().ToCharArray();
        }

        int maxRows = 0;
        int maxColumns = 0;
        int maxAttackedPositions = 0;
        int countOfRemovedKnights = 0;

        do
        {
            if (maxAttackedPositions > 0)
            {
                board[maxRows][maxColumns] = '0';
                maxAttackedPositions = 0;
                countOfRemovedKnights++;
            }

            int currentAttackPosition = 0;

            for (int row = 0; row < dimension; row++)
            {
                for (int col = 0; col < dimension; col++)
                {
                    if (board[row][col] == 'K')
                    {
                        currentAttackPosition = CalculateAttackedPositions(row, col, board);

                        if (currentAttackPosition > maxAttackedPositions)
                        {
                            maxAttackedPositions = currentAttackPosition;
                            maxRows = row;
                            maxColumns = col;
                        }
                    }
                }
            }
        }
        while (maxAttackedPositions > 0);

        Console.WriteLine(countOfRemovedKnights);
    }

    static int CalculateAttackedPositions(int row, int column, char[][] board)
    {
        int currentPos = 0;

        if (IsPositionAttacked(row - 2, column - 1, board))
            currentPos++;

        if (IsPositionAttacked(row - 2, column + 1, board))
            currentPos++;

        if (IsPositionAttacked(row - 1, column - 2, board))
            currentPos++;

        if (IsPositionAttacked(row - 1, column + 2, board))
            currentPos++;

        if (IsPositionAttacked(row + 1, column - 2, board))
            currentPos++;

        if (IsPositionAttacked(row + 1, column + 2, board))
            currentPos++;

        if (IsPositionAttacked(row + 2, column - 1, board))
            currentPos++;

        if (IsPositionAttacked(row + 2, column + 1, board))
            currentPos++;

        return currentPos;
    }

    static bool IsPositionWithinBoard(int row, int column, int size)
    {
        return row >= 0 && row < size && column >= 0 && column < size;
    }

    static bool IsPositionAttacked(int row, int column, char[][] board)
    {
        return IsPositionWithinBoard(row, column, board[0].Length) && board[row][column] == 'K';
    }
}