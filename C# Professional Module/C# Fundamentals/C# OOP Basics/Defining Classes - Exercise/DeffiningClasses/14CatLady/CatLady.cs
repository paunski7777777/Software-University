using System;
using System.Collections.Generic;
using System.Linq;

public class CatLady
{
    public static void Main()
    {
        var cats = new List<Cat>();

        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] tokens = input.Split();
            string breed = tokens[0];
            string name = tokens[1];

            Cat cat = new Cat(name, breed);

            switch (breed)
            {
                case "Siamese":
                    int earSize = int.Parse(tokens[2]);
                    cat = new Siamese(name, breed, earSize);
                    break;

                case "Cymric":
                    double furLength = double.Parse(tokens[2]);
                    cat = new Cymric(name, breed, furLength);
                    break;

                case "StreetExtraordinaire":
                    int decibelsOfMeows = int.Parse(tokens[2]);
                    cat = new StreetExtraordinaire(name, breed, decibelsOfMeows);
                    break;
            }

            cats.Add(cat);
        }

        string catInput = Console.ReadLine();
        var neededCat = cats.FirstOrDefault(c => c.Name == catInput);

        Console.WriteLine(neededCat);
    }
}
