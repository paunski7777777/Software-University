namespace _04Hotel
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            string month = Console.ReadLine();
            int nights = int.Parse(Console.ReadLine());

            if (month == "May" || month == "October")
            {
                double studio = 50;
                double doubleroom = 65;
                double suite = 75;
                if (nights > 7)
                {
                    studio = 50 - (50 * 0.05);
                    if (month == "October")
                    {
                        studio = (studio / nights) * (nights - 1);
                    }
                }

                Console.WriteLine($"Studio: {(studio * nights):f2} lv.");
                Console.WriteLine($"Double: {(doubleroom * nights):f2} lv.");
                Console.WriteLine($"Suite: {(suite * nights):f2} lv.");
            }

            else if (month == "June" || month == "September")
            {
                double studio = 60;
                double doubleroom = 72;
                double suite = 82;
                if (nights > 14)
                {
                    suite = 82 - (82 * 0.10);
                }
                if (nights > 7 && month == "September")
                {
                    studio = (studio / nights) * (nights - 1);
                }

                Console.WriteLine($"Studio: {(studio * nights):f2} lv.");
                Console.WriteLine($"Double: {(doubleroom * nights):f2} lv.");
                Console.WriteLine($"Suite: {(suite * nights):f2} lv.");
            }

            else if (month == "July" || month == "August" || month == "December")
            {
                double studio = 68;
                double doubleroom = 77;
                double suite = 89;
                if (nights > 14)
                {
                    suite = 89 - (89 * 0.15);
                }

                Console.WriteLine($"Studio: {(studio * nights):f2} lv.");
                Console.WriteLine($"Double: {(doubleroom * nights):f2} lv.");
                Console.WriteLine($"Suite: {(suite * nights):f2} lv.");
            }
        }
    }
}