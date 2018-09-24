using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class HornetAssault
{
    static void Main()
    {
        var bees = Console.ReadLine().Split().Select(long.Parse).ToList();
        var hornets = Console.ReadLine().Split().Select(long.Parse).ToList();

        long power = hornets.Sum();

        for (int i = 0; i < bees.Count; i++)
        {
            if (hornets.Count() == 0)
            {
                break;
            }
            if (bees[i] < power)
            {
                bees[i] = 0;
            }
            else
            {
                bees[i] -= power;
                power -= hornets[0];
                hornets.RemoveAt(0);
            }
        }

        if (bees.Sum() > 0)
        {
            Console.WriteLine(string.Join(" ", bees.Where(b => b != 0)));
        }
        else
        {
            Console.WriteLine(string.Join(" ", hornets));
        }
    }
}

