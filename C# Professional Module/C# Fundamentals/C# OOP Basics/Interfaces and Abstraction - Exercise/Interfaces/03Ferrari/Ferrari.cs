using System;
using System.Collections.Generic;
using System.Text;
public class Ferrari : ICar
{
    public string Model { get; private set; }
    public string Brakes { get; private set; }
    public string GasPedal { get; private set; }
    public string DriversName { get; private set; }
    public Ferrari(string driversName)
    {
        this.Model = "488-Spider";
        this.Brakes = "Brakes!";
        this.GasPedal = "Zadu6avam sA!";
        this.DriversName = driversName;
    }
    public override string ToString()
    {
        return $"{this.Model}/{this.Brakes}/{this.GasPedal}/{this.DriversName}";
    }
}

