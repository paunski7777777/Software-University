using System;
using System.Collections.Generic;
using System.Text;

class PriceCalculator
{
    private double price;
    private int days;
    private Seasons season;
    private Discounts discount;

    public PriceCalculator(string input)
    {
        var tokens = input.Split();
        price = double.Parse(tokens[0]);
        days = int.Parse(tokens[1]);
        season = Enum.Parse<Seasons>(tokens[2]);

        discount = Discounts.None;

        if (tokens.Length > 3)
        {
            discount = Enum.Parse<Discounts>(tokens[3]);
        }
    }

    public string CalculatePrice()
    {
        var tempTotal = price * days * (int)season;
        var discountPercentage = ((double)100 - (int)discount) / 100;
        var total = tempTotal * discountPercentage;

        return total.ToString("f2");
    }
}

