namespace _06TheatrePromotion
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            string day = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            if ((age >= 0 && age <= 18) || (age > 64 && age <= 122))
            {
                if (day == "Weekday")
                {
                    Console.WriteLine("12$");
                }
            }
            else if (age > 18 && age <= 64)
            {
                if (day == "Weekday")
                {
                    Console.WriteLine("18$");
                }
            }

            if ((age >= 0 && age <= 18) || (age > 64 && age <= 122))
            {
                if (day == "Weekend")
                {
                    Console.WriteLine("15$");
                }
            }
            else if (age > 18 && age <= 64)
            {
                if (day == "Weekend")
                {
                    Console.WriteLine("20$");
                }
            }

            if (age >= 0 && age <= 18)
            {
                if (day == "Holiday")
                {
                    Console.WriteLine("5$");
                }
            }
            else if (age > 18 && age <= 64)
            {
                if (day == "Holiday")
                {
                    Console.WriteLine("12$");
                }
            }
            else if (age > 64 && age <= 122)
            {
                if (day == "Holiday")
                {
                    Console.WriteLine("10$");
                }
            }
            else if (age < 0 || age > 122)
            {
                Console.WriteLine("Error!");
            }
        }
    }
}