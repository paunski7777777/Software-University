using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class KnightsOfHonor
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        Action<string[]> printer = Print;
        printer(input);
    }

    public static void Print(string[] input)
    {
        foreach (var i in input)
        {
            Console.WriteLine("Sir " + i);
        }
    }
}

