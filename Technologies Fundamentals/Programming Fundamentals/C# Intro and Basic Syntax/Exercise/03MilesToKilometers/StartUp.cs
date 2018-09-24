namespace _03MilesToKilometers
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            double miles = double.Parse(Console.ReadLine());

            Console.WriteLine($"{(miles * 1.60934):f2}");
        }
    }
}