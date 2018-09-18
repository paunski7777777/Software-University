using System;
using System.Collections.Generic;

public class WildFarm
{
    public static void Main()
    {
        var animals = new List<Animal>();

        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            Animal animal = CreateAnimal(animals, input);
            Food food = CreateFood();

            try
            {
                animal.Eat(food);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }

        }
        animals.ForEach(a => Console.WriteLine(a));
    }

    private static Food CreateFood()
    {
        string[] foodInfo = Console.ReadLine().Split();
        string foodType = foodInfo[0];
        double foodQuantity = double.Parse(foodInfo[1]);

        Food food = null;

        switch (foodType)
        {
            case "Vegetable":
                food = new Vegetable(foodQuantity);
                break;

            case "Fruit":
                food = new Fruit(foodQuantity);
                break;

            case "Meat":
                food = new Meat(foodQuantity);
                break;

            case "Seeds":
                food = new Seeds(foodQuantity);
                break;
        }

        return food;
    }

    private static Animal CreateAnimal(List<Animal> animals, string input)
    {
        string[] animalInfo = input.Split();
        string animalType = animalInfo[0];
        string animalName = animalInfo[1];
        double animalWeight = double.Parse(animalInfo[2]);

        Animal animal = null;

        switch (animalType)
        {
            case "Cat":
                animal = CreateCat(animals, animalInfo, animalName, animalWeight);
                break;

            case "Tiger":
                animal = CreateTiger(animals, animalInfo, animalName, animalWeight);
                break;

            case "Hen":
                animal = CreateHen(animals, animalInfo, animalName, animalWeight);
                break;

            case "Owl":
                animal = CreateOwl(animals, animalInfo, animalName, animalWeight);
                break;

            case "Mouse":
                animal = CreateMouse(animals, animalInfo, animalName, animalWeight);
                break;

            case "Dog":
                animal = CreateDog(animals, animalInfo, animalName, animalWeight);
                break;
        }

        return animal;
    }

    private static Animal CreateDog(List<Animal> animals, string[] animalInfo, string animalName, double animalWeight)
    {
        Animal animal;

        string dogLivingRegion = animalInfo[3];
        animal = new Dog(animalName, animalWeight, dogLivingRegion);
        animals.Add(animal);

        MakeSound(animal);

        return animal;
    }

    private static Animal CreateMouse(List<Animal> animals, string[] animalInfo, string animalName, double animalWeight)
    {
        Animal animal;

        string mouseLivingRegion = animalInfo[3];

        animal = new Mouse(animalName, animalWeight, mouseLivingRegion);
        animals.Add(animal);

        MakeSound(animal);
        return animal;
    }

    private static Animal CreateOwl(List<Animal> animals, string[] animalInfo, string animalName, double animalWeight)
    {
        Animal animal;

        double owlWingSize = double.Parse(animalInfo[3]);

        animal = new Owl(animalName, animalWeight, owlWingSize);
        animals.Add(animal);

        MakeSound(animal);
        return animal;
    }

    private static Animal CreateHen(List<Animal> animals, string[] animalInfo, string animalName, double animalWeight)
    {
        Animal animal;

        double henWingSize = double.Parse(animalInfo[3]);

        animal = new Hen(animalName, animalWeight, henWingSize);
        animals.Add(animal);

        MakeSound(animal);
        return animal;
    }

    private static Animal CreateTiger(List<Animal> animals, string[] animalInfo, string animalName, double animalWeight)
    {
        Animal animal;

        string tigerLivingRegion = animalInfo[3];
        string tigerBreed = animalInfo[4];

        animal = new Tiger(animalName, animalWeight, tigerLivingRegion, tigerBreed);
        animals.Add(animal);

        MakeSound(animal);
        return animal;
    }

    private static Animal CreateCat(List<Animal> animals, string[] animalInfo, string animalName, double animalWeight)
    {
        Animal animal;

        string catLivingRegion = animalInfo[3];
        string catBreed = animalInfo[4];

        animal = new Cat(animalName, animalWeight, catLivingRegion, catBreed);
        animals.Add(animal);

        MakeSound(animal);
        return animal;
    }

    private static void MakeSound(Animal animal)
    {
        Console.WriteLine(animal.AskForFood());
    }
}

