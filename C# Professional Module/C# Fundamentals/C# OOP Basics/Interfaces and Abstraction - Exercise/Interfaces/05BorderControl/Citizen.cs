using System;
using System.Collections.Generic;
using System.Text;
public class Citizen : IIdenticable, IBirthdatable
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Id { get; private set; }
    public string Birthdate { get; private set; }
    public Citizen(string name, int age, string id, string birthdate)
    {
        this.Name = name;
        this.Age = age;
        this.Id = id;
        this.Birthdate = birthdate;
    }
}

