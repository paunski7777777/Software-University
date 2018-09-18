using System;
using System.Collections.Generic;
using System.Text;
public class Cat
{
    public string Name { get; set; }
    public string Breed { get; set; }
    public Cat(string name, string breed)
    {
        this.Name = name;
        this.Breed = breed;
    }
    public override string ToString()
    {
        return $"{this.Breed} {this.Name}";
    }
}

