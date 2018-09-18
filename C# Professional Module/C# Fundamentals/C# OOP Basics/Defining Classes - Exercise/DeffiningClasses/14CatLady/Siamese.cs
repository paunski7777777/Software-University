using System;
using System.Collections.Generic;
using System.Text;
public class Siamese : Cat
{
    public int EarSize { get; set; }
    public Siamese(string name, string breed, int earSize) : base(name, breed)
    {
        this.EarSize = earSize;
    }
    public override string ToString()
    {
        return $"{base.ToString()} {this.EarSize}";
    }
}

