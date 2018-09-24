namespace _10HolidaysBetweenTwoDates
{
    using System;
    using System.Globalization;

    public class StartUp
    {
        public static void Main()
        {
            string dateFormat = "d.M.yyyy";

            var startDate = DateTime.ParseExact(Console.ReadLine(), dateFormat, CultureInfo.InvariantCulture);
            var endDate = DateTime.ParseExact(Console.ReadLine(), dateFormat, CultureInfo.InvariantCulture);

            var holidaysCount = 0;

            for (var date = startDate; date <= endDate; date = date.AddDays(1))
            {
                if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                {
                    holidaysCount++;
                }
            }

            Console.WriteLine(holidaysCount);
        }
    }
}