using System;
using System.Collections.Generic;
using System.Linq;

public class BorderControl
{
    public static void Main()
    {
        var birthdates = new List<IBirthdatable>();

        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] tokens = input.Split();
            string command = tokens[0];

            switch (command)
            {
                case "Citizen":
                    string name = tokens[1];
                    int age = int.Parse(tokens[2]);
                    string id = tokens[3];
                    string birthdate = tokens[4];

                    IBirthdatable citizen = new Citizen(name, age, id, birthdate);
                    birthdates.Add(citizen);

                    break;

                case "Robot":
                    break;

                case "Pet":
                    string petName = tokens[1];
                    string petBirthdate = tokens[2];

                    IBirthdatable pet = new Pet(petName, petBirthdate);
                    birthdates.Add(pet);

                    break;
            }
        }
        string birthdateInput = Console.ReadLine();

        foreach (var b in birthdates)
        {
            if (b.Birthdate.EndsWith(birthdateInput))
            {
                Console.WriteLine(b.Birthdate);
            }
        }
    }
}

