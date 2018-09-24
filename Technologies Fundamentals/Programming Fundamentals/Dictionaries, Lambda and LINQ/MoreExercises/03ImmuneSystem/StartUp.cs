namespace _03ImmuneSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int health = int.Parse(Console.ReadLine());
            int currentHealth = health;

            string virus = Console.ReadLine();

            int virusStrength = 0;
            int timeToDefeat = 0;
            string time = string.Empty;

            List<string> viruses = new List<string>();

            while (virus != "end")
            {
                virusStrength = virus.Sum(v => v);
                virusStrength /= 3;
                timeToDefeat = virusStrength * virus.Length;

                timeToDefeat = viruses.Contains(virus) ? timeToDefeat / 3 : timeToDefeat;

                int seconds = timeToDefeat % 60;
                int minutes = timeToDefeat / 60;
                time = minutes + "m" + " " + seconds + "s";

                currentHealth -= timeToDefeat;

                viruses.Add(virus);

                Console.WriteLine($"Virus {virus}: {virusStrength} => {timeToDefeat} seconds");

                if (currentHealth > 0)
                {
                    Console.WriteLine($"{virus} defeated in {time}.");
                    Console.WriteLine($"Remaining health: {currentHealth}");
                }

                currentHealth = (int)(currentHealth * 1.2) > health ? health : (int)(currentHealth * 1.2);

                if (currentHealth < 0)
                {
                    break;
                }

                virus = Console.ReadLine();
            }

            if (currentHealth > 0)
            {
                Console.WriteLine($"Final Health: {currentHealth}");
            }
            else
            {
                Console.WriteLine("Immune System Defeated.");
            }
        }
    }
}