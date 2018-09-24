using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class EnduranceRally
{
    static void Main()
    {
        var drivers = Console.ReadLine().Split().ToList();
        var zones = Console.ReadLine().Split().Select(double.Parse).ToList();
        var checkpointIndexes = Console.ReadLine().Split().Select(int.Parse).ToList();

        foreach (var d in drivers)
        {
            double fuel = (int)d.First();

            for (int i = 0; i < zones.Count; i++)
            {
                double currentFuel = zones[i];

                if (checkpointIndexes.Contains(i))
                {
                    fuel += currentFuel;
                }
                else
                {
                    fuel -= currentFuel;
                }
                if (fuel <= 0)
                {
                    Console.WriteLine($"{d} - reached {i}");
                    break;
                }
            }
            if (fuel > 0)
            {
                Console.WriteLine($"{d} - fuel left {fuel:f2}");
            }
        }
    }
}

