using System;
using System.Collections.Generic;
using System.Text;
public class Cymric : Cat
{
    public double FurLength { get; set; }
    public Cymric(string name, string breed, double furLength) : base(name, breed)
    {
        this.FurLength = furLength;
    }
    public override string ToString()
    {
        return $"{base.ToString()} {this.FurLength:f2}";
    }
}

