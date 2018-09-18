using System;
public class PizzaCalories
{
    public static void Main()
    {
        try
        {
            string pizzaName = Console.ReadLine().Split()[1];
            Pizza pizza = new Pizza(pizzaName);

            Dough dough = CreateDough();
            pizza.SetDough(dough);

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                CreateTopping(pizza, input);
            }

            Console.WriteLine(pizza);
        }
        catch(ArgumentException argEx)
        {
            Console.WriteLine(argEx.Message);
        }
    }

    private static Dough CreateDough()
    {
        string[] doughInput = Console.ReadLine().Split();
        string flourType = doughInput[1];
        string bakingTechnique = doughInput[2];
        double doughWeight = double.Parse(doughInput[3]);

        Dough dough = new Dough(flourType, bakingTechnique, doughWeight);
        return dough;
    }

    private static void CreateTopping(Pizza pizza, string input)
    {
        string[] toppingsInput = input.Split();
        string toppingType = toppingsInput[1];
        double toppingWeight = double.Parse(toppingsInput[2]);

        Topping topping = new Topping(toppingType, toppingWeight);
        pizza.AddTopping(topping);
    }
}

