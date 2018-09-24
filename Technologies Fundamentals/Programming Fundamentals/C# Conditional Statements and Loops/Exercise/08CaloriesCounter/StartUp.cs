namespace _08CaloriesCounter
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int cheese = 500;
            int tomatoSauce = 150;
            int salami = 600;
            int pepper = 50;

            int count = 0;

            for (int i = 0; i < n; i++)
            {
                string ingredient = Console.ReadLine().ToLower();

                if (ingredient == "cheese")
                {
                    count += cheese;
                }
                else if (ingredient == "tomato sauce")
                {
                    count += tomatoSauce;
                }
                else if (ingredient == "salami")
                {
                    count += salami;
                }
                else if (ingredient == "pepper")
                {
                    count += pepper;
                }
            }

            Console.WriteLine($"Total calories: {count}");
        }
    }
}