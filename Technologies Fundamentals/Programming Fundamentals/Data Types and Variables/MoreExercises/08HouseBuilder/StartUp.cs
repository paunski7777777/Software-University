namespace _08HouseBuilder
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            long price1 = long.Parse(Console.ReadLine());
            long price2 = long.Parse(Console.ReadLine());

            Console.WriteLine(Math.Max(price1, price2) * 10 + Math.Min(price1, price2) * 4);
        }
    }
}