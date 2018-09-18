using System.Collections.Generic;
public class PersonAgeComparer : IComparer<Person>
{
    public int Compare(Person firstPerson, Person secondPerson)
    {
        return firstPerson.Age.CompareTo(secondPerson.Age);
    }
}

