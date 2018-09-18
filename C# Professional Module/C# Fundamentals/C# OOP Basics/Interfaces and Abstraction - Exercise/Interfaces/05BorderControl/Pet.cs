using System;
using System.Collections.Generic;
using System.Text;
public class Pet : IBirthdatable
{
    public string Name { get; set; }
    public string Birthdate { get; private set; }
    public Pet(string name, string birthdate)
    {
        this.Name = name;
        this.Birthdate = birthdate;
    }
}

