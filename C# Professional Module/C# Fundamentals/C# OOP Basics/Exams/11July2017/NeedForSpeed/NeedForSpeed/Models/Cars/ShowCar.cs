using System.Text;

public class ShowCar : Car
{
    public int Stars { get; set; }
    public ShowCar(string brand, string model, int yearOfProduction, int horsePower, int acceleration, int suspension, int durability)
        : base(brand, model, yearOfProduction, horsePower, acceleration, suspension, durability)
    {
        this.Stars = 0;
    }
    public override void TuneCar(int tuneIndex, string addOn)
    {
        base.TuneCar(tuneIndex, addOn);

        this.Stars += tuneIndex;
    }
    public override string ToString()
    {
        var carInfo = new StringBuilder(base.ToString());

        carInfo.AppendLine($"{this.Stars} *");

        string result = carInfo.ToString().TrimEnd();

        return result;
    }
}

