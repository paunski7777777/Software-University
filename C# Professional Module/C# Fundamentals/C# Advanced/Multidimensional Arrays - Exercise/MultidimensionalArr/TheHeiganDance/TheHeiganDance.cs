using System;
class TheHeiganDance
{
    private const int ChamberSize = 15;
    private const int PlagueCloud = 3500;
    private const int Eruption = 6000;
    private const double PlayerHealth = 18500;
    private const double HeiganHealth = 3000000;
    static void Main()
    {
        var playerPosition = new int[] { ChamberSize / 2, ChamberSize / 2 };

        double damage = double.Parse(Console.ReadLine());

        double heiganHealth = HeiganHealth;
        double playerHealth = PlayerHealth;

        bool isHeiganDead = false;
        bool isPlayerDead = false;
        bool hasCloud = false;

        string deathCause = string.Empty;

        while (true)
        {
            string[] input = Console.ReadLine().Split();
            string spell = input[0];
            int row = int.Parse(input[1]);
            int column = int.Parse(input[2]);

            heiganHealth -= damage;

            isHeiganDead = heiganHealth <= 0;

            if (hasCloud)
            {
                playerHealth -= PlagueCloud;
                hasCloud = false;
                isPlayerDead = playerHealth <= 0;
            }

            if (isHeiganDead || isPlayerDead)
            {
                break;
            }

            if (IsPlayerInDamagedZone(playerPosition, row, column))
            {
                if (!PlayerTryToEscape(playerPosition, row, column))
                {
                    switch (spell)
                    {
                        case "Cloud":
                            playerHealth -= PlagueCloud;
                            hasCloud = true;
                            deathCause = "Plague " + spell;

                            break;

                        case "Eruption":
                            playerHealth -= Eruption;
                            deathCause = spell;

                            break;
                    }
                }
            }

            isPlayerDead = playerHealth <= 0;

            if (isPlayerDead)
            {
                break;
            }
        }

        PrintResult(playerPosition, heiganHealth, playerHealth, deathCause);
    }

    private static void PrintResult(int[] playerPosition, double heiganHealth, double playerHealth, string deathCause)
    {
        if (heiganHealth <= 0)
        {
            Console.WriteLine("Heigan: Defeated!");
        }
        else
        {
            Console.WriteLine($"Heigan: {heiganHealth:f2}");
        }

        if (playerHealth <= 0)
        {
            Console.WriteLine($"Player: Killed by {deathCause}");
        }
        else
        {
            Console.WriteLine($"Player: {playerHealth}");
        }

        Console.WriteLine($"Final position: {playerPosition[0]}, {playerPosition[1]}");
    }

    private static bool PlayerTryToEscape(int[] playerPosition, int row, int column)
    {
        if (playerPosition[0] - 1 >= 0 && playerPosition[0] - 1 < row - 1)
        {
            playerPosition[0]--;
            return true;
        }
        else if (playerPosition[1] + 1 < ChamberSize && playerPosition[1] + 1 > column + 1)
        {
            playerPosition[1]++;
            return true;
        }
        else if (playerPosition[0] + 1 < ChamberSize && playerPosition[0] + 1 > row + 1)
        {
            playerPosition[0]++;
            return true;
        }
        else if (playerPosition[1] - 1 >= 0 && playerPosition[1] - 1 < column - 1)
        {
            playerPosition[1]--;
            return true;
        }

        return false;
    }

    private static bool IsPlayerInDamagedZone(int[] playerPosition, int row, int column)
    {
        bool isHitRow = playerPosition[0] >= row - 1 && playerPosition[0] <= row + 1;
        bool isHitCol = playerPosition[1] >= column - 1 && playerPosition[1] <= column + 1;

        return isHitRow && isHitCol;
    }
}

