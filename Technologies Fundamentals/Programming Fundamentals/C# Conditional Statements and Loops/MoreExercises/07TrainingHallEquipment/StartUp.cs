namespace _07TrainingHallEquipment
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            double budget = double.Parse(Console.ReadLine());
            int items = int.Parse(Console.ReadLine());

            double total = 0;

            for (int i = 0; i < items; i++)
            {
                string name = Console.ReadLine();
                double price = double.Parse(Console.ReadLine());
                int count = int.Parse(Console.ReadLine());

                if (count > 1)
                {
                    total += count * price;

                    Console.WriteLine($"Adding {count} {name}s to cart.");
                }
                else
                {
                    total += price;

                    Console.WriteLine($"Adding {count} {name} to cart.");
                }
            }

            if (budget >= total)
            {
                Console.WriteLine($"Subtotal: ${total:f2}");
                Console.WriteLine($"Money left: ${(budget - total):f2}");
            }
            else
            {
                Console.WriteLine($"Subtotal: ${total:f2}");
                Console.WriteLine($"Not enough. We need ${(total - budget):f2} more.");
            }
        }
    }
}