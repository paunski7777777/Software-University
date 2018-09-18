using System;
using System.Collections.Generic;
using System.Text;
public class Tomcat : Cat
{
    public Tomcat(string name, int age) : base(name, "Male", age)
    {

    }
    public override string ProduceSound()
    {
        return "MEOW";
    }
}
