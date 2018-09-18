using System;
public class Dog : Mammal
{
    private const double INCREASE_DOG_WEIGHT = 0.40;
    public Dog(string name, double weight, string livingRegion) 
        : base(name, weight, livingRegion)
    {
    }

    public override string AskForFood()
    {
        return "Woof!";
    }

    public override void Eat(Food food)
    {
        string foodType = food.GetType().Name;
        if (foodType == "Meat")
        {
            this.Weight += food.Quantity * INCREASE_DOG_WEIGHT;
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

