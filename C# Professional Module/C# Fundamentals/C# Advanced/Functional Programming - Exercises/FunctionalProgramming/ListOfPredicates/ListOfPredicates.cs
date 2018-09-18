using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class ListOfPredicates
{
    static void Main()
    {
        int end = int.Parse(Console.ReadLine());
        var numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

        var predicates = numbers.Select(divide => (Func<int, bool>)(x => x % divide == 0)).ToList();
        var result = new List<int>();

        for (int i = 1; i <= end; i++)
        {
            if (IsValid(i, predicates))
            {
                result.Add(i);
            }
        }

        Console.WriteLine(string.Join(" ", result));
    }

    private static bool IsValid(int number, List<Func<int, bool>> predicates)
    {
        foreach (var p in predicates)
        {
            if (!p(number))
            {
                return false;
            }
        }

        return true;
    }
}

