using System;
using System.Linq;

public class GenericSwapMethodInteger
{
    public static void Main()
    {
        var boxOfStrings = new GenericBox<int>();

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            int input = int.Parse(Console.ReadLine());

            boxOfStrings.Add(input);
        }

        int[] indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int firstIndex = indexes[0];
        int secondIndex = indexes[1];

        boxOfStrings.Swap(firstIndex, secondIndex);

        Console.WriteLine(boxOfStrings);
    }
}

