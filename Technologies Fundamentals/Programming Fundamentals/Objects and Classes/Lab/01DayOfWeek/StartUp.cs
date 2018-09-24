namespace _01DayOfWeek
{
    using System;
    using System.Globalization;

    public class StartUp
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            DateTime date = DateTime.ParseExact(input, "d-M-yyyy", CultureInfo.InvariantCulture);

            Console.WriteLine(date.DayOfWeek);
        }
    }
}