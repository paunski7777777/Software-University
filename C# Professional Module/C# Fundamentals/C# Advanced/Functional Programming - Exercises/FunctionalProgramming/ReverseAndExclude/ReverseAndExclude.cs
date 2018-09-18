using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class ReverseAndExclude
{
    static void Main()
    {
        var numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
        int n = int.Parse(Console.ReadLine());

        Func<int, bool> divide = x => x % n != 0;

        var filtered = numbers.Where(divide).Reverse().ToList();
        Console.WriteLine(string.Join(" ", filtered));
    }
}

