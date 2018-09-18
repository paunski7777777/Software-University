using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        SortedSet<Person> sorted = new SortedSet<Person>();
        HashSet<Person> people = new HashSet<Person>();

        int peopleCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < peopleCount; i++)
        {
            string[] input = Console.ReadLine().Split();
            string name = input[0];
            int age = int.Parse(input[1]);

            Person person = new Person(name, age);
            sorted.Add(person);
            people.Add(person);
        }

        Console.WriteLine(sorted.Count);
        Console.WriteLine(people.Count);
    }
}

