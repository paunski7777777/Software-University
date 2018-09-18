using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class PredicateForNames
{
    static void Main()
    {
        int length = int.Parse(Console.ReadLine());
        var names = Console.ReadLine().Split().Where(x => x.Length <= length).ToList();
        Console.WriteLine(string.Join(Environment.NewLine, names));
    }
}

