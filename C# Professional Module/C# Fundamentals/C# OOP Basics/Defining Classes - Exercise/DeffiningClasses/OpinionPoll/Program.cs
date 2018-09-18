using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var people = new List<Person>();

        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split();

            string name = input[0];
            int age = int.Parse(input[1]);

            var person = new Person(name, age);

            people.Add(person);
        }

        var filtered = people.Where(p => p.Age > 30).OrderBy(p => p.Name).ToList();

        foreach (var person in filtered)
        {
            Console.WriteLine($"{person.Name} - {person.Age}");
        }
    }
}

