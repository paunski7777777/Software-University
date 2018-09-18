using System;
using System.Collections.Generic;

public class AnimalsProgram
{
    public static void Main()
    {
        var animals = new List<Animal>();

        string animalType;
        while ((animalType = Console.ReadLine()) != "Beast!")
        {
            try
            {
                AddAnimals(animals, animalType);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        animals.ForEach(e => Console.WriteLine(e));
    }

    private static void AddAnimals(List<Animal> animals, string animalType)
    {
        string[] tokens = Console.ReadLine().Split();

        string name = tokens[0];
        int age = int.Parse(tokens[1]);
        string gender = null;

        if (tokens.Length == 3)
        {
            gender = tokens[2];
        }

        switch (animalType)
        {
            case "Cat":
                Cat cat = new Cat(name, gender, age);
                animals.Add(cat);
                break;
            case "Dog":
                Dog dog = new Dog(name, gender, age);
                animals.Add(dog);
                break;
            case "Frog":
                Frog frog = new Frog(name, gender, age);
                animals.Add(frog);
                break;
            case "Tomcat":
                Tomcat tomcat = new Tomcat(name, age);
                animals.Add(tomcat);
                break;
            case "Kitten":
                Kitten kitten = new Kitten(name, age);
                animals.Add(kitten);
                break;
            default:
                throw new ArgumentException("Invalid input!");
        }
    }
}
