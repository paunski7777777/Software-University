namespace _03BackIn30Minutes
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());

            if (hours <= 23 && minutes < 30)
            {
                Console.WriteLine($"{hours}:{minutes + 30:00}");
            }
            else if (hours < 23 && minutes >= 30)
            {
                Console.WriteLine($"{hours + 1}:{(minutes + 30) - 60:00}");
            }
            else if (hours == 23 && minutes >= 30)
            {
                Console.WriteLine($"{(hours + 1) - 24}:{(minutes + 30) - 60:00}");
            }
        }
    }
}