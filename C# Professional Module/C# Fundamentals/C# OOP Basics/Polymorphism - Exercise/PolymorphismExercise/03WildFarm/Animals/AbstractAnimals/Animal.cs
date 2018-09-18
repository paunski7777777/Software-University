public abstract class Animal
{
    public const string EATING_ERROR = "{0} does not eat {1}!";
    public string Name { get; set; }
    public double Weight { get; set; }
    public double FoodEaten { get; set; }
    public Animal(string name, double weight)
    {
        this.Name = name;
        this.Weight = weight;
        this.FoodEaten = 0;
    }
    public abstract string AskForFood();
    public abstract void Eat(Food food);
    public override string ToString()
    {
        return $"{this.GetType().Name} [{this.Name}, ";
    }
}

