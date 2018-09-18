using System;
using System.Collections.Generic;
using System.Text;
public class Cat : Animal
{
    public Cat(string name, string gender, int age) : base(name, gender, age)
    {

    }
    public override string ProduceSound()
    {
        return "Meow meow";
    }
}

