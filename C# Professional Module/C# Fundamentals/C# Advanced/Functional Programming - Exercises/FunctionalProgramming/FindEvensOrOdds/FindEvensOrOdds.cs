using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class FindEvensOrOdds
{
    static void Main()
    {
        var numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
        string type = Console.ReadLine();

        int start = numbers[0];
        int end = numbers[1];

        var even = new List<int>();
        var odd = new List<int>();

        for (int i = start; i <= end; i++)
        {
            if (IsEven(i, x => x % 2 == 0))
            {
                even.Add(i);
            }
            else
            {
                odd.Add(i);
            }
        }

        string result = type == "even" ? string.Join(" ", even) : string.Join(" ", odd);

        Console.WriteLine(result);
    }

    public static bool IsEven(int number, Func<int, bool> condition)
    {
        return condition(number);
    }
}

