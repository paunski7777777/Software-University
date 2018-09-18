using System;
using System.Linq;

class CubicsRube
{
    static void Main()
    {
        int dimension = int.Parse(Console.ReadLine());

        long sum = 0;
        int count = 0;

        string input;
        while ((input = Console.ReadLine()) != "Analyze")
        {
            int[] tokens = input.Split().Select(int.Parse).ToArray();

            if (tokens.Take(3).Any(x => x < 0 || x >= dimension))
            {
                continue;
            }

            if (tokens[3] != 0)
            {
                sum += tokens[3];
                count++;
            }
        }

        Console.WriteLine(sum);
        Console.WriteLine(Math.Pow(dimension, 3) - count);
    }
}

