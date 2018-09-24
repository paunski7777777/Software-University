using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Numbers
{
    static void Main()
    {
        var list = Console.ReadLine().Split().Select(int.Parse).ToList();
        double average = list.Average();
        bool isBigger = false;

        foreach (var n in list)
        {
            if (n > average)
            {
                isBigger = true;
            }
        }
        if (isBigger)
        {
            Console.WriteLine(string.Join(" ", list.OrderByDescending(x => x).Where(x => x > average).Take(5)));
        }
        else
        {
            Console.WriteLine("No");
        }
    }
}

