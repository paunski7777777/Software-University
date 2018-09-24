namespace _05PizzaIngredients
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            string[] ingredients = Console.ReadLine().Split().ToArray();
            int n = int.Parse(Console.ReadLine());

            int count = 0;
            var newIngredients = new List<string>();

            for (int i = 0; i < ingredients.Length; i++)
            {
                if (ingredients[i].Length == n)
                {
                    Console.WriteLine($"Adding {ingredients[i]}.");

                    newIngredients.Add(ingredients[i]);

                    count++;
                }
                if (count >= 10)
                {
                    break;
                }
            }
            Console.WriteLine($"Made pizza with total of {count} ingredients.");
            Console.WriteLine($"The ingredients are: {string.Join(", ", newIngredients)}.");
        }
    }
}