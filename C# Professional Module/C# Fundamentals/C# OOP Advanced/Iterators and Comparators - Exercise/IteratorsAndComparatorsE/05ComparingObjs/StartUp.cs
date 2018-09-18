using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        List<Person> people = new List<Person>();

        string input;
        while ((input = Console.ReadLine()) != "END")
        {
            string[] tokens = input.Split();
            string name = tokens[0];
            int age = int.Parse(tokens[1]);
            string town = tokens[2];

            Person person = new Person(name, age, town);
            people.Add(person);
        }

        int index = int.Parse(Console.ReadLine()) - 1;
        Person personToCompare = people[index];

        int matches = 0;

        foreach (var person in people)
        {
            if (person.CompareTo(personToCompare) == 0)
            {
                matches++;
            }
        }

        if (matches > 1)
        {
            Console.WriteLine($"{matches} {people.Count - matches} {people.Count}");
        }
        else
        {
            Console.WriteLine("No matches");
        }
    }
}

