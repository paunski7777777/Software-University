using System;
public class Cat : Animal
{
    public Cat(string name, string favouriteFood)
    {
        this.Name = name;
        this.FavouriteFood = favouriteFood;
    }
    public override string ExplainSelf()
    {
        return $"{base.ExplainSelf()}{Environment.NewLine}MEEOW";
    }
}

