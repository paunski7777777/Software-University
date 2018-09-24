using System;
using System.Collections.Generic;
using System.Linq;

public class KaminoFactory
{
    public static void Main()
    {
        int DNAlength = int.Parse(Console.ReadLine());

        int[] bestDNA = null;
        int bestSequenceIndex = 0;
        int bestSequenceSum = 0;

        string input;
        while ((input = Console.ReadLine()) != "Clone them!")
        {
            var DNAsequence = input.Split('!').Select(int.Parse).ToList();
            
        }

        Console.WriteLine($"Best DNA sample {bestSequenceIndex} with sum: {bestSequenceSum}.");
        Console.WriteLine(string.Join(" ", bestDNA));
    }
}

