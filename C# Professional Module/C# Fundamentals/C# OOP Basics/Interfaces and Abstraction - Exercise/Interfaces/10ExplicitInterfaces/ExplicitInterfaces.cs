using System;
public class ExplicitInterfaces
{
    public static void Main()
    {
        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] tokens = input.Split();
            string name = tokens[0];
            string country = tokens[1];
            int age = int.Parse(tokens[2]);

            IPerson person = new Citizen(name, country, age);
            IResident resident = new Citizen(name, country, age);

            Console.WriteLine(person.GetName());
            Console.WriteLine(resident.GetName());
        }
    }
}

