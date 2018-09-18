using System;
using System.Collections.Generic;
using System.Linq;

public class PokemonTrainer
{
    public static void Main()
    {
        var trainers = new List<Trainer>();

        string input;
        while ((input = Console.ReadLine()) != "Tournament")
        {
            string[] tokens = input.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            string trainerName = tokens[0];
            string pokemonName = tokens[1];
            string pokemonElement = tokens[2];
            int pokemonHealth = int.Parse(tokens[3]);

            if (!trainers.Any(t => t.Name == trainerName))
            {
                Trainer trainer = new Trainer(trainerName);
                trainers.Add(trainer);
            }

            var currentTrainer = trainers.FirstOrDefault(t => t.Name == trainerName);

            if (!currentTrainer.Pokemons.Any(p => p.Name == pokemonName))
            {
                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);
                currentTrainer.Pokemons.Add(pokemon);
            }
            else
            {
                currentTrainer.Pokemons.FirstOrDefault(p => p.Name == pokemonName).Element = pokemonElement;
                currentTrainer.Pokemons.FirstOrDefault(p => p.Name == pokemonName).Health += pokemonHealth;
            }
        }

        string element;
        while ((element = Console.ReadLine()) != "End")
        {
            foreach (var trainer in trainers)
            {
                if (trainer.Pokemons.Any(p => p.Element == element))
                {
                    trainer.Badges++;
                }
                else
                {
                    trainer.Pokemons.ForEach(p => p.Health -= 10);
                    foreach (var pokemon in trainer.Pokemons)
                    {
                        if (pokemon.Health < 1)
                        {
                            trainer.Pokemons = trainer.Pokemons.Where(p => p.Health > 0).ToList();
                        }
                    }
                }
            }
        }

        var ordered = trainers.OrderByDescending(b => b.Badges).ToList();

        foreach (var trainer in ordered)
        {
            Console.WriteLine(trainer);
        }
    }
}

