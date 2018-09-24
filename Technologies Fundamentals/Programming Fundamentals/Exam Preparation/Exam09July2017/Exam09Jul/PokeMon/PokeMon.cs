using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class PokeMon
{
    static void Main()
    {
        long power = long.Parse(Console.ReadLine());
        long distance = long.Parse(Console.ReadLine());
        long exhaustionFactor = long.Parse(Console.ReadLine());
        long count = 0;
        long initialPower = power;

        while (initialPower >= distance)
        {
            initialPower -= distance;

            if (power * 0.5 == initialPower)
            {
                if (initialPower >= exhaustionFactor && exhaustionFactor != 0)
                {
                    initialPower /= exhaustionFactor;
                }
            }
            count++;
        }

        Console.WriteLine(initialPower);
        Console.WriteLine(count);
    }
}

