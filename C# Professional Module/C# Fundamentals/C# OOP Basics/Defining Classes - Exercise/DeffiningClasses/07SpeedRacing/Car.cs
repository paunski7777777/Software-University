using System;
using System.Collections.Generic;
using System.Text;
public class Car
{
    public string Model { get; set; }
    public double FuelAmount { get; set; }
    public double FuelConsumption { get; set; }
    public double DistanceTraveled { get; set; }

    public Car(string model, double fuelAmount, double fuelConsumption)
    {
        this.Model = model;
        this.FuelAmount = fuelAmount;
        this.FuelConsumption = fuelConsumption;
        this.DistanceTraveled = 0;
    }
    
    public void Drive(double kilometersToTravel)
    {
        if (kilometersToTravel <= this.FuelAmount / this.FuelConsumption)
        {
            this.DistanceTraveled += kilometersToTravel;
            this.FuelAmount -= this.FuelConsumption * kilometersToTravel;
        }
        else
        {
            Console.WriteLine("Insufficient fuel for the drive");
        }
    }
}

