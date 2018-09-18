using System;
public class Tiger : Feline
{
    private const double INCREASE_TIGER_WEIGHT = 1.00;
    public Tiger(string name, double weight, string livingRegion, string breed)
        : base(name, weight, livingRegion, breed)
    {
    }

    public override string AskForFood()
    {
        return "ROAR!!!";
    }

    public override void Eat(Food food)
    {
        string foodType = food.GetType().Name;
        if (foodType == "Meat")
        {
            this.Weight += food.Quantity * INCREASE_TIGER_WEIGHT;
            this.FoodEaten += food.Quantity;
        }
        else
        {
            throw new ArgumentException(string.Format(EATING_ERROR, this.GetType().Name, foodType));
        }
    }
}

