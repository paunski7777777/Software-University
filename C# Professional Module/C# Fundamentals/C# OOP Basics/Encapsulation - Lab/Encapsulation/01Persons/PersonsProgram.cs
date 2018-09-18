using System;
using System.Collections.Generic;
using System.Linq;

public class PersonsProgram
{
    public static void Main()
    {
        var people = new List<Person>();
        int countPeople = int.Parse(Console.ReadLine());

        for (int i = 0; i < countPeople; i++)
        {
            string[] input = Console.ReadLine().Split();

            string firstName = input[0];
            string lastName = input[1];
            int age = int.Parse(input[2]);

            Person person = new Person(firstName, lastName, age);
            people.Add(person);
        }

        people
            .OrderBy(p => p.FirstName)
            .ThenBy(p => p.Age)
            .ToList()
            .ForEach(p => Console.WriteLine(p));
    }
}

