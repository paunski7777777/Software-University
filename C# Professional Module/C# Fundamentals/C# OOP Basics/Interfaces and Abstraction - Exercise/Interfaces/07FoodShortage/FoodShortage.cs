using System;
using System.Collections.Generic;
using System.Linq;

public class FoodShortage
{
    public static void Main()
    {
        var buyers = new List<IBuyer>();
        int countOfPeople = int.Parse(Console.ReadLine());

        for (int i = 0; i < countOfPeople; i++)
        {
            string[] tokens = Console.ReadLine().Split();

            CreateRebel(buyers, tokens);
            CreateCitizen(buyers, tokens);
        }

        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            if (buyers.Any(b => b.Name == input))
            {
                var currentBuyer = buyers.FirstOrDefault(b => b.Name == input);
                currentBuyer.BuyFood();
            }
        }

        Console.WriteLine(buyers.Sum(b => b.Food));
    }

    private static void CreateCitizen(List<IBuyer> buyers, string[] tokens)
    {
        if (tokens.Length == 4)
        {
            string citizenName = tokens[0];
            int citizenAge = int.Parse(tokens[1]);
            string id = tokens[2];
            string birthdate = tokens[3];

            IBuyer citizen = new Citizen(citizenName, citizenAge, id, birthdate);
            buyers.Add(citizen);
        }
    }

    private static void CreateRebel(List<IBuyer> buyers, string[] tokens)
    {
        if (tokens.Length == 3)
        {
            string rebelName = tokens[0];
            int rebelAge = int.Parse(tokens[1]);
            string group = tokens[2];

            IBuyer rebel = new Rebel(rebelName, rebelAge, group);
            buyers.Add(rebel);
        }
    }
}

