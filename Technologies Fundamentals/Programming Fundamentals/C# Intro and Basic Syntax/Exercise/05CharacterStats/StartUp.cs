namespace _05CharacterStats
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            string name = Console.ReadLine();
            int health = int.Parse(Console.ReadLine());
            int maxHealth = int.Parse(Console.ReadLine());
            int energy = int.Parse(Console.ReadLine());
            int maxEnergy = int.Parse(Console.ReadLine());

            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Health: |{new string('|', health)}{new string('.', maxHealth - health)}|");
            Console.WriteLine($"Energy: |{new string('|', energy)}{new string('.', maxEnergy - energy)}|");
        }
    }
}