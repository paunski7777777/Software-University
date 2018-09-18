using System;

class RhombusofStars
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 1; i <= n; i++)
        {
            PrintRow(n, i);
        }

        for (int i = n - 1; i > 0; i--)
        {
            PrintRow(n, i);
        }
    }

    static void PrintRow(int size, int row)
    {
        for (int i = 0; i < size - row; i++)
        {
            Console.Write(" ");
        }
        for (int i = 0; i < row; i++)
        {
            Console.Write("* ");
        }
        Console.WriteLine();
    }
}

