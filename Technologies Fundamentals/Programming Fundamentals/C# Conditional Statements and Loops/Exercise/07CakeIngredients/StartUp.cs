namespace _07CakeIngredients
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            int count = 0;

            for (int i = 0; i <= 20; i++)
            {
                string ingredients = Console.ReadLine();

                count++;

                if (ingredients == "Bake!")
                {
                    count--;

                    Console.WriteLine($"Preparing cake with {count} ingredients.");
                    break;
                }

                Console.WriteLine($"Adding ingredient {ingredients}.");
            }
        }
    }
}