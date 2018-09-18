using System;
using System.Collections.Generic;
using System.Text;
public class RandomList : List<string>
{
    private Random random;
    public RandomList()
    {
        this.random = new Random();
    }
    public string RandomString()
    {
        string result = string.Empty;

        if (this.Count > 0)
        {
            int index = random.Next(0, this.Count - 1);
            result = this[index];
            this.RemoveAt(index);
        }

        return result;
    }
}

