using System;
using System.Linq;

class FillingJaggedArray
{
    static void Main()
    {
        int[][] jaggedArray = ReadJaggedArray();

        PrintJaggedArray(jaggedArray);
    }

    private static void PrintJaggedArray(int[][] jaggedArray)
    {
        for (int i = 0; i < jaggedArray.Length; i++)
        {
            for (int j = 0; j < jaggedArray[i].Length; j++)
            {
                Console.Write(jaggedArray[i][j] + " ");
            }
            Console.WriteLine();
        }
    }

    private static int[][] ReadJaggedArray()
    {
        int n = int.Parse(Console.ReadLine());

        int[][] jaggedArray = new int[n][];

        for (int i = 0; i < jaggedArray.Length; i++)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            jaggedArray[i] = new int[numbers.Length];

            for (int j = 0; j < jaggedArray[i].Length; j++)
            {
                jaggedArray[i][j] = numbers[j];
            }
        }

        return jaggedArray;
    }
}

