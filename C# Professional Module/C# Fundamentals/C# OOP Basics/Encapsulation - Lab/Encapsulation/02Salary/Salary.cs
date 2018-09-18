using System;
using System.Collections.Generic;
using System.Linq;

public class Salary
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
            decimal salary = decimal.Parse(input[3]);

            Person person = new Person(firstName, lastName, age, salary);
            people.Add(person);
        }

        decimal bonus = decimal.Parse(Console.ReadLine());

        people.ForEach(s => s.IncreaseSalary(bonus));
        people.ForEach(p => Console.WriteLine(p));
    }
}

