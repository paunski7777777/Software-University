namespace _03WaterOverflow
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int tank = 255;
            int total = 0;

            for (int i = 0; i < n; i++)
            {
                int liters = int.Parse(Console.ReadLine());

                total += liters;

                if (total > tank)
                {
                    total -= liters;

                    Console.WriteLine("Insufficient capacity!");
                }
            }

            Console.WriteLine(total);
        }
    }
}