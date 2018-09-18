public abstract class Mammal : Animal
{
    public string LivingRegion { get; set; }
    public Mammal(string name, double weight, string livingRegion) : base(name, weight)
    {
        this.LivingRegion = livingRegion;
    }
}

