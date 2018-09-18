using System;
using System.Collections.Generic;
using System.Text;
public class Kitten : Cat
{
    public Kitten(string name, int age) : base(name, "Female", age)
    {

    }
    public override string ProduceSound()
    {
        return "Meow";
    }
}

