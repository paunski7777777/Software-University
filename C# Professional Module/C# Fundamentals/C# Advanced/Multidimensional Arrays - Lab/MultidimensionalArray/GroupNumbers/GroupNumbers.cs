using System;
using System.Linq;

class GroupNumbers
{
    static void Main()
    {
        int[] numbers = Console.ReadLine().Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        int[] sizes = new int[3];
        int[][] jaggedArray = new int[3][];
        int[] indexes = new int[3];

        foreach (var n in numbers)
        {
            sizes[Math.Abs(n % 3)]++;
        }

        for (int i = 0; i < sizes.Length; i++)
        {
            jaggedArray[i] = new int[sizes[i]];
        }

        foreach (var n in numbers)
        {
            var remainder = Math.Abs(n % 3);
            jaggedArray[remainder][indexes[remainder]] = n;
            indexes[remainder]++;
        }

        for (int i = 0; i < jaggedArray.Length; i++)
        {
            for (int j = 0; j < jaggedArray[i].Length; j++)
            {
                Console.Write(jaggedArray[i][j] + " ");
            }
            Console.WriteLine();
        }
    }
}

