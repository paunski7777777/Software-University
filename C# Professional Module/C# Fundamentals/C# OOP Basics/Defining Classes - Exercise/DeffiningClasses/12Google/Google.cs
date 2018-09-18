using System;
using System.Collections.Generic;
using System.Linq;

class Google
{
    static void Main()
    {
        var people = new List<Person>();

        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] tokens = input.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            string personName = tokens[0];
            string personProp = tokens[1];

            if (!people.Any(p => p.Name == personName))
            {
                Person person = new Person(personName);
                people.Add(person);
            }

            var currentPerson = people.FirstOrDefault(p => p.Name == personName);

            if (personProp == "company")
            {
                string companyName = tokens[2];
                string companyDepartment = tokens[3];
                double companySalary = double.Parse(tokens[4]);

                Company company = new Company(companyName, companyDepartment, companySalary);

                currentPerson.Company = company;
            }
            else if (personProp == "pokemon")
            {
                string pokemonName = tokens[2];
                string pokemonType = tokens[3];

                Pokemon pokemon = new Pokemon(pokemonName, pokemonType);

                currentPerson.Pokemons.Add(pokemon);
            }
            else if (personProp == "parents")
            {
                string parentName = tokens[2];
                string parentBirthday = tokens[3];

                Parent parent = new Parent(parentName, parentBirthday);

                currentPerson.Parents.Add(parent);
            }
            else if (personProp == "children")
            {
                string childName = tokens[2];
                string childBirthday = tokens[3];

                Child child = new Child(childName, childBirthday);

                currentPerson.Children.Add(child);
            }
            else if (personProp == "car")
            {
                string carModel = tokens[2];
                int carPower = int.Parse(tokens[3]);

                Car car = new Car(carModel, carPower);

                currentPerson.Car = car;
            }
        }

        string name = Console.ReadLine();

        var neededPerson = people.FirstOrDefault(p => p.Name == name);

        Console.WriteLine(neededPerson);
    }
}

