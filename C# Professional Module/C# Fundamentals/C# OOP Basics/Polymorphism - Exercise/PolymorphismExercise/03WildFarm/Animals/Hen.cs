public class Hen : Bird
{
    private const double INCREASE_HEN_WEIGHT = 0.35;
    public Hen(string name, double weight, double wingSize)
        : base(name, weight, wingSize)
    {
    }

    public override string AskForFood()
    {
        return "Cluck";
    }

    public override void Eat(Food food)
    {
        this.Weight += food.Quantity * INCREASE_HEN_WEIGHT;
        this.FoodEaten += food.Quantity;
    }
}

