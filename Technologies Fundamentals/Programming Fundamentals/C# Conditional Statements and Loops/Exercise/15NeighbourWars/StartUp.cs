namespace _15NeighbourWars
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            int pesho = int.Parse(Console.ReadLine());
            int gosho = int.Parse(Console.ReadLine());

            int healthP = 100;
            int healthG = 100;

            int turn = 0;

            while (healthP > 0 && healthG > 0)
            {
                turn++;

                if (turn % 2 != 0)
                {
                    healthG -= pesho;

                    if (healthG < 1)
                    {
                        Console.WriteLine($"Pesho won in {turn}th round.");
                        break;
                    }

                    Console.WriteLine($"Pesho used Roundhouse kick and reduced Gosho to {healthG} health.");
                }
                else
                {
                    healthP -= gosho;

                    if (healthP < 1)
                    {
                        Console.WriteLine($"Gosho won in {turn}th round.");
                        break;
                    }

                    Console.WriteLine($"Gosho used Thunderous fist and reduced Pesho to {healthP} health.");
                }

                if (turn % 3 == 0)
                {
                    healthP += 10;
                    healthG += 10;
                }
            }
        }
    }
}