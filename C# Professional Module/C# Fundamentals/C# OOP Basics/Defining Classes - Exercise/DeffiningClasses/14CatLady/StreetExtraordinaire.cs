using System;
using System.Collections.Generic;
using System.Text;
public class StreetExtraordinaire : Cat
{
    public int DecibelsOfMeows { get; set; }
    public StreetExtraordinaire(string name, string breed, int decibelsOfMeows) : base(name, breed)
    {
        this.DecibelsOfMeows = decibelsOfMeows;
    }
    public override string ToString()
    {
        return $"{base.ToString()} {this.DecibelsOfMeows}";
    }
}

