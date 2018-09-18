using System;
using System.Collections.Generic;
using System.Linq;

class FamilyTree
{
    static void Main()
    {
        var family = new List<Person>();

        string mainPersonInput = Console.ReadLine();
        Person mainPerson = new Person();

        if (IsBirthday(mainPersonInput))
        {
            mainPerson.BirthDay = mainPersonInput;
        }
        else
        {
            mainPerson.Name = mainPersonInput;
        }

        family.Add(mainPerson);

        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            if (!input.Contains("-"))
            {
                string[] tokens = input.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                string name = $"{tokens[0]} {tokens[1]}";
                string birthday = tokens[2];

                var currentPerson = family.FirstOrDefault(p => p.Name == name || p.BirthDay == birthday);

                if (currentPerson == null)
                {
                    Person person = new Person(name, birthday);
                    family.Add(person);
                }
                else
                {
                    if (currentPerson.Name == null)
                    {
                        currentPerson.Name = name;
                    }
                    if (currentPerson.BirthDay == null)
                    {
                        currentPerson.BirthDay = birthday;
                    }
                }
            }

            else
            {
                string[] tokens = input.Split("- ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                string parentInput = tokens[0];
                string childInput = tokens[1];

                Person parent = CreatePerson(parentInput);
                Person child = CreatePerson(childInput);

                parent.Children.Add(child);
                child.Parents.Add(parent);
            }
        }

        Console.WriteLine(mainPerson);
    }

    private static Person CreatePerson(string personInfo)
    {
        Person person = new Person();

        if (IsBirthday(personInfo))
        {
            person.BirthDay = personInfo;
        }
        else
        {
            person.Name = personInfo;
        }

        return person;
    }

    static bool IsBirthday(string input)
    {
        if (input.Contains("/"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

