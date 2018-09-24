using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class SinoTheWalker
{
    static void Main()
    {
        DateTime time = DateTime.ParseExact(Console.ReadLine(), "HH:mm:ss", CultureInfo.InvariantCulture);
        long steps = long.Parse(Console.ReadLine()) % 86400;
        long seconds = long.Parse(Console.ReadLine()) % 86400;

        long arrival = steps * seconds;

        Console.WriteLine($"Time Arrival: {time.AddSeconds(arrival).ToString("HH:mm:ss")}");
    }
}

