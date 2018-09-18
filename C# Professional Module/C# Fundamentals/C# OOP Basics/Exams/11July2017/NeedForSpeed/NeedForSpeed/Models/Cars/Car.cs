using System.Text;

public abstract class Car
{
    public string Brand { get; set; }
    public string Model { get; set; }
    public int YearOfProduction { get; set; }
    public int HorsePower { get; set; }
    public int Acceleration { get; set; }
    public int Suspension { get; set; }
    public int Durability { get; set; }
    protected Car(string brand, string model, int yearOfProduction, int horsePower, int acceleration, int suspension, int durability)
    {
        this.Brand = brand;
        this.Model = model;
        this.YearOfProduction = yearOfProduction;
        this.HorsePower = horsePower;
        this.Acceleration = acceleration;
        this.Suspension = suspension;
        this.Durability = durability;
    }
    public virtual void TuneCar(int tuneIndex, string addOn)
    {
        this.HorsePower += tuneIndex;
        this.Suspension += tuneIndex * 50 / 100;
    }
    public override string ToString()
    {
        var carInfo = new StringBuilder();

        carInfo.AppendLine($"{this.Brand} {this.Model} {this.YearOfProduction}");
        carInfo.AppendLine($"{this.HorsePower} HP, 100 m/h in {this.Acceleration} s");
        carInfo.AppendLine($"{this.Suspension} Suspension force, {this.Durability} Durability");

        string result = carInfo.ToString();

        return result;
    }
}

