using System;
public class RageExpenses
{
    public static void Main()
    {
        int lostGamesCount = int.Parse(Console.ReadLine());
        decimal headsetPrice = decimal.Parse(Console.ReadLine());
        decimal mousePrice = decimal.Parse(Console.ReadLine());
        decimal keyboardPrice = decimal.Parse(Console.ReadLine());
        decimal displayPrice = decimal.Parse(Console.ReadLine());

        decimal expenses = 0;
        int keyboardCrash = 0;

        for (int i = 1; i <= lostGamesCount; i++)
        {
            if (i % 2 == 0)
            {
                expenses += headsetPrice;
            }
            if (i % 3 == 0)
            {
                expenses += mousePrice;
            }
            if (i % 2 == 0 && i % 3 == 0 && i > 0)
            {
                expenses += keyboardPrice;
                keyboardCrash++;
            }
            if (keyboardCrash % 2 == 0 &&  keyboardCrash > 0 && i > 0)
            {
                expenses += displayPrice;
                keyboardCrash = 0;
            }
        }

        Console.WriteLine($"Rage expenses: {expenses:f2} lv.");
    }
}
