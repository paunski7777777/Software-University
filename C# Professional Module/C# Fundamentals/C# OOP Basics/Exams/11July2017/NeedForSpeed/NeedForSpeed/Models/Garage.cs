using System;
using System.Collections.Generic;

public class Garage
{
    public List<int> ParkedCars { get; set; }
    public Garage()
    {
        this.ParkedCars = new List<int>();
    }
    public void ParkCar(int id)
    {
        this.ParkedCars.Add(id);
    }

    public void UnparkCar(int id)
    {
        this.ParkedCars.Remove(id);
    }
}

