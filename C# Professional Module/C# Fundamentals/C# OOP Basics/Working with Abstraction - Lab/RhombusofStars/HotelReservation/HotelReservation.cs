using System;

class HotelReservation
{
    static void Main()
    {
        string input = Console.ReadLine();
        PriceCalculator priceCalculator = new PriceCalculator(input);
        var total = priceCalculator.CalculatePrice();
        Console.WriteLine(total);
    }
}
