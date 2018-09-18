using System;
using System.Linq;

class LegoBlocks
{
    static long totalCells = 0;
    static void Main()
    {
        int rows = int.Parse(Console.ReadLine());

        var firstJagged = FillJaggedArray(rows);
        var secondJagged = FillJaggedArray(rows);

        ReverseSecondJagged(secondJagged);

        var rectangle = new int[rows][];
        FitArray(rows, firstJagged, secondJagged, rectangle);

        bool isFit = MatchedArrays(rectangle);

        PrintArrays(rows, firstJagged, secondJagged, isFit);
    }

    private static void PrintArrays(int rows, int[][] firstJagged, int[][] secondJagged, bool isFit)
    {
        if (isFit)
        {
            for (int row = 0; row < rows; row++)
            {
                Console.WriteLine($"[{string.Join(", ", firstJagged[row].Concat(secondJagged[row]))}]");
            }
        }
        else
        {
            Console.WriteLine($"The total number of cells is: {totalCells}");
        }
    }

    private static bool MatchedArrays(int[][] rectangle)
    {
        bool isFit = true;

        for (int row = 0; row < rectangle.Length - 1; row++)
        {
            if (rectangle[row].Length != rectangle[row + 1].Length)
            {
                isFit = false;
                break;
            }
        }

        return isFit;
    }

    private static void FitArray(int rows, int[][] firstJagged, int[][] secondJagged, int[][] rectangle)
    {
        for (int i = 0; i < rows; i++)
        {
            rectangle[i] = firstJagged[i].Concat(secondJagged[i]).ToArray();
        }
    }

    private static void ReverseSecondJagged(int[][] secondJagged)
    {
        for (int i = 0; i < secondJagged.Length; i++)
        {
            Array.Reverse(secondJagged[i]);
        }
    }

    private static int[][] FillJaggedArray(int rows)
    {
        var jaggedArray = new int[rows][];

        for (int i = 0; i < jaggedArray.Length; i++)
        {
            jaggedArray[i] = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            totalCells += jaggedArray[i].Length;
        }

        return jaggedArray;
    }
}

