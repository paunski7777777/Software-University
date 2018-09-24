using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Evolution
{
    public string EvolutionType { get; set; }
    public long EvolutionIndex { get; set; }

    public Evolution(string type, long index)
    {
        this.EvolutionType = type;
        this.EvolutionIndex = index;
    }
}
class PokemonEvolution
{
    static void Main()
    {
        var pokemons = new Dictionary<string, List<Evolution>>();

        string input = Console.ReadLine();

        while (input != "wubbalubbadubdub")
        {
            string[] tokens = input.Split(new string[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);
            string pokemonName = tokens[0];

            if (tokens.Length == 1)
            {
                if (pokemons.ContainsKey(pokemonName))
                {
                    Console.WriteLine($"# {pokemonName}");
                    foreach (var p in pokemons[pokemonName])
                    {
                        Console.WriteLine($"{p.EvolutionType} <-> {p.EvolutionIndex}");
                    }
                }
            }

            else
            {
                string evolutionType = tokens[1];
                long evolutionIndex = long.Parse(tokens[2]);

                Evolution evolution = new Evolution(evolutionType, evolutionIndex);

                if (!pokemons.ContainsKey(pokemonName))
                {
                    pokemons[pokemonName] = new List<Evolution>();
                }
                pokemons[pokemonName].Add(evolution);
            }


            input = Console.ReadLine();
        }

        foreach (var p in pokemons)
        {
            string name = p.Key;
            List<Evolution> type = p.Value;
            Console.WriteLine($"# {name}");
            foreach (var t in type.OrderByDescending(t => t.EvolutionIndex))
            {
                Console.WriteLine($"{t.EvolutionType} <-> {t.EvolutionIndex}");
            }
        }
    }
}

