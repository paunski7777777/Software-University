using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class TriFunction
{
    static void Main()
    {
        int sum = int.Parse(Console.ReadLine());
        var names = Console.ReadLine().Split().ToList();

        var filter = CreateFilter(sum);

        Console.WriteLine(names.FirstOrDefault(filter));
    }

    static Func<string, bool> CreateFilter (int sum)
    {
        return name => name.ToCharArray().Sum(c => c) >= sum;
    }
}

