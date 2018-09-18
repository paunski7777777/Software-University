using System;
class PascalTriangle
{
    static void Main()
    {
        int height = int.Parse(Console.ReadLine());

        long[][] pascalTriangle = new long[height][];

        for (int i = 0; i < height; i++)
        {
            pascalTriangle[i] = new long[i + 1];
            pascalTriangle[i][0] = 1;
            pascalTriangle[i][i] = 1;

            if (i >= 2)
            {
                for (int j = 1; j < i; j++)
                {
                    pascalTriangle[i][j] = pascalTriangle[i - 1][j - 1] + pascalTriangle[i - 1][j];
                }
            }
        }

        for (int i = 0; i < pascalTriangle.Length; i++)
        {
            for (int j = 0; j < pascalTriangle[i].Length; j++)
            {
                Console.Write(pascalTriangle[i][j] + " ");
            }
            Console.WriteLine();
        }
    }
}

