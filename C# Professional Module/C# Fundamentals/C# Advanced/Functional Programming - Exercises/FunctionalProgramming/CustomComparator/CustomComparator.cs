using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class CustomComparator
{
    static void Main()
    {
        var numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

        var even = numbers.FindAll(delegate (int n)
        {
            return n % 2 == 0;
        });
        even.Sort();

        var odd = numbers.FindAll(delegate (int n)
        {
            return n % 2 != 0;
        });
        odd.Sort();

        var filtered = even.Concat(odd);
        Console.WriteLine(string.Join(" ", filtered));
    }
}

