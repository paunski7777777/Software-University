using System;
using System.Collections.Generic;
using System.Text;
public class Gandalf
{
    public int Happiness { get; set; }
    public Gandalf()
    {
        this.Happiness = 0;
    }
    public void EatFood(string food)
    {
        var foodPoints = new Dictionary<string, int>
        {
            ["cram"] = 2,
            ["lembas"] = 3,
            ["apple"] = 1,
            ["melon"] = 1,
            ["honeycake"] = 5,
            ["mushrooms"] = -10
        };

        if (foodPoints.ContainsKey(food))
        {
            this.Happiness += foodPoints[food];
        }
        else
        {
            this.Happiness--;
        }
    }
    public string CalculateMood()
    {
        if (this.Happiness < -5)
        {
            return "Angry";
        }
        else if (this.Happiness >= -5 && this.Happiness <= 0)
        {
            return "Sad";
        }
        else if (this.Happiness >= 1 && this.Happiness <= 15)
        {
            return "Happy";
        }
        else
        {
            return "JavaScript";
        }
    }
}

