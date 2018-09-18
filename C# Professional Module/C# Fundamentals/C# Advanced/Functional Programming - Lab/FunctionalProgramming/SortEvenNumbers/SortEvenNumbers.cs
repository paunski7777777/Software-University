using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class SortEvenNumbers
{
    static void Main()
    {
        var numbers = Console.ReadLine().Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).Where(x => x % 2 == 0).OrderBy(x => x).ToList();

        Console.WriteLine(string.Join(", ", numbers));
    }
}

