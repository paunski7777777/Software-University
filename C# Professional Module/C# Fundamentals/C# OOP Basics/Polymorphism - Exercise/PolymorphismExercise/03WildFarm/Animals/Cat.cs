using System;
public class Cat : Feline
{
    private const double INCREASE_CAT_WEIGHT = 0.30;
    public Cat(string name, double weight, string livingRegion, string breed)
        : base(name, weight, livingRegion, breed)
    {
    }

    public override string AskForFood()
    {
        return "Meow";
    }

    public override void Eat(Food food)
    {
        string foodType = food.GetType().Name;
        if (foodType == "Vegetable" || foodType == "Meat")
        {
            this.Weight += food.Quantity * INCREASE_CAT_WEIGHT;
            this.FoodEaten += food.Quantity;
        }
        else
        {
            throw new ArgumentException(string.Format(EATING_ERROR, this.GetType().Name, foodType));
        }
    }
}

