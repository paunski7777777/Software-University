using System;
using System.Collections.Generic;

class DefineAClassPerson
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        Family family = new Family();

        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split();

            string name = input[0];
            int age = int.Parse(input[1]);

            Person person = new Person(name, age);

            family.AddMember(person);
        }

        var oldestMember = family.GetOldestMember();

        Console.WriteLine($"{oldestMember.Name} {oldestMember.Age}");
    }
}

