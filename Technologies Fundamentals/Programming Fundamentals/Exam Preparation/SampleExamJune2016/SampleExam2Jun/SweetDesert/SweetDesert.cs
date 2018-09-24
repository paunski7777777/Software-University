using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class SweetDesert
{
    static void Main()
    {
        decimal cash = decimal.Parse(Console.ReadLine());
        long guests = long.Parse(Console.ReadLine());
        decimal bananaPrice = decimal.Parse(Console.ReadLine());
        decimal eggPrice = decimal.Parse(Console.ReadLine());
        decimal berriesPrice = decimal.Parse(Console.ReadLine());

        int portion = (int)Math.Ceiling(guests / 6.0);

        decimal price = (2 * bananaPrice) + (4 * eggPrice) + (0.2M * berriesPrice);
        decimal neededCash = price * portion;

        if (neededCash <= cash)
        {
            Console.WriteLine($"Ivancho has enough money - it would cost {neededCash:f2}lv.");
        }
        else
        {
            Console.WriteLine($"Ivancho will have to withdraw money - he will need {(neededCash - cash):f2}lv more.");
        }

    }
}

