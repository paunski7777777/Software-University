using System;
using System.Collections.Generic;
using System.Text;
class Person
{
    public string Name { get; set; }
    public Company Company { get; set; }
    public Car Car { get; set; }
    public List<Pokemon> Pokemons { get; set; }
    public List<Parent> Parents { get; set; }
    public List<Child> Children { get; set; }
    public Person(string name)
    {
        this.Name = name;
        this.Company = new Company();
        this.Car = new Car();
        this.Pokemons = new List<Pokemon>();
        this.Parents = new List<Parent>();
        this.Children = new List<Child>();
    }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder();
        result.AppendLine(this.Name);

        result.AppendLine("Company:");
        if (this.Company.Name != null)
        {
            result.AppendLine($"{this.Company.Name} {this.Company.Department} {this.Company.Salary:f2}");
        }

        result.AppendLine("Car:");
        if (this.Car.Model != null)
        {
            result.AppendLine($"{this.Car.Model} {this.Car.Speed}");
        }

        result.AppendLine("Pokemon:");
        foreach (var pokemon in this.Pokemons)
        {
            result.AppendLine($"{pokemon.Name} {pokemon.Type}");
        }

        result.AppendLine("Parents:");
        foreach (var parent in this.Parents)
        {
            result.AppendLine($"{parent.Name} {parent.Birthday}");
        }

        result.AppendLine("Children:");
        foreach (var child in this.Children)
        {
            result.AppendLine($"{child.Name} {child.Birthday}");
        }

        return result.ToString().TrimEnd();
    }
}

