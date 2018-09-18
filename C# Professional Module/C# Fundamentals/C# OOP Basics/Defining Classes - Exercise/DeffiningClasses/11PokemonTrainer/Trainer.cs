using System;
using System.Collections.Generic;
using System.Text;
public class Trainer
{
    public string Name { get; set; }
    public int Badges { get; set; }
    public List<Pokemon> Pokemons { get; set; }
    public Trainer(string name)
    {
        this.Name = name;
        this.Badges = 0;
        this.Pokemons = new List<Pokemon>();
    }
    public override string ToString()
    {
        return $"{this.Name} {this.Badges} {this.Pokemons.Count}";
    }
}

