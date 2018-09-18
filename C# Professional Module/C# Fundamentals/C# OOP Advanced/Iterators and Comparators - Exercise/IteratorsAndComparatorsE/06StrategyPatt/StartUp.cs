using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        SortedSet<Person> peopleName = new SortedSet<Person>(new PersonNameComparer());
        SortedSet<Person> peopleAge = new SortedSet<Person>(new PersonAgeComparer());

        int peopleCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < peopleCount; i++)
        {
            string[] input = Console.ReadLine().Split();
            string name = input[0];
            int age = int.Parse(input[1]);

            Person person = new Person(name, age);
            peopleName.Add(person);
            peopleAge.Add(person);
        }

        Console.WriteLine(string.Join(Environment.NewLine, peopleName));
        Console.WriteLine(string.Join(Environment.NewLine, peopleAge));
    }
}
