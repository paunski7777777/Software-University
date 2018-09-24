namespace _05TemperatureConversion
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            double fahrenheit = double.Parse(Console.ReadLine());

            double celsius = FahrenheitToCelcius(fahrenheit);

            Console.WriteLine($"{celsius:f2}");
        }

        private static double FahrenheitToCelcius(double fahrenheit)
        {
            fahrenheit = (fahrenheit - 32) * 5 / 9;

            return fahrenheit;
        }
    }
}