using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
public class Pizza
{
    private const int MIN_LENGTH = 1;
    private const int MAX_LENGTH = 15;
    private const int MIN_TOPPINGS = 0;
    private const int MAX_TOPPINGS = 10;

    private string name;
    private string Name
    {
        get { return name; }
        set
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value) || value.Length > MAX_LENGTH)
            {
                throw new ArgumentException($"Pizza name should be between {MIN_LENGTH} and {MAX_LENGTH} symbols.");
            }
            name = value;
        }
    }
    private Dough Dough { get; set; }
    private List<Topping> Toppings { get; set; }
    private double ToppingCalories
    {
        get
        {
            if (this.Toppings.Count == 0)
            {
                return 0;
            }
            else
            {
                return this.Toppings.Select(t => t.Calories).Sum();
            }
        }
    }
    public Pizza()
    {
        this.Toppings = new List<Topping>();
    }
    public Pizza(string name) : this()
    {
        this.Name = name;
    }
    public void SetDough(Dough dough)
    {
        if (this.Dough == null)
        {
            this.Dough = dough;
        }
        else
        {
            throw new InvalidOperationException("Dough already set!");
        }
    }
    public void AddTopping(Topping topping)
    {
        this.Toppings.Add(topping);

        if (this.Toppings.Count > MAX_TOPPINGS)
        {
            throw new ArgumentException($"Number of toppings should be in range [{MIN_TOPPINGS}..{MAX_TOPPINGS}].");
        }
    }
    public double Calories => this.Dough.Calories + this.ToppingCalories;
    public override string ToString()
    {
        return $"{this.Name} - {this.Calories:f2} Calories.";
    }
}

