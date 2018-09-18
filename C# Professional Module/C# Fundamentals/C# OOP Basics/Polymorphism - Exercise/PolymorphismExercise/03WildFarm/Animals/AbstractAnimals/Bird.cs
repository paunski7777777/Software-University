public abstract class Bird : Animal
{
    public double WingSize { get; set; }
    public Bird(string name, double weight, double wingSize)
        : base(name, weight)
    {
        this.WingSize = wingSize;
    }
    public override string ToString()
    {
        return $"{base.ToString()}{this.WingSize}, {this.Weight}, {this.FoodEaten}]";
    }
}

