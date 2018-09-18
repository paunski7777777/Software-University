using System;
using System.Collections.Generic;
using System.Text;
public class Rebel : IBuyer
{
    public string Name { get; private set; }
    public int Age { get; set; }
    public string Group { get; set; }
    public int Food { get; private set; }
    public void BuyFood()
    {
        this.Food += 5;
    }
    public Rebel(string name, int age, string group)
    {
        this.Name = name;
        this.Age = age;
        this.Group = group;
        this.Food = 0;
    }
}

