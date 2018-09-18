using System;
public class Mouse : Mammal
{
    private const double INCREASE_MOUSE_WEIGHT = 0.10;
    public Mouse(string name, double weight, string livingRegion)
        : base(name, weight, livingRegion)
    {
    }

    public override string AskForFood()
    {
        return "Squeak";
    }

    public override void Eat(Food food)
    {
        string foodType = food.GetType().Name;
        if (foodType == "Vegetable" || foodType == "Fruit")
        {
            this.Weight += food.Quantity * INCREASE_MOUSE_WEIGHT;
            this.FoodEaten += food.Quantity;
        }
        else
        {
            throw new ArgumentException(string.Format(EATING_ERROR, this.GetType().Name, foodType));
        }
    }
    public override string ToString()
    {
        return $"{base.ToString()}{this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
    }
}

