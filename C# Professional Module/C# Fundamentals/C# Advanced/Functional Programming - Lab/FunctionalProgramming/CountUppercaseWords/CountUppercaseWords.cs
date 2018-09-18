using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class CountUppercaseWords
{
    static void Main()
    {
        var input = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        Func<string, bool> isUppercase = x => x[0] == x.ToUpper()[0];
        input.Where(isUppercase).ToList().ForEach(x => Console.WriteLine(x));
    }
}

