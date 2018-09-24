using System;
using System.Linq;

namespace P03_JediGalaxy
{
    class Program
    {
        static void Main()
        {
            int[,] matrix = FillMatrix();

            long sum = 0;

            string command;
            while ((command = Console.ReadLine()) != "Let the Force be with you")
            {
                int[] ivoS = command.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int[] evil = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                EvilCommand(matrix, evil);
                sum = IvoCommand(matrix, sum, ivoS);
            }

            Console.WriteLine(sum);
        }

        private static long IvoCommand(int[,] matrix, long sum, int[] ivoS)
        {
            int ivoRow = ivoS[0];
            int ivoCol = ivoS[1];

            while (ivoRow >= 0 && ivoCol < matrix.GetLength(1))
            {
                if (ivoRow >= 0 && ivoRow < matrix.GetLength(0) && ivoCol >= 0 && ivoCol < matrix.GetLength(1))
                {
                    sum += matrix[ivoRow, ivoCol];
                }

                ivoCol++;
                ivoRow--;
            }

            return sum;
        }

        private static void EvilCommand(int[,] matrix, int[] evil)
        {
            int evilRow = evil[0];
            int evilCol = evil[1];

            while (evilRow >= 0 && evilCol >= 0)
            {
                if (evilRow >= 0 && evilRow < matrix.GetLength(0) && evilCol >= 0 && evilCol < matrix.GetLength(1))
                {
                    matrix[evilRow, evilCol] = 0;
                }
                evilRow--;
                evilCol--;
            }
        }

        private static int[,] FillMatrix()
        {
            int[] dimestions = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = dimestions[0];
            int columns = dimestions[1];

            int[,] matrix = new int[rows, columns];

            int value = 0;
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    matrix[row, col] = value++;
                }
            }

            return matrix;
        }
    }
}
