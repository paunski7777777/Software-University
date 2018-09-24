namespace _05WeatherForecast
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            try
            {
                long number = long.Parse(Console.ReadLine());
                string weather = Console.ReadLine();

                if (number >= -128 && number <= 127)
                {
                    weather = "Sunny";

                    Console.WriteLine(weather);
                }
                else if (number >= -2147483648 && number <= 2147483647)
                {
                    weather = "Cloudy";

                    Console.WriteLine(weather);
                }
                else if (number >= -9223372036854775808 && number <= 9223372036854775807)
                {
                    weather = "Windy";

                    Console.WriteLine(weather);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Rainy");
            }
        }
    }
}