using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class CharityMarathon
{
    static void Main()
    {
        int days = int.Parse(Console.ReadLine());
        long runners = long.Parse(Console.ReadLine());
        int laps = int.Parse(Console.ReadLine());
        long length = long.Parse(Console.ReadLine());
        long capacity = long.Parse(Console.ReadLine());
        decimal money = decimal.Parse(Console.ReadLine());

        var maxRunners = capacity * days;

        if (maxRunners >= runners)
        {
            var currentRunners = runners;
            var totalMeters = currentRunners * laps * length;
            var totalKilometers = totalMeters / 1000;
            var moneyRaised = totalKilometers * money;
            Console.WriteLine($"Money raised: {moneyRaised:f2}");
        }
        else
        {
            var currentRunners = maxRunners;
            var totalMeters = currentRunners * laps * length;
            var totalKilometers = totalMeters / 1000;
            var moneyRaised = totalKilometers * money;
            Console.WriteLine($"Money raised: {moneyRaised:f2}");
        }
    }
}

