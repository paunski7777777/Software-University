using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class SumNumbers
{
    static void Main()
    {
        var numbers = Console.ReadLine()
            .Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList();
        var count = numbers.Count();
        var sum = numbers.Sum();
        Console.WriteLine(count);
        Console.WriteLine(sum);
    }
}

