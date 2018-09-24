using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class SoftuniCoffeeOrders
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        decimal total = 0;

        for (int i = 0; i < n; i++)
        {
            decimal price = ProcessOrder();
            total += price;
        }

        Console.WriteLine($"Total: ${total:f2}");
    }

    static decimal ProcessOrder()
    {
        decimal pricePerCapsule = decimal.Parse(Console.ReadLine());
        DateTime date = DateTime.ParseExact(Console.ReadLine(), "d/M/yyyy", null);
        decimal capsules = decimal.Parse(Console.ReadLine());

        decimal daysInMonth = DateTime.DaysInMonth(date.Year, date.Month);
        decimal price = (daysInMonth * capsules) * pricePerCapsule;

        Console.WriteLine($"The price for the coffee is: ${price:f2}");
        return price;
    }
}

