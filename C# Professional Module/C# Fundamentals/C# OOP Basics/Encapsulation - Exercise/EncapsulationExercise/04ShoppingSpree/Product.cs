using System;
using System.Collections.Generic;
using System.Text;
public class Product
{
    private string name;
    private double price;
    public string Name
    {
        get { return name; }
        set
        {
            Validator.ValidateName(value);
            name = value;
        }
    }
    public double Price
    {
        get { return price; }
        set
        {
            Validator.ValidateMoney(value);
            price = value;
        }
    }
    public Product(string name, double price)
    {
        this.Name = name;
        this.Price = price;
    }
    public override string ToString()
    {
        return $"{this.Name}";
    }
}

