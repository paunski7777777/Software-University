using System;
using System.Collections.Generic;
using System.Linq;
public class Database
{
    private HashSet<Person> people;

    public Database()
    {
        this.people = new HashSet<Person>();
    }

    public Database(IEnumerable<Person> people)
        : this()
    {
        if (people != null)
        {
            foreach (var person in people)
            {
                this.Add(person);
            }
        }
    }

    public int Count => this.people.Count;

    public void Add(Person person)
    {
        if (this.people.Any(p => p.Id == person.Id || p.Username == person.Username))
        {
            throw new InvalidOperationException();
        }

        this.people.Add(person);
    }

    public void Remove(Person person)
    {
        this.people.RemoveWhere(p => p.Id == person.Id && p.Username == person.Username);
    }

    public Person Find(long id)
    {
        if (id < 0)
        {
            throw new ArgumentOutOfRangeException();
        }

        var foundPerson = this.people.FirstOrDefault(p => p.Id == id);
        if (foundPerson == null)
        {
            throw new InvalidOperationException();
        }

        return foundPerson;
    }

    public Person Find(string username)
    {
        if (username == null)
        {
            throw new ArgumentNullException();
        }

        var foundPerson = this.people.FirstOrDefault(p => p.Username == username);
        if (foundPerson == null)
        {
            throw new InvalidOperationException();
        }

        return foundPerson;
    }
}