using System;
using System.Linq;

class DangerousFloor
{
    static char[][] board;
    static void Main()
    {
        board = new char[8][];

        for (int row = 0; row < board.Length; row++)
        {
            board[row] = Console.ReadLine().Split(',').Select(char.Parse).ToArray();
        }

        string input;
        while ((input = Console.ReadLine()) != "END")
        {
            char figure = input[0];
            int startRow = int.Parse(input[1].ToString());
            int startCol = int.Parse(input[2].ToString());
            int targetRow = int.Parse(input[4].ToString());
            int targetCol = int.Parse(input[5].ToString());
            

            if (!FigureExist(figure, startRow, startCol))
            {
                Console.WriteLine("There is no such a piece!");
                continue;
            }

            if (!IsMoveValid(figure, startRow, startCol, targetRow, targetCol))
            {
                Console.WriteLine("Invalid move!");
                continue;
            }

            if (!OutOfBoard(targetRow, targetCol))
            {
                Console.WriteLine("Move go out of board!");
                continue;
            }

            board[targetRow][targetCol] = figure;
            board[startRow][startCol] = 'x';
        }
    }


    private static bool OutOfBoard(int targetRow, int targetCol)
    {
        bool validRow = targetRow >= 0 && targetRow <= 7;
        bool validCol = targetCol >= 0 && targetCol <= 7;

        return validRow && validCol;
    }

    private static bool IsMoveValid(char figure, int startRow, int startCol, int targetRow, int targetCol)
    {
        switch (figure)
        {
            case 'P':
                return ValidPawnMove(startRow, startCol, targetRow, targetCol);
            case 'R':
                return ValidRookMove(startRow, startCol, targetRow, targetCol);
            case 'B':
                return ValidBishopMove(startRow, startCol, targetRow, targetCol);
            case 'Q':
                return ValidRookMove(startRow, startCol, targetRow, targetCol) || ValidBishopMove(startRow, startCol, targetRow, targetCol);
            case 'K':
                return ValidKingMove(startRow, startCol, targetRow, targetCol);
            default:
                throw new Exception();
        }
    }

    private static bool ValidKingMove(int startRow, int startCol, int targetRow, int targetCol)
    {
        bool rowMove = Math.Abs(startRow - targetRow) == 1 && Math.Abs(startCol - targetCol) == 0;
        bool columnMove = Math.Abs(startCol - targetCol) == 1 && Math.Abs(startRow - targetRow) == 0;
        bool diagonalMove = Math.Abs(startCol - targetCol) == 1 && Math.Abs(startRow - targetRow) == 1;

        return rowMove || columnMove || diagonalMove;
    }

    private static bool ValidBishopMove(int startRow, int startCol, int targetRow, int targetCol)
    {
        return Math.Abs(startRow - targetRow) == Math.Abs(startCol - targetCol);
    }

    private static bool ValidRookMove(int startRow, int startCol, int targetRow, int targetCol)
    {
        bool sameRow = startRow == targetRow;
        bool sameCol = startCol == targetCol;

        return sameRow || sameCol;
    }

    private static bool ValidPawnMove(int startRow, int startCol, int targetRow, int targetCol)
    {
        bool validCol = startCol == targetCol;
        bool validRow = startRow - 1 == targetRow;

        return validCol && validRow;
    }

    private static bool FigureExist(char figure, int startRow, int startCol)
    {
        return board[startRow][startCol] == figure;
    }
}

