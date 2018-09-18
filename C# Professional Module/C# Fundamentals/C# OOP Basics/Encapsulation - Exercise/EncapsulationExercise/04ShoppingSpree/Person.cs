using System;
using System.Collections.Generic;
using System.Text;
public class Person
{
    private string name;
    private double money;
    public List<Product> Products { get; set; }

    public string Name
    {
        get { return name; }
        set
        {
            Validator.ValidateName(value);
            name = value;
        }
    }
    public double Money
    {
        get { return money; }
        set
        {
            Validator.ValidateMoney(value);
            money = value;
        }
    }
    public Person(string name, double money)
    {
        this.Name = name;
        this.Money = money;
        this.Products = new List<Product>();
    }
    public string TryBuyProduct(Product product)
    {
        if (this.Money < product.Price)
        {
            return $"{this.Name} can't afford {product.Name}";
        }
        else
        {
            this.Money -= product.Price;
            this.Products.Add(product);

            return $"{this.Name} bought {product.Name}";
        }
    }
    public override string ToString()
    {
        string productsOutput = this.Products.Count > 0 ? string.Join(", ", this.Products) : "Nothing bought";
        string result = $"{this.Name} - {productsOutput}";

        return result;
    }
}

