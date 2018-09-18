using System;
using System.Collections.Generic;

public class TeamProgram
{
    static void Main()
    {
        var people = new List<Person>();
        int countPeople = int.Parse(Console.ReadLine());

        for (int i = 0; i < countPeople; i++)
        {
            string[] input = Console.ReadLine().Split();

            try
            {
                string firstName = input[0];
                string lastName = input[1];
                int age = int.Parse(input[2]);
                decimal salary = decimal.Parse(input[3]);

                Person person = new Person(firstName, lastName, age, salary);
                people.Add(person);
            }
            catch (ArgumentException exeption)
            {
                Console.WriteLine(exeption.Message);
            }
        }

        Team team = new Team("SoftUni");

        people.ForEach(p => team.AddPlayer(p));

        Console.WriteLine(team);
    }
}

