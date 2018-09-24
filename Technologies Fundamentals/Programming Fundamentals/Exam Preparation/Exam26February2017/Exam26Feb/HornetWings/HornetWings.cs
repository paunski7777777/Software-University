using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class HornetWings
{
    static void Main()
    {
        int flaps = int.Parse(Console.ReadLine());
        decimal distance = decimal.Parse(Console.ReadLine());
        int endurance = int.Parse(Console.ReadLine());

        decimal totalDistance = (flaps / 1000) * distance;
        decimal seconds = flaps / 100;
        decimal totalSeconds = (flaps / endurance) * 5 + seconds;

        Console.WriteLine($"{totalDistance:f2} m.");
        Console.WriteLine($"{totalSeconds} s.");
    }
}

