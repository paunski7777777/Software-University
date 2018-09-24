namespace _01OrderByAge
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            var persons = new List<Person>();

            while (input != "End")
            {
                string[] tokens = input.Split();

                string name = tokens[0];
                string id = tokens[1];
                int age = int.Parse(tokens[2]);

                Person person = new Person(name, id, age);
                persons.Add(person);

                input = Console.ReadLine();
            }

            foreach (var p in persons.OrderBy(a => a.Age))
            {
                string name = p.Name;
                string id = p.Id;
                int age = p.Age;

                Console.WriteLine($"{name} with ID: {id} is {age} years old.");
            }
        }

        public class Person
        {
            public string Name { get; set; }
            public string Id { get; set; }
            public int Age { get; set; }

            public Person(string name, string id, int age)
            {
                this.Name = name;
                this.Id = id;
                this.Age = age;
            }
        }
    }
}