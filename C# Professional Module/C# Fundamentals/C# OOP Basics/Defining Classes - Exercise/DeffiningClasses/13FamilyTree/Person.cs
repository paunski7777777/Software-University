using System;
using System.Collections.Generic;
using System.Text;
public class Person
{
    public string Name { get; set; }
    public string BirthDay { get; set; }
    public List<Person> Parents { get; set; }
    public List<Person> Children { get; set; }
    public Person()
    {
        this.Parents = new List<Person>();
        this.Children = new List<Person>();
    }
    public Person(string name, string birthday)
    {
        this.Name = name;
        this.BirthDay = birthday;
        this.Parents = new List<Person>();
        this.Children = new List<Person>();
    }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder();

        result.AppendLine($"{this.Name} {this.BirthDay}");

        result.AppendLine($"Parents:");
        foreach (var parent in this.Parents)
        {
            result.AppendLine($"{parent.Name} {parent.BirthDay}");
        }

        result.AppendLine($"Children:");
        foreach (var child in this.Children)
        {
            result.AppendLine($"{child.Name} {child.BirthDay}");
        }

        return result.ToString().TrimEnd();
    }
}

