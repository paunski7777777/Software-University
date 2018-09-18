using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class AddVAT
{
    static void Main()
    {
        var numbers = Console.ReadLine()
            .Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
            .Select(double.Parse)
            .Select(x => x * 1.2)
            .ToList();

        foreach (var n in numbers)
        {
            Console.WriteLine($"{n:f2}");
        }
    }
}

