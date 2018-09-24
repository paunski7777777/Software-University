namespace _06Heists
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int[] elements = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int priceJ = elements[0];
            int priceG = elements[1];

            int totalExpenses = 0;
            int totalEarnings = 0;
            int countJ = 0;
            int countG = 0;

            string info = Console.ReadLine();

            while (info != "Jail Time")
            {
                string[] heist = info.Split().ToArray();

                countJ = heist[0].Where(j => j == '%').Count();
                countG = heist[0].Where(g => g == '$').Count();

                totalExpenses += int.Parse(heist[1]);
                totalEarnings += countJ * priceJ + countG * priceG;

                info = Console.ReadLine();
            }

            if (totalEarnings >= totalExpenses)
            {
                Console.WriteLine($"Heists will continue. Total earnings: {totalEarnings - totalExpenses}.");
            }
            else
            {
                Console.WriteLine($"Have to find another job. Lost: {totalExpenses - totalEarnings}.");
            }
        }
    }
}