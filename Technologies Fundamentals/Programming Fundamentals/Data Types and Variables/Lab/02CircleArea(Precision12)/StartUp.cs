namespace _02CircleArea_Precision12_
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            double r = double.Parse(Console.ReadLine());

            double sum = Math.PI * r * r;

            Console.WriteLine($"{sum:f12}");
        }
    }
}