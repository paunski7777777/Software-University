namespace _01CountWorkingDays
{
    using System;
    using System.Globalization;

    public class StartUp
    {
        public static void Main()
        {
            string dateFormat = "dd-MM-yyyy";

            DateTime startDate = DateTime.ParseExact(Console.ReadLine(), dateFormat, CultureInfo.InvariantCulture);
            DateTime endDate = DateTime.ParseExact(Console.ReadLine(), dateFormat, CultureInfo.InvariantCulture);

            DateTime[] holidays =
            {
                DateTime.ParseExact("01-01-1970", dateFormat, CultureInfo.InvariantCulture),
                DateTime.ParseExact("03-03-1970", dateFormat, CultureInfo.InvariantCulture),
                DateTime.ParseExact("01-05-1970", dateFormat, CultureInfo.InvariantCulture),
                DateTime.ParseExact("06-05-1970", dateFormat, CultureInfo.InvariantCulture),
                DateTime.ParseExact("24-05-1970", dateFormat, CultureInfo.InvariantCulture),
                DateTime.ParseExact("06-09-1970", dateFormat, CultureInfo.InvariantCulture),
                DateTime.ParseExact("22-09-1970", dateFormat, CultureInfo.InvariantCulture),
                DateTime.ParseExact("01-11-1970", dateFormat, CultureInfo.InvariantCulture),
                DateTime.ParseExact("24-12-1970", dateFormat, CultureInfo.InvariantCulture),
                DateTime.ParseExact("25-12-1970", dateFormat, CultureInfo.InvariantCulture),
                DateTime.ParseExact("26-12-1970", dateFormat, CultureInfo.InvariantCulture)
            };

            int count = 0;

            for (DateTime currentDate = startDate; currentDate <= endDate; currentDate = currentDate.AddDays(1))
            {
                if (currentDate.DayOfWeek != DayOfWeek.Saturday && currentDate.DayOfWeek != DayOfWeek.Sunday)
                {
                    bool isHoliday = true;

                    foreach (var day in holidays)
                    {
                        if (day.Day == currentDate.Day && day.Month == currentDate.Month)
                        {
                            isHoliday = false;
                            break;
                        }
                    }

                    if (isHoliday)
                    {
                        count++;
                    }
                }
            }

            Console.WriteLine(count);
        }
    }
}