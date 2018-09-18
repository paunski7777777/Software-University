using System;
public class Owl : Bird
{
    private const double INCREASE_OWL_WEIGHT = 0.25;
    public Owl(string name, double weight, double wingSize)
        : base(name, weight, wingSize)
    {
    }

    public override string AskForFood()
    {
        return "Hoot Hoot";
    }

    public override void Eat(Food food)
    {
        string foodType = food.GetType().Name;
        if (foodType == "Meat")
        {
            this.Weight += food.Quantity * INCREASE_OWL_WEIGHT;
            this.FoodEaten += food.Quantity;
        }
        else
        {
            throw new ArgumentException(string.Format(EATING_ERROR, this.GetType().Name, foodType));
        }
    }
}

